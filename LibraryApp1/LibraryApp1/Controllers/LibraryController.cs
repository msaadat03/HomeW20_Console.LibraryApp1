using Domain.Models;
using Service.Services;
using Service.Services.Helpers;
using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryApp1.Controllers
{
    public class LibraryController
    {
            LibraryService libraryService = new LibraryService();
            public void Create()
            {
                Helper.WriteConsole(ConsoleColor.Blue, "Add library name : ");

                string libraryname = Console.ReadLine();

                Helper.WriteConsole(ConsoleColor.Blue, "Add library seat count : ");

            SeatCount: string librarySeatCount = Console.ReadLine();
                int seatCount;
                bool isSeatCount = int.TryParse(librarySeatCount, out seatCount);

                if (isSeatCount)
                {
                    Library library = new Library
                    {
                        Name = libraryname,
                        SeatCount = seatCount
                    };

                    var result = libraryService.Create(library);
                    Helper.WriteConsole(ConsoleColor.Green, $"Library Id : {result.Id}, Name : {result.Name}, Seat count : {result.SeatCount}");
                }
                else
                {
                    Helper.WriteConsole(ConsoleColor.Red, "Add correct seat count : ");
                    goto SeatCount;
                }
            }
            public void GetById()
            {
                Helper.WriteConsole(ConsoleColor.Blue, "Add library id : ");
            LibraryId: string libraryId = Console.ReadLine();

                int id;
                bool isLibraryId = int.TryParse(libraryId, out id);

                if (isLibraryId)
                {
                    Library library = libraryService.GetById(id);

                    if (library != null)
                    {
                        Helper.WriteConsole(ConsoleColor.Green, $"Library Id : {library.Id}, Name : {library.Name}, Seat count : {library.SeatCount}");
                    }
                    else
                    {
                        Helper.WriteConsole(ConsoleColor.Red, "Library not found");
                        goto LibraryId;
                    }
                }
                else
                {
                    Helper.WriteConsole(ConsoleColor.Red, "Add correct id type : ");
                    goto LibraryId;
                }
            }
            public void GetAll()
            {
                List<Library> libraries = libraryService.GetAll();

                foreach (var item in libraries)
                {
                    Helper.WriteConsole(ConsoleColor.Green, $"Library Id : {item.Id}, Name : {item.Name}, Seat count : {item.SeatCount}");
                }
            }
            public void Search()
            {
                Helper.WriteConsole(ConsoleColor.Blue, "Add library search text : ");

            SearchText: string search = Console.ReadLine();

                List<Library> resultlibraries = libraryService.Search(search);

                if (resultlibraries.Count != 0)
                {
                    foreach (var item in resultlibraries)
                    {
                        Helper.WriteConsole(ConsoleColor.Green, $"Library Id : {item.Id}, Name : {item.Name}, Seat count : {item.SeatCount}");
                    }
                }
                else
                {
                    Helper.WriteConsole(ConsoleColor.Red, "Library not found");
                    goto SearchText;
                }
            }
            public void Delete()
            {
                Helper.WriteConsole(ConsoleColor.Blue, "Add library id : ");
            LibraryId: string libraryId = Console.ReadLine();

                int id;
                bool isLibraryId = int.TryParse(libraryId, out id);

                if (isLibraryId)
                {
                    libraryService.Delete(id);
                }
                else
                {
                    Helper.WriteConsole(ConsoleColor.Red, "Select correct id type : ");
                    goto LibraryId;
                }
            }
            public void Update()
            {
                Helper.WriteConsole(ConsoleColor.Blue, "Add library id : ");

            LibraryId: string updateLibraryId = Console.ReadLine();
                int libraryId;
                bool isLibraryId = int.TryParse(updateLibraryId, out libraryId);

                if (isLibraryId)
                {
                    Helper.WriteConsole(ConsoleColor.Blue, "Add library new name : ");

                    string libraryNewName = Console.ReadLine();

                    Helper.WriteConsole(ConsoleColor.Blue, "Add library new seat count : ");

                SeatCount: string libraryNewSeatCount = Console.ReadLine();
                    int seatCount;
                    bool isSeatCount = int.TryParse(libraryNewSeatCount, out seatCount);

                    if (isSeatCount || libraryNewSeatCount == "")
                    {
                        bool isSeatCountEmpty = string.IsNullOrEmpty(libraryNewSeatCount);
                        int? count = null;

                        if (isSeatCount)
                        {
                            count = null;
                        }
                        else
                        {
                            count = seatCount;
                        }

                        Library library = new Library()
                        {
                            Name = libraryNewName,
                            SeatCount = count
                        };

                        var resultLibrary = libraryService.Update(libraryId, library);

                        if (resultLibrary == null)
                        {
                            Helper.WriteConsole(ConsoleColor.Red, "Library not found, please try again : ");
                            goto LibraryId;
                        }
                        else
                        {
                            Helper.WriteConsole(ConsoleColor.Green, $"Library Id : {resultLibrary.Id}, Name : {resultLibrary.Name}, Seat count : {resultLibrary.SeatCount}");
                        }
                    }
                    else
                    {
                        Helper.WriteConsole(ConsoleColor.Red, "Add correct seat count : ");
                        goto SeatCount;
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

       