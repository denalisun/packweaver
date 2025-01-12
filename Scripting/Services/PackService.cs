using MoonSharp.Interpreter;

namespace PackWeaver.Scripting.Services {
    [MoonSharpUserData]
    public class PackService : Service {
        public PackService(ScriptHost host) : base(host) {}

        public void RegisterFunction(DynValue callback, string funcName, bool isTick = false) {
            try {
                Guid lastFunc = this._host.CurrentFunction;

                FunctionFile cbFunc = new FunctionFile($"{funcName}");
                cbFunc.isTick = isTick;

                this._host.Functions.Add(cbFunc);
                this._host.CurrentFunction = cbFunc.Id;

                callback.Function.Call();

                this._host.CurrentFunction = lastFunc;
            } catch (Exception ex) {
                Console.WriteLine($"Failed to register function: {ex.Message}");
            }
        }
    }
}