namespace PackWeaver.Scripting.Services {
    public class PlayerService {
        private ScriptHost _host;

        public PlayerService(ScriptHost host) {
            this._host = host;
        }

        public void Enchant(string enchantId, int level, string selector = "@s") {
            this._host.AddCommandToCurrentFunction($"enchant {selector} {enchantId} {level}");
        }

        public void SetXPLevels(int amount, string selector = "@s") {
            this._host.AddCommandToCurrentFunction($"xp set {selector} {amount} levels");
        }

        public void AddXPLevels(int amount, string selector = "@s") {
            this._host.AddCommandToCurrentFunction($"xp add {selector} {amount} levels");
        }

        public void SetXPPoints(int amount, string selector = "@s") {
            this._host.AddCommandToCurrentFunction($"xp set {selector} {amount} levels");
        }

        public void AddXPPoints(int amount, string selector = "@s") {
            this._host.AddCommandToCurrentFunction($"xp add {selector} {amount} levels");
        }

        public void SetSpawnPoint(int x, int y, int z, float angle, string selector = "@s") {
            this._host.AddCommandToCurrentFunction($"spawnpoint {selector} {x} {y} {z} {angle}");
        }

        public void Message(string target, string message) {
            this._host.AddCommandToCurrentFunction($"msg {target} {message}");
        }

        public void TeamMessage(string message) {
            this._host.AddCommandToCurrentFunction($"teammsg {message}");
        }

        public void ClearItem(string item, int maxCount, string selector = "@s") {
            this._host.AddCommandToCurrentFunction($"clear {selector} {item} {maxCount}");
        }

        public void ClearInventory(string selector = "@s") {
            this._host.AddCommandToCurrentFunction($"clear {selector}");
        }

        public void GiveItem(string item, int count, string selector = "@s") {
            this._host.AddCommandToCurrentFunction($"give {selector} {item}[] {count}");
        }
    }
}