
using System.Text.Json;

namespace CHMR_DMP_PPR_Charlie_Docker.Helpers
{
    public sealed class JsonFileIO
    {
        public static bool SaveJson<T>(T obj, string fileName)
        {
            bool success = true;

            try
            {
                string jsonString = JsonSerializer.Serialize<T>(obj);
                File.WriteAllText(fileName, jsonString);
            }
            catch (Exception ex)
            {
                success = false;
            }

            return success;
        }

        public static T LoadJson<T>(string fileName)
        {
            T? obj = default(T);

            try
            {
                string jsonString = File.ReadAllText(fileName);
                obj = JsonSerializer.Deserialize<T>(jsonString);
            }
            catch (Exception ex)
            {
                obj = default(T);
            }

            return obj;
        }
    }
}
