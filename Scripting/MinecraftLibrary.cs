using MoonSharp.Interpreter;

namespace PackWeaver.Scripting {
    [MoonSharpUserData]
    public class MinecraftLibrary {
        public List<string> finalFunc;

        public MinecraftLibrary() {
            finalFunc = new List<string>();
        }

        public void Chat(string chatMessage) {
            finalFunc.Add($"say {chatMessage}");
        }

        public void Give(string itemId, int count = 1, string selector = "@s") {
            finalFunc.Add($"give {selector} {itemId}[] {count}");
        }

        public void Summon(string mobId) {
            finalFunc.Add($"summon {mobId}");
        }
    }
}