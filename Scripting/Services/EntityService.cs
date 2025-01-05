using MoonSharp.Interpreter;

namespace PackWeaver.Scripting.Services {
    [MoonSharpUserData]
    public class EntityService {
        private ScriptHost _host;

        public EntityService(ScriptHost host) {
            this._host = host;
        }

        public void TeleportToLocation(float x, float y, float z, bool relative = false, string selector = "@s") {
            string cmd = $"tp {selector} {x} {y} {z}";
            if (relative)
                cmd = $"tp {selector} ~{x} ~{y} ~{z}";
            
            this._host.AddCommandToCurrentFunction(cmd);
        }

        public void TeleportToEntity(string target, string selector = "@s") {
            this._host.AddCommandToCurrentFunction($"tp {selector} {target}");
        }

        public void SummonEntity(string entityToSummon) {
            this._host.AddCommandToCurrentFunction($"summon {entityToSummon}");
        }

        public void Kill(string selector = "@s") {
            this._host.AddCommandToCurrentFunction($"kill {selector}");
        }

        public void AddTag(string tag, string selector = "@s") {
            this._host.AddCommandToCurrentFunction($"tag {selector} add {tag}");
        }

        public void RemoveTag(string tag, string selector = "@s") {
            this._host.AddCommandToCurrentFunction($"tag {selector} remove {tag}");
        }

        public void ListTags(string selector = "@s") {
            this._host.AddCommandToCurrentFunction($"tag {selector} list");
        }
    }
}