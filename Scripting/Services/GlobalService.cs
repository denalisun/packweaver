using MoonSharp.Interpreter;
using PackWeaver.Scripting.Types;

namespace PackWeaver.Scripting.Services {
    [MoonSharpUserData]
    public class GlobalService : Service {
        public GlobalService(ScriptHost host) : base(host) {}

        public Execute lua_executeFactory() {
            return new Execute(this._host);
        }

        public void lua_mcIfStatement(DynValue paramsTable, DynValue callback) {
            //TODO: If statement
        }
    }
}