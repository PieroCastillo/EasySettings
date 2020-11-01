using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;

namespace EasySettings
{
    public class Setting
    {
        public Setting(string ID)
        {
            this.ID = ID;
        }

        public string ID { get; protected set; }
    
        public object? Value { get; protected set; } = default(object);

        public object? GetValue()
        {
            return Value;
        }

        public void SetValue(object? value)
        {
            Value = value;
        }
    }

    public class Settings : Collection<Setting>
    {
        /// <summary>
        /// Check if there is a <see cref="Setting"/> with the same ID
        /// </summary>
        /// <param name="ID">The ID to search</param>
        /// <returns>True if there is a Setting with the same ID<, in another case, false/returns>
        public bool Check(string ID)
        {
            return this.Any(x => x.ID == ID);
        }
    } 
}
