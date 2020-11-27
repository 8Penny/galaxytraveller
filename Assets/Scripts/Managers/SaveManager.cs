using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using Core;
using Objects;
using Storage;
using UnityEngine;

namespace Managers
{
    public class SaveManager
    {
        private Game _game;
        private Save _save = new Save();

        private readonly string _savePath;

        public SaveManager()
        {
            _game = Game.instance;
            _savePath = Application.persistentDataPath + "/gamesave.save";
        }


        private void SaveHomeLocation()
        {
            _save.homePlanetElements = _game.homePlanet.environmentElements;
        }


        private void SavePlayerParameters()
        {
            _save.playerEnergy = _game.player.energy;
            _save.playerHealth = _game.player.health;
            _save.playerPoints = _game.player.points;
            _save.playerRang = _game.player.rang;

            _save.playerPosition = _game.player.position;
            _save.playerRotation = _game.player.rotation;
            
            _save.playerInventory = new InventoryStorage();
        }


        public void SaveGame()
        {
            SavePlayerParameters();
            SaveHomeLocation();

            var bf = new BinaryFormatter();
            var file = File.Create(_savePath);
            bf.Serialize(file, _save);
            file.Close();
        }


        public Save LoadGame()
        {
            var fileNotExists = !File.Exists(_savePath);

            if (fileNotExists)
            {
                Debug.Log($"file {_savePath} is not existing");
                return null;
            }

            var bf = new BinaryFormatter();
            var file = File.Open(_savePath, FileMode.Open);
            _save = (Save) bf.Deserialize(file);
            file.Close();

            return _save;
        }
    }
}