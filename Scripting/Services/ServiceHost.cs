using MoonSharp.Interpreter;

namespace PackWeaver.Scripting.Services {
    [MoonSharpUserData]
    public class ServiceHost {
        protected ScriptHost _host;

        private PackService _packService;
        private ServerService _serverService;
        private ScoreboardService _scoreboardService;
        private WorldService _worldService;
        private EntityService _entityService;
        private PlayerService _playerService;
        private HUDService _hudService;

        public ServiceHost(ScriptHost host) {
            this._host = host;

            this._packService = new PackService(host);
            this._serverService = new ServerService(host);
            this._scoreboardService = new ScoreboardService(host);
            this._worldService = new WorldService(host);
            this._entityService = new EntityService(host);
            this._playerService = new PlayerService(host);
            this._hudService = new HUDService(host);
        }

        public Service GetService(string serviceName) {
            return this._entityService;
        }
    }
}