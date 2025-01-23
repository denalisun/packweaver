using MoonSharp.Interpreter;
using PackWeaver.Scripting.Types;

namespace PackWeaver.Scripting.Services {
    [MoonSharpUserData]
    public class GlobalService : Service {
        public GlobalService(ScriptHost host) : base(host) {}

        public Execute lua_executeFactory() {
            return new Execute(this._host);
        }

        public void lua_mcIfStatement(DynValue paramsTable, DynValue callback, string selector = "@s") {
            List<string> paramsList = new List<string>();
            paramsList.Add($"as {selector}");
            paramsList.Add($"at {selector}");
            foreach (var param in paramsTable.Table.Values)
                paramsList.Add(param.String);
            
            try {
                Guid lastFunc = this._host.CurrentFunction;

                Random random = new Random();
                int id = random.Next(0, 3000);
                FunctionFile cbFunc = new FunctionFile($"callback_{id}");
                this._host.Functions.Add(cbFunc);
                this._host.CurrentFunction = cbFunc.Id;

                callback.Function.Call();

                this._host.CurrentFunction = lastFunc;
                this._host.AddCommandToCurrentFunction($"execute {String.Join(" ", paramsList)} run function {this._host.PackName}:callback_{id}");
            } catch (Exception ex) {
                Console.WriteLine($"Error executing callback: {ex.Message}");
            }
        }
    }
}