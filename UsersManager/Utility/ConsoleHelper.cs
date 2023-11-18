using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UsersManager.Models.Entities;

namespace UsersManager.Utility
{
    public static class ConsoleHelper
    {
        public static void PrintUserWithTags(User user, List<Tag> tags )
        {
            Console.WriteLine($"Name: {user.Name}");
            Console.WriteLine($"Domain: {user.Domain}");

            if (tags != null)
            {
                Console.WriteLine("Tags:");
                foreach (var item in tags)
                {
                    Console.Write($"{item.Value} ");
                }
            }
            else
            {
                Console.WriteLine("User has no tags");
            }
        }

        public static int GetPageSize()
        {
            Console.WriteLine("Print number of users per page or 0 for all");

            int pageSize;
            bool parsedSize = Int32.TryParse(Console.ReadLine(), out pageSize);
            if (!parsedSize) pageSize = 0;
            return pageSize;
        }

        public static int GetPageNumber()
        {
            Console.WriteLine("Print page number");

            int pageNumber;
            bool parsedNumber = Int32.TryParse(Console.ReadLine(), out pageNumber);
            if (!parsedNumber) pageNumber = 1;
            return pageNumber;
        }

    }
}
