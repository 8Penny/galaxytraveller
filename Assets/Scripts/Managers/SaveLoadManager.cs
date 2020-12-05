using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using Core;
using Interfaces;
using Objects;
using Storage;
using UnityEngine;

namespace Managers
{
    [CreateAssetMenu(fileName = "SaveLoadManager", menuName = "Managers/SaveLoadManager")]
    public class SaveLoadManager: BaseManager, IAwake
    {
        private Save _save;
        private string _savePath ;
        public void OnAwake()
        {
            _savePath = Application.persistentDataPath + "/gamesave.save";
            _save = LoadGame() ?? new Save();
        }

        public List<EnvironmentElement> GetEnvironment()
        {
            return _save.homePlanetElements;
        }
        
        private void SaveHomeLocation()
        {
            var homeLocationMng = GameCore.Get<HomeLocationManager>();
            _save.homePlanetElements = homeLocationMng.GetEnvironmentElements();
        }


        private void SavePlayerParameters()
        {
//            _save.playerEnergy = _game.player.energy;
//            _save.playerHealth = _game.player.health;
//            _save.playerPoints = _game.player.points;
//            _save.playerRang = _game.player.rang;
//
//            _save.playerPosition = _game.player.position;
//            _save.playerRotation = _game.player.rotation;
//            
//            _save.playerInventory = new InventoryStorage();
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


        private Save LoadGame()
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