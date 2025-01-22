using MoonSharp.Interpreter;

namespace PackWeaver.Scripting.Types {
    public class Execute {
        private ScriptHost _host;
        private List<string> _paramsList;

        public Execute(ScriptHost host) {
            this._host = host;
            this._paramsList = new List<string>();
        }

        public Execute _as(string selector) {
            this._paramsList.Add($"as {selector}");
            return this;
        }

        public Execute at(string selector) {
            this._paramsList.Add($"at {selector}");
            return this;
        }

        public Execute if_block(Location loc, string blockId) {
            this._paramsList.Add($"if block {loc.ToString()} {blockId}");
            return this;
        }

        public void run(DynValue callback) {
            try {
                Guid lastFunc = this._host.CurrentFunction;

                Random random = new Random();
                int id = random.Next(0, 3000);
                FunctionFile cbFunc = new FunctionFile($"callback_{id}");
                this._host.Functions.Add(cbFunc);
                this._host.CurrentFunction = cbFunc.Id;

                callback.Function.Call();

                this._host.CurrentFunction = lastFunc;
                this._host.AddCommandToCurrentFunction($"execute {String.Join(" ", this._paramsList)} run function {this._host.PackName}:callback_{id}");
            } catch (Exception ex) {
                Console.WriteLine($"Error executing callback: {ex.Message}");
            }
        }
    }
}