using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using Core;
using Interfaces;
using Objects;
using Storage;
using UnityEngine;

namespace Managers {
    [CreateAssetMenu(fileName = "SaveLoadManager", menuName = "Managers/SaveLoadManager")]
    public class SaveLoadManager : BaseManager, IAwake {
        private Save _save = new Save();
        private string _savePath;

        public void OnAwake() {
            _savePath = Application.persistentDataPath + "/gamesave.save";
            LoadGame();

            var playerStatsMng = GameCore.Get<PlayerStatsManager>();
            playerStatsMng.WriteStatsFromSave(_save);
        }

        public bool wasHomeGenerated => _save.wasHomeGenerated;

        public void SetHomeGenerated(bool value) {
            _save.wasHomeGenerated = value;
        }

        public List<EnvironmentElement> GetEnvironment() {
            return _save.homePlanetElements;
        }

        private void SaveHomeLocation() {
            var homeLocationMng = GameCore.Get<HomeLocationManager>();
            _save.homePlanetElements = homeLocationMng.GetEnvironmentElements();
        }


        private void SavePlayerParameters() {
            var playerStatsMng = GameCore.Get<PlayerStatsManager>();
            _save.playerEnergy = playerStatsMng.GetEnergy();
            _save.playerHealth = playerStatsMng.GetHealth();
            _save.playerPoints = playerStatsMng.GetPoints();
            _save.playerRang = playerStatsMng.GetRang();

            _save.playerPosition = playerStatsMng.GetPosition();
            _save.playerRotation = playerStatsMng.GetRotation();

            _save.playerInventory = playerStatsMng.GetInventory();
        }


        public void SaveGame() {
            SavePlayerParameters();
            SaveHomeLocation();

            var bf = new BinaryFormatter();
            var file = File.Create(_savePath);
            bf.Serialize(file, _save);
            file.Close();
        }


        private void LoadGame() {
            var fileNotExists = !File.Exists(_savePath);

            if (fileNotExists) {
                Debug.Log($"file {_savePath} is not existing");
                return;
            }

            var bf = new BinaryFormatter();
            var file = File.Open(_savePath, FileMode.Open);
            _save = (Save) bf.Deserialize(file);
            file.Close();
        }
    }
}