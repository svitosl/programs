using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace StrategyTemplateMethodApp
{
    abstract class Sorting
    {
        List<int> list = new List<int>();

        public void Sort(ISortStrategy strategy)
        {
            list = ReadData();
            if (list != null)
            {
                SortExecute(strategy);
                PrintData(list);
            }
            else
                Console.WriteLine("Cannot read data\n");
        }

        public abstract List<int> ReadData();
        public abstract void PrintData(List<int> list);
        public virtual void SortExecute(ISortStrategy strategy)
        {
            strategy.Execute(list);
        }
    }

    class ConsoleSourceSorting : Sorting
    {
        public override List<int> ReadData()
        {
            Console.Write("Input Data: ");
            string input = Console.ReadLine();
            if (input.Length > 0)
                return new List<int>(Array.ConvertAll(input.Split(' '), int.Parse));
            else
                return null;
        }

        public override void PrintData(List<int> list)
        {
            Console.Write("After sorting: ");
            foreach (var value in list)
                Console.Write(value + " ");
            Console.WriteLine('\n');
        }
    }

    class FileSourceSorting : Sorting
    {
        public override List<int> ReadData()
        {
            Console.WriteLine("Read data from file values.txt");
            string filename = "values.txt";

            string path = Path.Combine(Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location), filename);
            if (File.Exists(path))
            {
                string input = File.ReadAllText(path);
                return new List<int>(Array.ConvertAll(input.Split(' '), int.Parse));
            }

            else
                Console.WriteLine("\nFile doesn't exist");

            return null;
            
        }

        public override void PrintData(List<int> list)
        {
            Console.Write("Input filename to save result: ");
            string filename = Console.ReadLine();
            File.WriteAllLines(filename, list.Select(i => i.ToString()).ToArray());
        }
    }
}
