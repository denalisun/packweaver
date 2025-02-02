using MoonSharp.Interpreter;
using PackWeaver.Scripting.Types;

namespace PackWeaver.Scripting.Services {
    [MoonSharpUserData]
    public class EntityService : Service {
        public EntityService(ScriptHost host) : base(host) {}

        public void Teleport(Location loc, string selector = "@s") {
            this._host.AddCommandToCurrentFunction($"tp {selector} {loc.ToString()}");
        }

        public void Teleport(string target, string selector = "@s") {
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

        public void ApplyEffect(string effectId, int time, int amplifier, bool hideParticles = false, string selector = "@s") {
            this._host.AddCommandToCurrentFunction($"effect give {selector} {effectId} {time} {amplifier} {hideParticles.ToString().ToLower()}");
        }

        public void ClearEffect(string effectId, string selector = "@s") {
            this._host.AddCommandToCurrentFunction($"effect clear {selector} {effectId}");
        }

        public void ClearAllEffects(string selector = "@s") {
            this._host.AddCommandToCurrentFunction($"effect clear {selector}");
        }

        public void RideVehicle(string target, string selector = "@s") {
            this._host.AddCommandToCurrentFunction($"ride {selector} mount {target}");
        }

        public void DismountVehicle(string selector = "@s") {
            this._host.AddCommandToCurrentFunction($"ride {selector} dismount");
        }
    }
}