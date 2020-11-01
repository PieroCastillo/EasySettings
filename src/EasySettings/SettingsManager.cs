using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using EasySettings.Exceptions;

namespace EasySettings
{
    public partial class SettingsManager
    {
        public SettingsManager(string PATH)
        {
            this.Path = PATH;
        }

        /// <summary>
        /// Finds a value
        /// </summary>
        /// <typeparam name="T">The type of value</typeparam>
        /// <param name="ID">The ID of the value</param>
        /// <returns>The requested value</returns>
        public T FindValue<T>(string ID) where T : class
        {
            return (Settings.Select(x => x.ID == ID) as Setting).Value as T;
        }

        public void SetSetting<T>(string ID, T value, bool overridevalue = true)
        {
            var ex = Settings.Check(ID);
            switch (ex)
            {
                case true:
                    if(overridevalue == true)
                    {
                        (this.Settings.Select(x => x.ID == ID) as Setting).SetValue(value);
                    }
                    break;
                case false:
                    this.RegisterNewSetting<T>(ID, value);
                    break;
            }
        }

        /// <summary>
        /// Register a new value
        /// </summary>
        /// <typeparam name="T">The type of value</typeparam>
        /// <param name="ID">The ID of the value</param>
        /// <param name="value">The value to set</param>
        public void RegisterNewSetting<T>(string ID, T value)
        {
            var c = Settings.Check(ID);
            switch (c)
            {
                case false: 
                    var set = new Setting(ID);
                    set.SetValue(value);
                    Settings.Add(set);
                    break;
                case true: 
                    throw new SettingException("A setting with the same ID already registred");
            }
       
        }

        #region Fields
        Settings Settings;
        string Path;
        #endregion
    }
}
