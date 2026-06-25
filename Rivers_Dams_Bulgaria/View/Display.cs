using Rivers_Dams_Bulgaria.Controllers;
using Rivers_Dams_Bulgaria.Data;
using Rivers_Dams_Bulgaria.Data.Models;

namespace Rivers_Dams_Bulgaria.View;

public static class Display
{
    public static void ShowMainMenu(MyContext context)
    {
        Console.WriteLine("=== CRUD Console Menu ===");
        Console.WriteLine("1. Create");
        Console.WriteLine("2. Read");
        Console.WriteLine("3. Update");
        Console.WriteLine("4. Delete");
        Console.WriteLine("0. Exit");
        Console.Write("Choose an option: ");
    }

    public static void ShowCreateMenu(MyContext context)
    {
        Console.WriteLine("=== Create River ===");

        var controller = new RiverController(context);
        var river = new River();

        Console.Write("Enter river ID: ");
        if (int.TryParse(Console.ReadLine(), out var riverId))
        {
            river.RiverId = riverId;
        }
        else
        {
            Console.WriteLine("Invalid ID. Using 0.");
        }

        Console.Write("Enter river name: ");
        river.Name = Console.ReadLine() ?? string.Empty;

        Console.Write("Enter length (km): ");
        river.Length = double.Parse(Console.ReadLine() ?? "0");

        Console.Write("Enter source location: ");
        river.SourceLocation = Console.ReadLine() ?? string.Empty;

        Console.Write("Enter mouth location: ");
        river.MouthLocation = Console.ReadLine() ?? string.Empty;

        controller.Add(river);
        Console.WriteLine($"River created with ID {river.RiverId}.");
    }

    public static void ShowReadMenu(MyContext context)
    {
        Console.WriteLine("=== Rivers ===");

        var controller = new RiverController(context);
        var rivers = controller.GetAll();

        if (rivers.Count == 0)
        {
            Console.WriteLine("No rivers found.");
            return;
        }

        foreach (var river in rivers)
        {
            Console.WriteLine($"ID: {river.RiverId}, Name: {river.Name}, Length: {river.Length} km, Source: {river.SourceLocation}, Mouth: {river.MouthLocation}");
        }
    }

    public static void ShowUpdateMenu(MyContext context)
    {
        Console.WriteLine("=== Update River ===");

        var controller = new RiverController(context);
        Console.Write("Enter river ID to update: ");
        var id = int.Parse(Console.ReadLine() ?? "0");

        var river = controller.GetById(id);
        if (river is null)
        {
            Console.WriteLine("River not found.");
            return;
        }

        Console.Write($"New name [{river.Name}]: ");
        var name = Console.ReadLine();
        if (!string.IsNullOrWhiteSpace(name)) river.Name = name;

        Console.Write($"New length [{river.Length}]: ");
        var lengthInput = Console.ReadLine();
        if (!string.IsNullOrWhiteSpace(lengthInput) && double.TryParse(lengthInput, out var length))
        {
            river.Length = length;
        }

        Console.Write($"New source location [{river.SourceLocation}]: ");
        var source = Console.ReadLine();
        if (!string.IsNullOrWhiteSpace(source)) river.SourceLocation = source;

        Console.Write($"New mouth location [{river.MouthLocation}]: ");
        var mouth = Console.ReadLine();
        if (!string.IsNullOrWhiteSpace(mouth)) river.MouthLocation = mouth;

        controller.Update(river);
        Console.WriteLine("River updated.");
    }

    public static void ShowDeleteMenu(MyContext context)
    {
        Console.WriteLine("=== Delete River ===");

        var controller = new RiverController(context);
        Console.Write("Enter river ID to delete: ");
        var id = int.Parse(Console.ReadLine() ?? "0");

        var river = controller.GetById(id);
        if (river is null)
        {
            Console.WriteLine("River not found.");
            return;
        }

        controller.Delete(id);
        Console.WriteLine($"River '{river.Name}' deleted.");
    }
}
