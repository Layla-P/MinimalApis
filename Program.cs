var builder = WebApplication.CreateBuilder(args);

IConfiguration Configuration = new ConfigurationBuilder()
    .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
    .AddEnvironmentVariables()
    .AddUserSecrets<Program>()
    .AddCommandLine(args)
    .Build();
// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSingleton<WaffleCreationService>();
builder.Services
    .AddDbContext<WaffleDbContext>(options => options.UseSqlServer(config.GetConnectionString("DefaultSql")));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

using (var scope = app.Services.CreateScope())
{
    var waffleCreationService = scope.ServiceProvider.GetRequiredService<WaffleCreationService>();
    var response = await waffleCreationService.StartWaffleCreation();

    app.MapGet("/GetWaffleToppings", () => new { toppings = response.toppings, bases = response.bases });

    app.MapGet("/users", async (WaffleDbContext context) =>
    {
        context.Database.EnsureCreated();
        return await context.Users.Include(u => u.Orders).ToListAsync();
    });
}

app.Run();

