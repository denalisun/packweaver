using System.Runtime.CompilerServices;
using MoonSharp.Interpreter;

namespace PackWeaver.Scripting.Services {
    [MoonSharpUserData]
    public class ScoreboardService : Service {
        public ScoreboardService(ScriptHost host) : base(host) {}

        public void CreateObjective(string objId, string criteria, string displayName = "") {
            string rdisplayName = displayName != "" ? displayName : objId;

            this._host.AddCommandToCurrentFunction($"scoreboard objectives add {objId} {criteria} {displayName}");
        }

        public void RemoveObjective(string objId) {
            this._host.AddCommandToCurrentFunction($"scoreboard objectives remove {objId}");
        }

        public void SetDisplay(string objId, string position) {
            this._host.AddCommandToCurrentFunction($"scoreboard objectives setdisplay {position} {objId}");
        }

        public void ListObjectives() {
            this._host.AddCommandToCurrentFunction($"scoreboard objectives list");
        }

        // Need to add Modify

        public void SetPlayerScore(string objective, int score, string selector = "@s") {
            this._host.AddCommandToCurrentFunction($"scoreboard players set {selector} {objective} {score}");
        }

        public void AddPlayerScore(string objective, int score, string selector = "@s") {
            this._host.AddCommandToCurrentFunction($"scoreboard players add {selector} {objective} {score}");
        }

        public void RemovePlayerScore(string objective, int score, string selector = "@s") {
            this._host.AddCommandToCurrentFunction($"scoreboard players remove {selector} {objective} {score}");
        }

        public void ResetPlayerScore(string objective, string selector = "@s") {
            this._host.AddCommandToCurrentFunction($"scoreboard players reset {selector} {objective}");
        }

        public void EnablePlayerTrigger(string objective, string selector = "@s") {
            this._host.AddCommandToCurrentFunction($"scoreboard players enable {selector} {objective}");
        }
    }
}