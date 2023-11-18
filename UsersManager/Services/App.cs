using UsersManager.Models.Entities;
using UsersManager.Services.Interfaces;
using UsersManager.Utility;

namespace UsersManager.Services
{
    public class App : IApp
    {
        private readonly IUserService _userService;
        public App(IUserService userService)
        {
            _userService = userService;
        }
        public void Run()
        {
            Console.WriteLine("UserManager");
            Console.WriteLine();
            Console.WriteLine("Choose action:");
            Console.WriteLine("1: Find user by Id & Domain");
            Console.WriteLine("2: Find users by Domain");
            Console.WriteLine("3: Find users by Tag & Domain");
            string action =  Console.ReadLine();

            switch (action)
            {

                case "1":
                    Console.WriteLine("Find user by Id & Domain");
                    Console.WriteLine("Enter user Id");
                    string userId = Console.ReadLine();
                    Console.WriteLine("Enter user Domain");
                    string userDomain = Console.ReadLine();

                    User? user = _userService
                        .GetUser(x => x.UserId.ToString() == userId && x.Domain == userDomain);

                    if (user == null)
                    {
                        Console.WriteLine("User not found");
                        break;
                    }

                    List<Tag?> tags = _userService.GetUserTags(userId);

                    Console.WriteLine();
                    ConsoleHelper.PrintUserWithTags(user, tags);


                    break;
                case "2":
                    Console.WriteLine("Find users by Domain");

                    Console.WriteLine("Enter users Domain");
                    string usersDomain = Console.ReadLine();

                    int pageSize = ConsoleHelper.GetPageSize();
                    int pageNumber = ConsoleHelper.GetPageNumber();

                    List<TagToUser?> users = _userService
                        .GetAllUsers(x => x.User.Domain == usersDomain,"User", pageSize, pageNumber);

                    if (users == null)
                    {
                        Console.WriteLine("Users not found");
                        break;
                    }

                    Console.WriteLine();
                    Console.WriteLine("Result:");
                    foreach (var item in users)
                    {
                        List<Tag?> itemTags = _userService.GetUserTags(item.UserId.ToString());

                        ConsoleHelper.PrintUserWithTags(item.User, itemTags);

                        Console.WriteLine();
                        Console.WriteLine();
                    }


                    break;
                case "3":
                    Console.WriteLine("Find users by Tag & Domain");
                    Console.WriteLine("Enter users tag");
                    string tag = Console.ReadLine();
                    Console.WriteLine("Enter users domain");
                    string domain = Console.ReadLine();

                    int itemsOnPage = ConsoleHelper.GetPageSize();
                    int pageCount = ConsoleHelper.GetPageNumber();

                    List<TagToUser?> usersByTag = _userService.GetAllUsers(x => x.Tag.Value == tag
                            && x.User.Domain == domain, "User,Tag", itemsOnPage, pageCount);
                    
                    if (usersByTag == null)
                    {
                        Console.WriteLine("Users not found");
                        break;
                    }

                    Console.WriteLine();
                    Console.WriteLine("Result:");
                    foreach (var item in usersByTag)
                    {
                        List<Tag?> itemTags = _userService.GetUserTags(item.UserId.ToString());

                        ConsoleHelper.PrintUserWithTags(item.User, itemTags);

                        Console.WriteLine();
                        Console.WriteLine();
                    }


                    break;
                default:
                    Console.WriteLine("Unknown command");
                    break;
            }

        }
    }
}
