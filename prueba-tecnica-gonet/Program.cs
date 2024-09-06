using data_access.repositories;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Hosting.Internal;
using RepoDb;

var builder = WebApplication.CreateBuilder(args);

var corsSpec = "todos";

// Add services to the container.
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: corsSpec, policy =>
    {
        policy.WithOrigins("*", "*")
        .AllowAnyMethod()
        .AllowAnyHeader()
        .AllowAnyOrigin();
    });
});

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddScoped<IEmpleadosRepository, EmpleadosRepository>();
builder.Services.AddScoped<IPuestosRepository, PuestosRepository>();
builder.Services.AddScoped<IEstadosRepository, EstadosRepository>();

builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

GlobalConfiguration.Setup().UseSqlServer();


app.UseHttpsRedirection();
app.UseStaticFiles(new StaticFileOptions
{
    FileProvider = new PhysicalFileProvider(Path.Combine(builder.Environment.ContentRootPath, "archivos")),
    RequestPath = "/archivos"
});
app.UseRouting();
app.UseCors(corsSpec);
app.UseAuthorization();

app.MapControllers();


app.Run();
