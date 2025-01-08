using MoonSharp.Interpreter;

namespace PackWeaver.Scripting.Services {
    [MoonSharpUserData]
    public class HUDService : Service {
        public HUDService(ScriptHost host) : base(host) {}

        public void Tellraw(string whatToTell, string selector = "@s") {
            this._host.AddCommandToCurrentFunction($"tellraw {selector} {whatToTell}");
        }

        public void Title(string textToPrint, string selector = "@s") {
            this._host.AddCommandToCurrentFunction($"title {selector} title {textToPrint}");
        }

        public void Subtitle(string textToPrint, string selector = "@s") {
            this._host.AddCommandToCurrentFunction($"title {selector} subtitle {textToPrint}");
        }

        public void ActionBar(string textToPrint, string selector = "@s") {
            this._host.AddCommandToCurrentFunction($"title {selector} actionbar {textToPrint}");
        }

        public void ClearTitle(string selector = "@s") {
            this._host.AddCommandToCurrentFunction($"title {selector} clear");
        }
    }
}