using Rivers_Dams_Bulgaria.Controllers;
using Rivers_Dams_Bulgaria.Data;
using Rivers_Dams_Bulgaria.Data.Models;

namespace Rivers_Dams_Bulgaria.View;

public static class RiverView
{
    public static River Dunav { get; } = new River
    {
        RiverId = 1,
        Name = "Dunav",
        Length = 2857,
        SourceLocation = "Germany",
        MouthLocation = "Black sea"
    };

    public static void RunCrudDemo(MyContext context)
    {
        context.Database.EnsureCreated();

        var controller = new RiverController(context);
        var sampleRiver = Dunav;

        Console.WriteLine("=== Startup River CRUD Demo ===");

        Console.WriteLine("Create: adding River DUNAV to database...");
        var riverToAdd = new River
        {
            Name = sampleRiver.Name,
            Length = sampleRiver.Length,
            SourceLocation = sampleRiver.SourceLocation,
            MouthLocation = sampleRiver.MouthLocation
        };
        controller.Add(riverToAdd);
        Console.WriteLine($"Created River with generated id {riverToAdd.RiverId}");

        Console.WriteLine($"Read: retrieving River by id {riverToAdd.RiverId}...");
        var loadedRiver = controller.GetById(riverToAdd.RiverId);
        if (loadedRiver is null)
        {
            Console.WriteLine("Failed to read the newly created River.");
            Console.WriteLine("=== End River CRUD Demo ===");
            return;
        }

        Console.WriteLine($"Loaded River: {loadedRiver.Name}, {loadedRiver.Length} km, from {loadedRiver.SourceLocation} to {loadedRiver.MouthLocation}");

        Console.WriteLine("Update: modifying Length and SourceLocation...");
        loadedRiver.Length = 2860;
        loadedRiver.SourceLocation = "Danube source";
        controller.Update(loadedRiver);

        var updatedRiver = controller.GetById(loadedRiver.RiverId);
        if (updatedRiver is null)
        {
            Console.WriteLine("Failed to read River after update.");
            Console.WriteLine("=== End River CRUD Demo ===");
            return;
        }

        Console.WriteLine($"Updated River: {updatedRiver.Name}, {updatedRiver.Length} km, from {updatedRiver.SourceLocation} to {updatedRiver.MouthLocation}");

        Console.WriteLine($"Delete: removing River id {updatedRiver.RiverId}...");
        controller.Delete(updatedRiver.RiverId);

        var deletedRiver = controller.GetById(updatedRiver.RiverId);
        Console.WriteLine(deletedRiver is null ? "Delete verified: river removed." : "Delete failed: river still exists.");
        Console.WriteLine("=== End River CRUD Demo ===");
    }
}
