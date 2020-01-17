using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StrategyTemplateMethodApp
{
    class Program
    {
        static void Main(string[] args)
        {
            ConsoleSourceSorting fromConsole = new ConsoleSourceSorting();
            fromConsole.Sort(new BubbleSortStrategy());

            FileSourceSorting fromFile = new FileSourceSorting();
            fromFile.Sort(new InsertionSortStrategy());

        }
    }
}