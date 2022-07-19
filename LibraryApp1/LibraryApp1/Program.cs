using Domain.Models;
using LibraryApp1.Controllers;
using Service.Services;
using Service.Services.Helpers;
using System;

namespace LibraryApp1
{
    public class Program
    {
        static void Main(string[] args)
        {
            LibraryService libraryService = new LibraryService();
            LibraryController libraryController = new LibraryController();
            BookController bookController = new BookController();

            GetMenues();

            while (true)
            {
            SelectOption: string selectOption = Console.ReadLine();

                int selectTrueOption;

                bool isSelectOption = int.TryParse(selectOption, out selectTrueOption);

                if (isSelectOption)
                {
                    switch (selectTrueOption)
                    {
                        case (int)Menues.CreateLibrary:
                            libraryController.Create();
                            break;

                        case (int)Menues.GetLibraryById:
                            libraryController.GetById();
                            break;

                        case (int)Menues.UpdateLibrary:
                            libraryController.Update();
                            break;

                        case (int)Menues.DeleteLibrary:
                            libraryController.Delete();
                            break;

                        case (int)Menues.GetAllLibraries:
                            libraryController.GetAll();
                            break;

                        case (int)Menues.SearchLibrary:
                            libraryController.Search();
                            break;

                        case (int)Menues.CreateBook:
                            bookController.Create();
                            break;

                        default:
                            Helper.WriteConsole(ConsoleColor.Red, "Select correct option number");
                            break;
                    }
                }
                else
                {
                    Helper.WriteConsole(ConsoleColor.Red, "Select correct option");
                    goto SelectOption;
                }
            }
        }

        private static void GetMenues()
        {
            Helper.WriteConsole(ConsoleColor.White, "Select one option : ");
            Helper.WriteConsole(ConsoleColor.Yellow, "1 - Create library, 2 - Get library by id, 3 - Update library, 4 - Delete library, 5 - Get all libraries, 6 - Search for library by name, 7 - Create book");
        }
    }
}
