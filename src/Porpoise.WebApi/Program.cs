using Marten;
using Porpoise.WebApi.Interfaces;
using Porpoise.WebApi.Services;
using Serilog;
using Weasel.Postgresql;

var builder = WebApplication.CreateBuilder(args);

builder.Host.UseSerilog((ctx, lc) => lc
    .WriteTo.Console()
    // .WriteTo.Seq("https://localhost:5341", apiKey: "VMKx4eGQ5Y4fjnjuLU3G")
    .WriteTo.Seq("http://localhost:5341")
    );

// Add services to the container.
builder.Services.AddCors(options =>
  options.AddPolicy(name: "Default", policy =>
    policy.SetIsOriginAllowed(origin =>
      new Uri(origin).Host == "localhost")
        .AllowAnyHeader()
        .AllowAnyMethod()
        .AllowCredentials()
      )
    );

builder.Services.AddMarten(options =>
{
    options.Connection(builder.Configuration.GetConnectionString("db"));
    options.AutoCreateSchemaObjects = AutoCreate.All;
});

builder.Services.AddSingleton<IPersonRepository, PersonRepository>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseCors("Default");
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

await app.RunAsync();
