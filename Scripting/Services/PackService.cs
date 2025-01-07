using MoonSharp.Interpreter;

namespace PackWeaver.Scripting.Services {
    [MoonSharpUserData]
    public class PackService : Service {
        public PackService(ScriptHost host) : base(host) {}

        public void RegisterTick(DynValue callback, string tickFuncName) {
            try {
                Guid lastFunc = this._host.CurrentFunction;

                FunctionFile cbFunc = new FunctionFile($"{tickFuncName}");
                cbFunc.isTick = true;

                this._host.Functions.Add(cbFunc);
                this._host.CurrentFunction = cbFunc.Id;

                callback.Function.Call();

                this._host.CurrentFunction = lastFunc;
            } catch (Exception ex) {
                Console.WriteLine($"Failed to register tick function: {ex.Message}");
            }
        }

        public void RegisterFunction(DynValue callback, string funcName) {
            //TODO: Do this later cuz i cba to do this now
        }
    }
}