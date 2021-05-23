using EstudoProject.Entities;
using System;
using System.Globalization;
using System.IO;

namespace EstudoProject
{
    class Program
    {
        static void Main(string[] args)
        {


            Console.Write("Enter file full path: ");
            string sourceFilePath = Console.ReadLine();



            try
            {
                string[] lines = File.ReadAllLines(sourceFilePath);

                string sourceFolderPath = Path.GetDirectoryName(sourceFilePath);
                string targetFolderPath = sourceFolderPath + @"\out";
                string targetFilePath = targetFolderPath + @"\summary.csv";

                Directory.CreateDirectory(targetFolderPath);

                using (StreamWriter sw = File.AppendText(targetFilePath))
                {
                    foreach (string line in lines)
                    {
                        string[] list = line.Split(";");
                        string name = list[0];
                        double price = double.Parse(list[1], CultureInfo.InvariantCulture);
                        int value = Convert.ToInt32(list[2]);

                        Product product = new Product(name, price, value);
                        sw.WriteLine(product.Name + ";" + product.Total().ToString("F2", CultureInfo.InvariantCulture));
                    }
                }
            }
            catch (IOException e)
            {
                Console.WriteLine("An error occurred");
                Console.WriteLine(e.Message);
                throw;
            }
        }
    }
}
