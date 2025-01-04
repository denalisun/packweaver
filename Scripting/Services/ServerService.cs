using MoonSharp.Interpreter;

namespace PackWeaver.Scripting.Services {
    [MoonSharpUserData]
    public class ServerService {
        private ScriptHost _host;

        public ServerService(ScriptHost host) {
            this._host = host;
        }

        public void Kick(string target, string reason) {
            this._host.AddCommandToCurrentFunction($"kick {target} {reason}");
        }

        public void Ban(string target, string reason) {
            this._host.AddCommandToCurrentFunction($"ban {target} {reason}");
        }

        public void AddToWhitelist(string target) {
            this._host.AddCommandToCurrentFunction($"whitelist add {target}");
        }

        public void EnableWhitelist() {
            this._host.AddCommandToCurrentFunction($"whitelist on");
        }

        public void DisableWhitelist() {
            this._host.AddCommandToCurrentFunction($"whitelist off");
        }

        public void ReloadWhitelist() {
            this._host.AddCommandToCurrentFunction($"whitelist reload");
        }

        public void SetGamerule(string gamerule, string value) {
            this._host.AddCommandToCurrentFunction($"gamerule {gamerule} {value}");
        }

        public void SetDifficulty(string difficulty) {
            this._host.AddCommandToCurrentFunction($"difficulty {difficulty}");
        }

        public void SetDefaultGameMode(string gamemode) {
            this._host.AddCommandToCurrentFunction($"defaultgamemode {gamemode}");
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
                Guid lastFunc = this._host.CurrentFunction;

                Random random = new Random();
                int id = random.Next(0, 3000);
                FunctionFile cbFunc = new FunctionFile($"callback_{id}");
                this._host.Functions.Add(cbFunc);
                this._host.CurrentFunction = cbFunc.Id;

                luaCallback.Function.Call();

                this._host.CurrentFunction = lastFunc;

                this._host.AddCommandToCurrentFunction($"execute {paramsStr} run function {this._host.PackName}:callback_{id}");
            }
            catch (Exception ex) {
                Console.WriteLine($"Error executing callback: {ex.Message}");
            }
        }

        public void CreateScoreboardObjective(string objId, string criteria, string displayName = "") {
            string rdisplayName = displayName != "" ? displayName : objId;

            this._host.AddCommandToCurrentFunction($"scoreboard objectives add {objId} {criteria} {displayName}");
        }

        public void RemoveScoreboardObjective(string objId) {
            this._host.AddCommandToCurrentFunction($"scoreboard objectives remove {objId}");
        }

        public void SetDisplayForScoreboardObjective(string objId, string position) {
            this._host.AddCommandToCurrentFunction($"scoreboard objectives setdisplay {position} {objId}");
        }

        public void CreateBossBar(string barId, string name) {
            this._host.AddCommandToCurrentFunction($"bossbar add {barId} {name}");
        }

        public void RemoveBossBar(string barId) {
            this._host.AddCommandToCurrentFunction($"bossbar remove {barId}");
        }

        public void Reload() {
            this._host.AddCommandToCurrentFunction($"reload");
        }
    }
}