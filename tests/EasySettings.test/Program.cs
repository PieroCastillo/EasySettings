using System;

namespace EasySettings.test
{
    class Program
    {
        public static SettingsManager ProgramSettings { get; set; }
        static void Main(string[] args)
        {
            ProgramSettings = new SettingsManager("config.xml");
            ProgramSettings.Load();
            
        }
    }
}
