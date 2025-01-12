using MoonSharp.Interpreter;
using PackWeaver.Scripting.Services;

namespace PackWeaver.Scripting {
    public class ScriptHost {
        public List<FunctionFile> Functions;
        public Guid CurrentFunction;
        public string PackName;

        public EntityService entityService;
        public HUDService hudService;
        public PackService packService;
        public PlayerService playerService;
        public ScoreboardService scoreboardService;
        public ServerService serverService;
        public WorldService worldService;

        public ScriptHost(string packName) {
            this.Functions = new List<FunctionFile>();

            FunctionFile mainFunc = new FunctionFile("main");
            this.Functions.Add(mainFunc);
            this.CurrentFunction = mainFunc.Id;

            this.entityService = new EntityService(this);
            this.hudService = new HUDService(this);
            this.packService = new PackService(this);
            this.playerService = new PlayerService(this);
            this.scoreboardService = new ScoreboardService(this);
            this.serverService = new ServerService(this);
            this.worldService = new WorldService(this);

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