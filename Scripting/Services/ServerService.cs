using MoonSharp.Interpreter;

namespace PackWeaver.Scripting.Services {
    [MoonSharpUserData]
    public class ServerService : Service {
        public ServerService(ScriptHost host) : base(host) {}

        public void Kick(string target, string reason) {
            this._host.AddCommandToCurrentFunction($"kick {target} {reason}");
        }

        public void Ban(string target, string reason) {
            this._host.AddCommandToCurrentFunction($"ban {target} {reason}");
        }

        public void Say(string message) {
            this._host.AddCommandToCurrentFunction($"say {message}");
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

        public void CreateBossBar(string barId, string name) {
            this._host.AddCommandToCurrentFunction($"bossbar add {barId} {name}");
        }

        public void RemoveBossBar(string barId) {
            this._host.AddCommandToCurrentFunction($"bossbar remove {barId}");
        }

        public void Reload() {
            this._host.AddCommandToCurrentFunction($"reload");
        }

        public void Command(string cmd) {
            this._host.AddCommandToCurrentFunction(cmd);
        }
    }
}