using Actors;
using Location;

namespace Core
{
    public class Game : Singleton<Game>
    {
        private Player _player = new Player();
        private HomePlanet _homePlanet = new HomePlanet();

        private int _currentPanel;

        public Player player => _player;
        public HomePlanet homePlanet => _homePlanet;
        public int currentPanel => _currentPanel;

        public delegate void ChangePanelEvent();

        private event ChangePanelEvent Changed;


        public void LoadGameData(Save save)
        {
            _player.SetEnergy(save.playerEnergy);
            _player.SetPoints(save.playerPoints);
            _player.SetRang(save.playerRang);
            _player.SetHealth(save.playerHealth);

            _player.SetPosition(save.playerPosition);
            _player.SetRotation(save.playerRotation);

            _homePlanet.FillEnvironmentElements(save.homePlanetElements);
        }
    }
}