using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class FileStreamer<T>
    {
        //JsonWriter jsonWriter = new JsonTextWriter(sw);
        private static readonly string filePath = AppDomain.CurrentDomain.BaseDirectory + "\\celebs.json";// System.IO.Directory.GetCurrentDirectory() + "\\celebs.json";// System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location) + "/celebs.json";// // System.IO.Path.GetFullPath("/DAL/celebs.json");
        public static bool SaveJsonObjectToFile(T type)
        {
            try
            {
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    var writer = new StreamWriter(stream);
                    var jsonStr = JsonConvert.SerializeObject(type);
                    writer.WriteLine(jsonStr);
                    writer.Close();
                }

                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }
        public static T GetJsonDataFromFile()
        { 
            using (var stream = new FileStream(filePath, FileMode.Open))
            {
                try
                {
                    var writer = new StreamReader(stream);
                    return JsonConvert.DeserializeObject<T>(writer.ReadToEnd());
                }
                catch (Exception)
                {
                    return default(T);
                }

            }
        }

    }
}
