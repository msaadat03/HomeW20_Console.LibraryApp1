using Domain.Models;
using Service.Services;
using Service.Services.Helpers;
using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryApp1.Controllers
{
    public class BookController
    {
        BookService bookService = new BookService();
        public void Create()
        {
            Helper.WriteConsole(ConsoleColor.Blue, "Add library id : ");

        LibraryId: string libraryid = Console.ReadLine();
            int selectedLibraryId;
            bool isSelectedId = int.TryParse(libraryid, out selectedLibraryId);

            if (isSelectedId)
            {
                Helper.WriteConsole(ConsoleColor.Blue, "Add book name : ");

                string bookName = Console.ReadLine();

                Helper.WriteConsole(ConsoleColor.Blue, "Add book author : ");

                string author = Console.ReadLine();

                Book book = new Book()
                {
                    Name = bookName,
                    Author = author
                };

                var result = bookService.Create(selectedLibraryId, book);

                if (result != null)
                {
                    Helper.WriteConsole(ConsoleColor.Green, $"Book Id : {result.Id}, Name : {result.Name}, Author : {result.Author}, Book library : {result.Library.Name}");
                }
                else
                {
                    Helper.WriteConsole(ConsoleColor.Red, "Library not found, please add correct library id : ");
                    goto LibraryId;
                }
            }
            else
            {
                Helper.WriteConsole(ConsoleColor.Red, "Add correct library id : ");
                goto LibraryId;
            }
        }
    }
}
