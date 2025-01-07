using MoonSharp.Interpreter;

namespace PackWeaver.Scripting {
    public class ScriptHost {
        public List<FunctionFile> Functions;
        public Guid CurrentFunction;
        public string PackName;

        public ScriptHost(string packName) {
            this.Functions = new List<FunctionFile>();

            FunctionFile mainFunc = new FunctionFile("main");
            this.Functions.Add(mainFunc);
            this.CurrentFunction = mainFunc.Id;



            this.PackName = packName;
        }

        public Guid GetFunctionIdFromName(string name) {
            foreach (var func in this.Functions) {
                if (func.Name == name) {
                    return func.Id;
                }
            }

            return Guid.Empty;
        }

        public void AddCommandToCurrentFunction(string command) {
            foreach (var func in this.Functions) {
                if (func.Id == CurrentFunction) {
                    func.Lines.Add(command);
                }
            }
        }
    }
}