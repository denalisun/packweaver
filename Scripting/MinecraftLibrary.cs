using MoonSharp.Interpreter;

namespace PackWeaver.Scripting {
    [MoonSharpUserData]
    public class MinecraftLibrary {
        public List<string> finalFunc;
        private string packName;

        public MinecraftLibrary(string packName) {
            this.finalFunc = new List<string>();
            this.packName = packName;
        }

        public void Command(string command) {
            finalFunc.Add(command);
        }

        public void Say(string chatMessage) {
            finalFunc.Add($"say {chatMessage}");
        }

        public void Give(string itemId, int count = 1, string selector = "@s") {
            finalFunc.Add($"give {selector} {itemId}[] {count}");
        }

        public void Summon(string mobId) {
            finalFunc.Add($"summon {mobId}");
        }

        public void SetTime(int time) {
            finalFunc.Add($"time set {time}");
        }

        public void Execute(DynValue luaParams, DynValue luaCallback) {
            var parameters = luaParams.Table.Values;
            string paramsStr = string.Join(" ", parameters);

            Action callback = () => {
                try {
                    luaCallback.Function.Call();
                }
                catch (Exception ex) {
                    Console.WriteLine($"Error executing callback: {ex.Message}");
                }
            };
        }
    }
}