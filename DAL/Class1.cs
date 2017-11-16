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
        private readonly string filePath = System.IO.Path.GetFullPath("Dtat/celebs.json");
        public bool WriteToFile(string str, T type)
        {
            try
            {
                using (var stream = new FileStream(filePath, FileMode.CreateNew))
                {
                    var writer = new StreamWriter(stream);
                    JsonSerializer serializer = new JsonSerializer();

                    serializer.Serialize(writer, type);
                    writer.WriteLine(str);
                }

                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }
        public string ReadFromFile()
        {
            var filePath = System.IO.Path.GetFullPath("Dtat/celebs.json");

            using (var stream = new FileStream(System.IO.Path.GetFullPath("Dtat/celebs.json"), FileMode.Open))
            {

                try
                {
                    var writer = new StreamReader(stream);
                    return writer.ReadToEnd();
                }
                catch (Exception)
                {
                    return string.Empty;
                }

            }
        }
        // responseObject.ObjectData = JsonConvert.DeserializeObject<T1>(result);
    }
}
