using MoonSharp.Interpreter;

namespace PackWeaver.Scripting.Services {
    [MoonSharpUserData]
    public class WorldService {
        private ScriptHost _host;

        public WorldService(ScriptHost host) {
            this._host = host;
        }

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