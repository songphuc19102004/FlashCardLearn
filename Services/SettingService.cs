using Repositories.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Services
{
    public static class SettingService
    {
        private const string SettingsFileName = "Config/settings.json";

        public static Settings LoadSettings()
        {
            string json = File.ReadAllText(SettingsFileName);
            string path = Path.GetDirectoryName(SettingsFileName);
            return JsonSerializer.Deserialize<Settings>(json);
        }

        public static void SaveSettings(Settings settings)
        {
            string json = JsonSerializer.Serialize(settings, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(SettingsFileName, json);
        }
    }
}
