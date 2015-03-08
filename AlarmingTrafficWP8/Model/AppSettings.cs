using System;
using System.Collections.Generic;
using System.IO.IsolatedStorage;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlarmingTrafficWP8.Model
{
    public class AppSettings
    {
        IsolatedStorageSettings settings;
        bool isDirty;
        public AppSettings()
        {
            //Get the settings for this application.
            settings = IsolatedStorageSettings.ApplicationSettings;
        }
 
        /// <summary>
        /// Update a setting value for our application. If the setting does not
        /// exist, then add the setting.
        /// </summary>
        /// <param name="Key">
        /// <param name="value">
        /// <returns></returns>
        public void AddOrUpdateValue(string Key, Object value)
        {
            if (settings.Contains(Key))
            {
                settings[Key] = value;
            }
            // Otherwise create the key.
            else
            {
                settings.Add(Key, value);
            }
            isDirty = true;
        }
 
        public bool ContainsKey(string key)
        {
            return settings.Contains(key);
        }

       
        /// <summary>
        /// Get the current value of the setting, or if it is not found, set the 
        /// setting to the default setting.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="Key">
        /// <param name="defaultValue">
        /// <returns></returns>
        public T GetValue<T>(string Key)
        {
            if (settings.Contains(Key))
            {
                return (T)settings[Key];
            }
            return default(T);
        }
 
        /// <summary>
        /// Save the settings to isolated storage.
        /// </summary>
        public void Save()
        {
            if (!isDirty)
                return;
            settings.Save();
            isDirty = false;
        }
    }
}
