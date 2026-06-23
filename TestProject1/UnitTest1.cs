using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using Rivers_Dams_Bulgaria.Controllers;
using Rivers_Dams_Bulgaria.Data;
using Rivers_Dams_Bulgaria.Data.Models;

namespace TestProject1;

public class Tests
{
    private static MyContext CreateInMemoryContext()
    {
        var connection = new SqliteConnection("Data Source=:memory:");
        connection.Open();

        var options = new DbContextOptionsBuilder<MyContext>()
            .UseSqlite(connection)
            .Options;

        var context = new MyContext(options);
        context.Database.EnsureCreated();

        return context;
    }

    [Test]
    public void AddRiver_InsertsRiverIntoDatabase()
    {
        using var context = CreateInMemoryContext();
        var controller = new RiverController(context);

        var river = new River
        {
            Name = "Dunav",
            Length = 2857,
            SourceLocation = "Germany",
            MouthLocation = "Black sea"
        };

        controller.Add(river);

        Assert.That(river.RiverId, Is.GreaterThan(0));
        var savedRiver = controller.GetById(river.RiverId);
        Assert.That(savedRiver, Is.Not.Null);
        Assert.That(savedRiver!.Name, Is.EqualTo("Dunav"));
        Assert.That(savedRiver.Length, Is.EqualTo(2857));
        Assert.That(savedRiver.SourceLocation, Is.EqualTo("Germany"));
        Assert.That(savedRiver.MouthLocation, Is.EqualTo("Black sea"));
    }

    [Test]
    public void UpdateRiver_ChangesExistingRiverValues()
    {
        using var context = CreateInMemoryContext();
        var controller = new RiverController(context);

        var river = new River
        {
            Name = "Dunav",
            Length = 2857,
            SourceLocation = "Germany",
            MouthLocation = "Black sea"
        };

        controller.Add(river);

        river.Length = 2860;
        river.SourceLocation = "Danube source";
        controller.Update(river);

        var updatedRiver = controller.GetById(river.RiverId);
        Assert.That(updatedRiver, Is.Not.Null);
        Assert.That(updatedRiver!.Length, Is.EqualTo(2860));
        Assert.That(updatedRiver.SourceLocation, Is.EqualTo("Danube source"));
    }

    [Test]
    public void DeleteRiver_RemovesRiverFromDatabase()
    {
        using var context = CreateInMemoryContext();
        var controller = new RiverController(context);

        var river = new River
        {
            Name = "Dunav",
            Length = 2857,
            SourceLocation = "Germany",
            MouthLocation = "Black sea"
        };

        controller.Add(river);
        controller.Delete(river.RiverId);

        var deletedRiver = controller.GetById(river.RiverId);
        Assert.That(deletedRiver, Is.Null);
        Assert.That(controller.GetAll(), Is.Empty);
    }

    [Test]
    public void GetAll_ReturnsAllAddedRivers()
    {
        using var context = CreateInMemoryContext();
        var controller = new RiverController(context);

        controller.Add(new River
        {
            Name = "Dunav",
            Length = 2857,
            SourceLocation = "Germany",
            MouthLocation = "Black sea"
        });

        controller.Add(new River
        {
            Name = "Maritza",
            Length = 480,
            SourceLocation = "Bulgaria",
            MouthLocation = "Aegean sea"
        });

        var rivers = controller.GetAll();
        Assert.That(rivers.Count, Is.EqualTo(2));
        Assert.That(rivers.Select(r => r.Name), Does.Contain("Dunav"));
        Assert.That(rivers.Select(r => r.Name), Does.Contain("Maritza"));
    }
}
