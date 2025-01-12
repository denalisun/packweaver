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
            if (serviceName == "PackService")
                return _packService;
            
            if (serviceName == "ServerService")
                return _serverService;
            
            if (serviceName == "ScoreboardService")
                return _scoreboardService;

            if (serviceName == "WorldService")
                return _worldService;

            if (serviceName == "EntityService")
                return _entityService;
            
            if (serviceName == "PlayerService")
                return _playerService;

            if (serviceName == "HUDService")
                return _hudService;

            Console.WriteLine("ERROR on GetService: A correct service was not specified.");
            return _packService;
        }
    }
}