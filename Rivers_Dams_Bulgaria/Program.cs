using Microsoft.EntityFrameworkCore;
using Rivers_Dams_Bulgaria.Data;
using Rivers_Dams_Bulgaria.View;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<MyContext>(options =>
    options.UseSqlite(Configuration.ConnectionString));

var app = builder.Build();

app.MapGet("/", () => "Hello World!");

using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<MyContext>();
    RiverView.RunCrudDemo(context);
}

app.Run();
