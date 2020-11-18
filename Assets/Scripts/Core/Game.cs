using Actors;
using Location;

namespace Core
{
    public class Game
    {
        private static Game _instance;
        private Player _player;
        private HomePlanet _homePlanet;

        public static Game instance => _instance;

        public Player player => _player;
        public HomePlanet homePlanet => _homePlanet;


        public Game()
        {
            if (_instance != null && _instance != this)
            {
                return;
            }

            _instance = this;
            _player = new Player();
            _homePlanet = new HomePlanet();
        }

        public void LoadGameData(Save save)
        {
            _player.SetEnergy(save.playerEnergy);
            _player.SetPoints(save.playerPoints);
            _player.SetRang(save.playerRang);
            _player.SetHealth(save.playerHealth);

            _homePlanet.FillEnvironmentElements(save.homePlanetElements);
        }
    }
}