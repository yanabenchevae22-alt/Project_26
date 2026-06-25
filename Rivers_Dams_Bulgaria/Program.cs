using Microsoft.EntityFrameworkCore;
using Rivers_Dams_Bulgaria.Data;
using Rivers_Dams_Bulgaria.View;

var options = new DbContextOptionsBuilder<MyContext>()
    .UseSqlite(Configuration.ConnectionString)
    .Options;

using var context = new MyContext(options);
context.Database.EnsureCreated();

while (true)
{
    Display.ShowMainMenu(context);

    var choice = Console.ReadLine();

    switch (choice)
    {
        case "1":
            Display.ShowCreateMenu(context);
            break;
        case "2":
            Display.ShowReadMenu(context);
            break;
        case "3":
            Display.ShowUpdateMenu(context);
            break;
        case "4":
            Display.ShowDeleteMenu(context);
            break;
        case "0":
            Console.WriteLine("Goodbye!");
            return;
        default:
            Console.WriteLine("Invalid option. Please try again.");
            break;
    }

    Console.WriteLine();
    Console.WriteLine("Press Enter to continue...");
    Console.ReadLine();
}
