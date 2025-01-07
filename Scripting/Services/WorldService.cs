using MoonSharp.Interpreter;

namespace PackWeaver.Scripting.Services {
    [MoonSharpUserData]
    public class WorldService : Service {
        public WorldService(ScriptHost host) : base(host) {}

        public void SetBlock(float X, float Y, float Z, string blockId) {
            this._host.AddCommandToCurrentFunction($"setblock {X} {Y} {Z} {blockId}");
        }

        public void SetWeather(string weatherId) {
            this._host.AddCommandToCurrentFunction($"weather {weatherId}");
        }

        public void SetTimeOfDay(int time) {
            this._host.AddCommandToCurrentFunction($"time set {time}");
        }
    }
}