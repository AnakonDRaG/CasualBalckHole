using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

namespace CasualHole.Data
{
    [Serializable]
    public class SavableValue<T>
    {
        private T _value;

        public SavableValue(string playerPrefsPath, T defaultValue = default(T))
        {
            if (string.IsNullOrEmpty(playerPrefsPath))
                throw new Exception("The path to player preferences is null or empty");

            _playerPreferencesPath = playerPrefsPath;

            Value = defaultValue;
            DefaultValue = defaultValue;

            LoadFromPrefs();
        }

        private readonly string _playerPreferencesPath;

        public T Value
        {
            get => _value;
            set
            {
                _value = value;
                SaveValuesToPreferences();
                OnChange?.Invoke(_value);
            }
        }

        public T DefaultValue { get; }

        public Action<T> OnChange { get; set; }


        public void RollbackToDefaultValue()
        {
            Value = DefaultValue;
            SaveValuesToPreferences();
        }


        public void SaveValuesToPreferences()
        {
            using var memoryStream = new MemoryStream();
            var binaryFormatter = new BinaryFormatter();
            binaryFormatter.Serialize(memoryStream, Value);
            var stringToSave = Convert.ToBase64String(memoryStream.ToArray());

            PlayerPrefs.SetString(_playerPreferencesPath, stringToSave);
        }

        private void LoadFromPrefs()
        {
            if (!PlayerPrefs.HasKey(_playerPreferencesPath))
            {
                SaveValuesToPreferences();
                return;
            }

            var stringToDeserialize = PlayerPrefs.GetString(_playerPreferencesPath);
            var bytes = Convert.FromBase64String(stringToDeserialize);

            using var memoryStream = new MemoryStream(bytes);

            var binaryFormatter = new BinaryFormatter();
            Value = (T) binaryFormatter.Deserialize(memoryStream);
        }
    }
}