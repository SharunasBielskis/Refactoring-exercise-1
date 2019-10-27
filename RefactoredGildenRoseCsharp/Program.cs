using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RefactoredGildenRoseCsharp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("OMGHAI!");

            #region Ask ask a user for a selection

            Console.SetWindowSize(Console.WindowWidth, Console.LargestWindowHeight);

            Console.WriteLine("Press y and then Enter key - ");
            Console.WriteLine("to form the report.");
            Console.WriteLine();
            Console.WriteLine("Press n and then Enter key - ");
            Console.WriteLine("to exit the program.");
            Console.WriteLine();
            string userSelectionSymbol = Console.ReadLine();

            #endregion Ask ask a user for a selection

            switch (userSelectionSymbol)
            {
                case "y":
                    ExecuteProgramMethods();//This separate public method will be used for Unit tests
                    break;
                case "n":
                    //Do nothing, the program will end without report formation
                    break;
                default:
                    #region Message to user about incorrect input
                    Console.WriteLine("Error No xxx:");
                    Console.WriteLine("You entered incorrect symbol - " + userSelectionSymbol);
                    Console.WriteLine("The program will end now.");
                    Console.WriteLine("Restart the program and then enter one of the correct symbols.");
                    Console.WriteLine();
                    #endregion
                    break;
            }

            #region Inform user about the end of the program 
            Console.WriteLine();
            Console.WriteLine("The end of the program.");
            Console.WriteLine("Press any key to exit the console window.");
            Console.ReadKey();
            #endregion


        }

        public static void ExecuteProgramMethods()
        {
            #region items collection initialization

            //Code is more readable when the code block devoted to one purpose is in the Visual Studio region.
            //It allows a developer to collapse region and focus on the other codes blocks which are more 
            //actual at some moment during code creation and edition.

            //According to C# naming convention,
            // https://github.com/ktaranov/naming-convention/blob/master/C%23%20Coding%20Standards%20and%20Naming%20Conventions.md
            //local variables notation is camelCase.
            //It is the reason why I changed Items name to items
            IList<Item> items = new List<Item>
                    {
                        new Item {Name = "+5 Dexterity Vest", SellIn = 10, Quality = 20},
                        new Item {Name = "Aged Brie", SellIn = 2, Quality = 0},
                        new Item {Name = "Elixir of the Mongoose", SellIn = 5, Quality = 7},
                        new Item {Name = "Sulfuras, Hand of Ragnaros", SellIn = 0, Quality = 80},
                        new Item {Name = "Sulfuras, Hand of Ragnaros", SellIn = -1, Quality = 80},
                        new Item
                        {
                            Name = "Backstage passes to a TAFKAL80ETC concert",
                            SellIn = 15,
                            Quality = 20
                        },
                        new Item
                        {
                            Name = "Backstage passes to a TAFKAL80ETC concert",
                            SellIn = 10,
                            Quality = 49
                        },
                        new Item
                        {
                            Name = "Backstage passes to a TAFKAL80ETC concert",
                            SellIn = 5,
                            Quality = 49
                        },
				        // this conjured item does not work properly yet
				        new Item {Name = "Conjured Mana Cake", SellIn = 3, Quality = 6}
                    };

            #endregion items collection initialization

            #region gildenRose instance initialization

            //When the created class instance will be used not in the adjacent code and it is easily possible to detect its 
            //exact type I do not use var keyword. Only in case when class name is very long var keyword can help do code
            //more readable
            //I prefer meaningful variable names, so app is renamed to  gildenRose as C# is case sensitive language and 
            //promotes initialized classes instances to name as a class name but with camelCases instead class name in PascalCases.
            GildenRose gildenRose = new GildenRose(items);

            #endregion gildenRose instance initialization

            #region Form report of goods quality change during 30 days period 

            //The method is refactored into a separate public method - public because it allows easier to create Unit Test
            FormReport(items, gildenRose);

            #endregion Form report of goods quality change during 30 days period
        }

        private static void FormReport(IList<Item> items, GildenRose gildenRose)
        {
            #region String builder for report data text accunulation initialization
            string reportHeader = "Gilden Rose goods quality change report for 30 days" + "\r\n" + "\r\n";
            //string builder class is more effective to accumulate text than string class, because string is unmutable array of chars
            //and in most cases more effective to accumulate data in it than read line by line directly into a file
            //For sting builder initialization is used constructor which accepts string and initial capasity in char
            //As aftertesting was detected that formed stringBuilder capasity was 16192 after this test initial capasity set to 16500
            StringBuilder stringBuilder = new StringBuilder(reportHeader, 16500); 
            #endregion

            #region Gilden Rose goods quality change for the next 30 days text data accumulation in stringBuilder
            //In the cases when are nested for loops I use meaningful index names.
            //i is changed to dayIndex, j to itemIndex
            for (var dayIndex = 0; dayIndex < 31; dayIndex++)
            {
                //In the commented code lines below are old code version
                //Console.WriteLine("-------- day " + dayIndex + " --------");
                //Console.WriteLine("name, sellIn, quality");
                stringBuilder.Append("-------- day " + dayIndex + " --------" + "\r\n");
                stringBuilder.Append("name, sellIn, quality" + "\r\n");
                for (var itemIndex = 0; itemIndex < items.Count; itemIndex++)
                {
                    //In the commented code lines below are old code version
                    //System.Console.WriteLine(items[itemIndex]);
                    stringBuilder.Append(items[itemIndex] + "\r\n");
                }
                //In the commented code lines below are old code version
                //Console.WriteLine("");
                stringBuilder.Append("\r\n");
                gildenRose.UpdateQuality();
            }
            #endregion Gilden Rose goods quality change for the next 30 days text data accumulation in stringBuilder

            #region Path for report file formation and write accumulated text into report file
            string pathToDirectory = AppDomain.CurrentDomain.BaseDirectory;
            string reportFileName = "Report.txt";
            string pathToreportFile = Path.Combine(pathToDirectory, reportFileName);
            using (StreamWriter sw = new StreamWriter(pathToreportFile, false, Encoding.UTF8))
            {
                sw.WriteLine(stringBuilder.ToString());
            }
            #endregion


        }
    }
}
