using MoonSharp.Interpreter;
using MoonSharp.Interpreter.Interop;

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
    }
}