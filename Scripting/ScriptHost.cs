using MoonSharp.Interpreter;

namespace PackWeaver.Scripting {
    [MoonSharpUserData]
    public class ScriptHost {
        public List<FunctionFile> Functions;
        private Guid CurrentFunction;
        private string PackName;

        public ScriptHost(string packName) {
            this.Functions = new List<FunctionFile>();

            FunctionFile mainFunc = new FunctionFile("main");
            this.Functions.Add(mainFunc);
            this.CurrentFunction = mainFunc.Id;

            this.PackName = packName;
        }

        public Guid GetFunctionIdFromName(string name) {
            foreach (var func in this.Functions) {
                if (func.Name == name) {
                    return func.Id;
                }
            }

            return Guid.Empty;
        }

        public void AddCommandToCurrentFunction(string command) {
            foreach (var func in this.Functions) {
                if (func.Id == CurrentFunction) {
                    func.Lines.Add(command);
                }
            }
        }

        public void Command(string command) {
            AddCommandToCurrentFunction(command);
        }

        public void Say(string chatMessage) {
            AddCommandToCurrentFunction($"say {chatMessage}");
        }

        public void Give(string itemId, int count = 1, string selector = "@s") {
            AddCommandToCurrentFunction($"give {selector} {itemId}[] {count}");
        }

        public void Summon(string mobId) {
            AddCommandToCurrentFunction($"summon {mobId}");
        }

        public void SetTime(int time) {
            AddCommandToCurrentFunction($"time set {time}");
        }

        public void TeleportToLocation(float X, float Y, float Z, bool relative = false, string selector = "@s") {
            string coords = $"{X} {Y} {Z}";
            if (relative)
                coords = $"~{X} ~{Y} ~{Z}";
            
            AddCommandToCurrentFunction($"tp {selector} {coords}");
        }

        public void TeleportToEntity(string target, string selector = "@s") {
            AddCommandToCurrentFunction($"tp {selector} {target}");
        }
        
        public void ApplyEffect(string effectId, int amplifier, int time, bool hideParticles = false, string selector = "@s") {
            AddCommandToCurrentFunction($"effect give {selector} {effectId} {time} {amplifier} {hideParticles.ToString().ToLower()}");
        }

        public void Enchant(string enchantId, int level, string selector = "@s") {
            AddCommandToCurrentFunction($"enchant {selector} {enchantId} {level}");
        }

        public void Execute(DynValue luaParams, DynValue luaCallback) {
            var parameters = luaParams.Table.Values;
            List<string> paramsList = new List<string>();
            foreach (var param in parameters) {
                paramsList.Add(param.String);
            }
            string paramsStr = String.Join(" ", paramsList);

            Console.WriteLine(paramsStr);

            try {
                Guid lastFunc = CurrentFunction;

                Random random = new Random();
                int id = random.Next(0, 3000);
                FunctionFile cbFunc = new FunctionFile($"callback_{id}");
                this.Functions.Add(cbFunc);
                this.CurrentFunction = cbFunc.Id;

                luaCallback.Function.Call();

                this.CurrentFunction = lastFunc;

                AddCommandToCurrentFunction($"execute {paramsStr} run function {this.PackName}:callback_{id}");
            }
            catch (Exception ex) {
                Console.WriteLine($"Error executing callback: {ex.Message}");
            }
        }
    }
}