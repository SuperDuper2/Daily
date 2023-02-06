using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Daily
{
    internal class Program
    {
        static void Main(string[] args)
        {
            DiaryMenu.Page(0);
            Arrows();
        }

        public static void Arrows()
        {
            ConsoleKeyInfo arrow = Console.ReadKey();
            while (true)
            {

                switch (arrow.Key)
                {
                    case ConsoleKey.LeftArrow:
                        DiaryMenu.Menu(arrow);
                        break;
                    case ConsoleKey.RightArrow:
                        DiaryMenu.Menu(arrow);
                        break;
                    case ConsoleKey.UpArrow:
                        DiaryMenu.ChangePosition(arrow);
                        break;
                    case ConsoleKey.DownArrow:
                        DiaryMenu.ChangePosition(arrow);
                        break;
                }
                if (arrow.Key == ConsoleKey.Escape) Environment.Exit(0);
            }
        }
    }
}