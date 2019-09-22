using CsvHelper;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace itro1
{
    class FileManager
    {
        static public List<string[]> read(string file)
        {
            List<string []> str = new List<string[]>();
            using (var reader = new StreamReader(file, Encoding.GetEncoding(1251)))
            {
                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    var values = line.Split(';');

                    str.Add(values);
                }
            }

            return str;
        }

        static public void write(string name, List<List<string>> data)
        {
            using (var stream = new StreamWriter(name, false, Encoding.GetEncoding(1251)))
            {
                CsvWriter writer = new CsvWriter(stream);
                for (int i = 0; i < data.Count; i++)
                {
                    for (int y = 0; y < data[i].Count; y++)
                    {
                        writer.WriteField(data[i][y]);
                    }
                    writer.NextRecord();
                }
            }
        }
    }
}
