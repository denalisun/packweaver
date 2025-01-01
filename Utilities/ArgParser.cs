using System.Reflection.Metadata;

namespace PackWeaver.Utilities {
    public enum ProgramTask {
        INITIALIZE_PROJECT,
        COMPILE
    }

    public class ArgParser {
        private string[] Arguments;

        public ArgParser(string[] args) {
            this.Arguments = args;
        }

        public ProgramTask GetTask() {
            bool bShouldInit = false;
            if (this.Arguments.Contains("--init"))
                bShouldInit = true;

            return bShouldInit ? ProgramTask.INITIALIZE_PROJECT : ProgramTask.COMPILE;
        }
    }
}