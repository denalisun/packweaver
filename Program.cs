using MoonSharp.Interpreter;
using Newtonsoft.Json;
using PackWeaver.Models;
using PackWeaver.Scripting;
using PackWeaver.Scripting.Services;
using PackWeaver.Utilities;

namespace PackWeaver {
    static class Program {
        static void Main(string[] args) {
            ArgParser argParser = new ArgParser(args);
            ProgramTask task = argParser.GetTask();
            
            string CurrentDir = Directory.GetCurrentDirectory();

            if (task == ProgramTask.INITIALIZE_PROJECT) {
                // Create Config
                Config config = new Config();
                config.datapack = new DatapackData();

                config.name = Path.GetFileName(CurrentDir.TrimEnd(Path.DirectorySeparatorChar));
                config.description = "Created with PackWeaver!";

                string json = JsonConvert.SerializeObject(config, Formatting.Indented);
                File.WriteAllText(Path.Combine(CurrentDir, "packweaver.json"), json);

                // Create Main file
                string srcDir = Path.Join(CurrentDir, "src");
                Directory.CreateDirectory(srcDir);
                File.WriteAllText(Path.Combine(srcDir, "main.lua"), "mc:Chat(\"Hello, Minecraft!\")");
            } else {
                if (Directory.Exists(Path.Combine(CurrentDir, "dist"))) {
                    DirectoryInfo di = new DirectoryInfo(Path.Combine(CurrentDir, "dist"));
                    foreach (FileInfo file in di.EnumerateFiles()) {
                        file.Delete();
                    }

                    foreach (DirectoryInfo dir in di.EnumerateDirectories()) {
                        dir.Delete(true);
                    }
                }
                
                Config? config = null;
                using (StreamReader reader = new StreamReader(Path.Join(CurrentDir, @"./packweaver.json"))) {
                    string json = reader.ReadToEnd();
                    config = JsonConvert.DeserializeObject<Config>(json);
                }
                
                UserData.RegisterType<ScriptHost>();
                UserData.RegisterType<EntityService>();
                UserData.RegisterType<PlayerService>();
                UserData.RegisterType<ServerService>();
                UserData.RegisterType<WorldService>();
                UserData.RegisterType<ScoreboardService>();
                UserData.RegisterType<PackService>();

                UserData.RegisterType<ServiceHost>();
                Script script = new Script();

                ScriptHost host = new ScriptHost(config.name);
                ServiceHost serviceHost = new ServiceHost(host);

                script.Globals["serviceHost"] = serviceHost;

                script.DoFile(Path.Join(CurrentDir, config?.datapack.entrypoint));
                
                // Let's create the dist folder
                Directory.CreateDirectory(Path.Join(CurrentDir, "dist"));

                // unfortunately i need to make the datapack folders, resourcepack will come l8r
                string FunctionDir = Path.Join(CurrentDir, $"dist/data/{config?.name}/function");
                Directory.CreateDirectory(FunctionDir);

                foreach (var Function in host.Functions) {
                    Console.WriteLine($"Compiling {Function.Name}...");
                    string FuncPath = Path.Join(FunctionDir, $"{Function.Name}.mcfunction");
                    using (StreamWriter writer = new StreamWriter(FuncPath)) {
                        foreach (string line in Function.Lines)
                            writer.WriteLine(line);
                    }
                }

                // i completely fucking forgot about pack.mcmeta
                PackMeta meta = new PackMeta();

                PackData data = new PackData();
                data.pack_format = 61;
                data.description = config.description;

                meta.pack = data;

                string metaStr = JsonConvert.SerializeObject(meta, Formatting.Indented);
                File.WriteAllText(Path.Combine(Path.Combine(CurrentDir, "dist"), "pack.mcmeta"), metaStr);

                // Function tag stuff
                string tagPath = Path.Combine(CurrentDir, "dist/data/minecraft/tags/function");
                Directory.CreateDirectory(tagPath);

                FunctionTag loadTag = new FunctionTag([$"{config.name}:main"]);
                List<string> tickFuncs = new List<string>();
                foreach (var Function in host.Functions) {
                    if (Function.isTick)
                        tickFuncs.Add($"{config.name}:{Function.Name}");
                }
                FunctionTag tickTag = new FunctionTag(tickFuncs.ToArray());

                string loadTagStr = JsonConvert.SerializeObject(loadTag, Formatting.Indented);
                File.WriteAllText(Path.Combine(tagPath, "load.json"), loadTagStr);

                string tickTagStr = JsonConvert.SerializeObject(tickTag, Formatting.Indented);
                File.WriteAllText(Path.Combine(tagPath, "tick.json"), tickTagStr);
            }
        }
    }
}