using System;
using System.IO;
using UnityEngine;

namespace Save.Managers
{
    public class SaveManager : MonoBehaviour
    {
        private string saveFolder;

        private void Awake()
        {
            saveFolder = Path.Combine(Application.persistentDataPath, "Saves");

            if (!Directory.Exists(saveFolder))
                Directory.CreateDirectory(saveFolder);
        }

        public void CreateSave(int slot, string saveName)
        {
            SaveData data = new SaveData
            {
                Slot = slot,
                SaveName = saveName,
                CreatedAt = DateTime.Now.ToString("dd.MM.yyyy HH:mm"),
                LastPlayedAt = DateTime.Now.ToString("dd.MM.yyyy HH:mm")
            };

            string json = JsonUtility.ToJson(data, true);

            string path = Path.Combine(saveFolder, $"slot{slot}.json");

            File.WriteAllText(path, json);

            Debug.Log($"Сохранение Slot {slot} создано.");
        }

        public SaveData LoadSave(int slot)
        {
            string path = Path.Combine(saveFolder, $"slot{slot}.json");

            if (!File.Exists(path))
                return null;

            string json = File.ReadAllText(path);

            return JsonUtility.FromJson<SaveData>(json);
        }

        public void DeleteSave(int slot)
        {
            string path = Path.Combine(saveFolder, $"slot{slot}.json");

            if (File.Exists(path))
                File.Delete(path);
        }
    }
}