using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;

namespace Save.Managers
{
    public class SaveManager : MonoBehaviour
    {
        public static SaveManager Instance { get; private set; }

        public int CurrentSlot { get; private set; } = -1;

        private string SaveFolder
        {
            get
            {
                string path = Path.Combine(Application.persistentDataPath, "Saves");

                if (!Directory.Exists(path))
                    Directory.CreateDirectory(path);

                return path;
            }
        }

        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
                DontDestroyOnLoad(gameObject);
            }
            else
            {
                Destroy(gameObject);
            }
        }

        public void SetCurrentSlot(int slot)
        {
            CurrentSlot = slot;
        }

        public void CreateSave(int slot, string saveName)
        {
            CurrentSlot = slot;

            SaveData data = new SaveData
            {
                Slot = slot,
                SaveName = saveName,
                CreatedAt = DateTime.Now.ToString("dd.MM.yyyy HH:mm"),
                LastPlayedAt = DateTime.Now.ToString("dd.MM.yyyy HH:mm"),
                Objects = new List<ObjectState>()
            };

            Save(data);
        }

        public void Save(SaveData data)
        {
            string json = JsonUtility.ToJson(data, true);

            File.WriteAllText(
                Path.Combine(SaveFolder, $"slot{data.Slot}.json"),
                json);
        }

        public SaveData LoadSave(int slot)
        {
            CurrentSlot = slot;

            string path = Path.Combine(SaveFolder, $"slot{slot}.json");

            if (!File.Exists(path))
                return null;

            string json = File.ReadAllText(path);

            return JsonUtility.FromJson<SaveData>(json);
        }

        public bool HasSave(int slot)
        {
            return File.Exists(Path.Combine(SaveFolder, $"slot{slot}.json"));
        }

        public void DeleteSave(int slot)
        {
            string path = Path.Combine(SaveFolder, $"slot{slot}.json");

            if (File.Exists(path))
                File.Delete(path);
        }

        public void UpdateLastPlayed(int slot)
        {
            SaveData data = LoadSave(slot);

            if (data == null)
                return;

            data.LastPlayedAt = DateTime.Now.ToString("dd.MM.yyyy HH:mm");

            Save(data);
        }

        public void SaveWorld()
        {
            if (CurrentSlot == -1)
            {
                Debug.Log("CurrentSlot = -1");
                return;
            }

            SaveData data = LoadSave(CurrentSlot);

            if (data == null)
            {
                Debug.Log("SaveData == null");
                return;
            }

            data.Objects.Clear();

            MonoBehaviour[] behaviours = FindObjectsByType<MonoBehaviour>(
                FindObjectsInactive.Include,
                FindObjectsSortMode.None);

            Debug.Log("Всего MonoBehaviour: " + behaviours.Length);

            foreach (MonoBehaviour behaviour in behaviours)
            {
                Debug.Log("Найден: " + behaviour.GetType().Name);

                if (behaviour is ISaveable saveable)
                {
                    Debug.Log("ISaveable: " + behaviour.name);

                    data.Objects.Add(new ObjectState
                    {
                        Id = saveable.GetId(),
                        State = saveable.CaptureState()
                    });
                }
            }

            Debug.Log("Сохранено объектов: " + data.Objects.Count);

            Save(data);
        }

        public void LoadWorld()
        {
            if (CurrentSlot == -1)
                return;

            SaveData data = LoadSave(CurrentSlot);

            if (data == null)
                return;

            MonoBehaviour[] behaviours = FindObjectsByType<MonoBehaviour>(
                FindObjectsInactive.Include,
                FindObjectsSortMode.None);

            foreach (MonoBehaviour behaviour in behaviours)
            {
                if (behaviour is ISaveable saveable)
                {
                    ObjectState state =
                        data.Objects.FirstOrDefault(x => x.Id == saveable.GetId());

                    if (state != null)
                        saveable.RestoreState(state.State);
                }
            }

            Debug.Log($"Загружено объектов: {data.Objects.Count}");
        }
    }
}