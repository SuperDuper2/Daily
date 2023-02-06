using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Daily
{
    internal class DiaryMenu
    {
        private static DateTime date = new DateTime(2022, 10, 1);

        public static List<string> note = new List<string>()
            { "Сходить в магазин", "Пойти к другу",};

        public static List<string> note2 = new List<string>()
            { "Сделать дома", "После шараги" };

        public static List<string> note3 = new List<string>()
            { "Дома", "съездить в чайна таун" };

        public static List<string> description = new List<string>()
            { "Купить картоху и капусту", "Почефирить", };

        public static List<string> description2 = new List<string>()
            { "Практику и отчет", "Съездить в драгхаус" };

        public static List<string> description3 = new List<string>()
            { "Поесть и поспать", "Заглянуть на маросейку" };
        private static int page;
        private static DateTime newDate = date;
        private static int position = 1;

        public static void Menu(ConsoleKeyInfo strelka)
        {
            while (true)
            {
                if (strelka.Key == ConsoleKey.LeftArrow)
                {
                    page--;
                    Page(page);
                }

                else if (strelka.Key == ConsoleKey.RightArrow)
                {
                    page++;
                    Page(page);
                }
                else if (strelka.Key == ConsoleKey.UpArrow)
                {
                    ChangePosition(strelka);
                }

                else if (strelka.Key == ConsoleKey.DownArrow)
                {
                    ChangePosition(strelka);
                }
                if (strelka.Key == ConsoleKey.LeftArrow || strelka.Key == ConsoleKey.RightArrow) Program.Arrows();

            }
        }

        public static void DateStart()
        {
            Console.WriteLine($"   Выбрана дата: {date}");
        }

        public static void Page(int page)
        {
            if (page == 0)
            {
                Console.Clear();
                DateStart();
                Console.WriteLine($"   1. {note[0]}");
                Console.WriteLine($"   2. {note[1]}");
            }
            else if (page == 1)
            {
                Console.Clear();
                Console.WriteLine($"   Выбрана дата: {newDate = date.AddDays(1)}");
                Console.WriteLine($"   1. {note2[0]}");
                Console.WriteLine($"   2. {note2[1]}");
            }
            else if (page == -1)
            {
                Console.Clear();
                Console.WriteLine($"   Выбрана дата: {newDate = date.AddDays(-1)}");
                Console.WriteLine($"   1. {note3[0]}");
                Console.WriteLine($"   2. {note3[1]}");
            }
        }

        public static void Description(List<string> descript, int n)
        {
            if (page == 0)
                Console.WriteLine($"----------------------------\nОписание: {description[n - 1]}");
            if (page == 1)
                Console.WriteLine($"----------------------------\nОписание: {description2[n - 1]}");
            if (page == -1)
                Console.WriteLine($"----------------------------\nОписание: {description3[n - 1]}");
        }

        public static void Notes(int page, int i)
        {
            Console.Clear();
            if (page == 0)
            {
                Console.WriteLine(note[i - 1]);
                Description(description, i);
                Console.WriteLine($"Дата: {date}");
            }
            else if (page == 1)
            {
                Console.WriteLine(note2[i - 1]);
                Description(description2, i);
                Console.WriteLine($"Дата: {newDate = date.AddDays(1)}");
            }
            else if (page == -1)
            {
                Console.WriteLine(note3[i - 1]);
                Description(description3, i);
                Console.WriteLine($"Дата: {newDate = date.AddDays(-1)}");
            }
        }

        public static void Enter(int i)
        {
            switch (page)
            {
                case 0:
                    if (i == 1)
                    {
                        Notes(page, i);
                    }
                    else if (i == 2)
                    {
                        Notes(page, i);
                    }

                    break;
                case 1:
                    if (i == 1)
                    {
                        Notes(page, i);
                    }
                    else if (i == 2)
                    {
                        Notes(page, i);
                    }
                    break;
                case -1:
                    if (i == 1)
                    {
                        Notes(page, i);
                    }
                    else if (i == 2)
                    {
                        Notes(page, i);
                    }
                    break;
            }
        }

        public static void ChangePosition(ConsoleKeyInfo strelka, int maxDown = 2, string empty = "\0\0")
        {
            int i = position;
            Console.SetCursorPosition(0, position);
            Console.Write("->");
            while (strelka.Key != ConsoleKey.Enter)
            {
                strelka = Console.ReadKey(true);
                switch (strelka.Key)
                {
                    case ConsoleKey.DownArrow:
                        if (i != maxDown + position - 1)
                        {
                            Console.SetCursorPosition(0, i);
                            Console.Write(empty);
                            Console.SetCursorPosition(0, ++i);
                            Console.Write("->");
                        }
                        break;
                    case ConsoleKey.UpArrow:
                        if (i != position)
                        {
                            Console.SetCursorPosition(0, i);
                            Console.Write(empty);
                            Console.SetCursorPosition(0, --i);
                            Console.Write("->");
                        }
                        break;
                    case ConsoleKey.RightArrow:
                        Menu(strelka);
                        break;
                    case ConsoleKey.LeftArrow:
                        Menu(strelka);
                        break;
                }
            }
            Enter(i);
        }
    }
}