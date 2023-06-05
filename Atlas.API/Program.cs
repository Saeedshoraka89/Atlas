var builder = WebApplication.CreateBuilder(args);

Bootstrapper.Config(builder.Services, "Name=AtlasConnectionString");

var app = builder.Build();

app.UseHttpsRedirection();

app.MapProductCategoryRoute();

app.Run();
