using MoonSharp.Interpreter;
using Newtonsoft.Json;
using PackWeaver.Models;
using PackWeaver.Scripting;
using PackWeaver.Utilities;

namespace PackWeaver {
    static class Program {
        private static void rizz() {
            Console.WriteLine("Rizzy Gyatt");
        }

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
                Config? config = null;
                using (StreamReader reader = new StreamReader(Path.Join(CurrentDir, @"./packweaver.json"))) {
                    string json = reader.ReadToEnd();
                    config = JsonConvert.DeserializeObject<Config>(json);
                }
                
                UserData.RegisterType<MinecraftLibrary>();
                Script script = new Script();

                MinecraftLibrary mc = new MinecraftLibrary(config.name);
                script.Globals["mc"] = mc;
                script.DoFile(Path.Join(CurrentDir, config?.datapack.entrypoint));
                
                // Let's create the dist folder
                Directory.CreateDirectory(Path.Join(CurrentDir, "dist"));

                // unfortunately i need to make the datapack folders, resourcepack will come l8r
                string FunctionDir = Path.Join(CurrentDir, $"dist/data/{config?.name}/function");
                Directory.CreateDirectory(FunctionDir);

                foreach (var Function in mc.Functions) {
                    Console.WriteLine($"Compiling {Function.Name}...");
                    string FuncPath = Path.Join(FunctionDir, $"{Function.Name}.mcfunction");
                    using (StreamWriter writer = new StreamWriter(FuncPath)) {
                        foreach (string line in Function.Lines)
                            writer.WriteLine(line);
                    }
                }
            }
        }
    }
}