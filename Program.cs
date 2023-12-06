using Microsoft.EntityFrameworkCore;
using ProyectoMvc.Models;

var builder = WebApplication.CreateBuilder(args);

// Agrega servicios al contenedor.
builder.Services.AddControllers();

// Configura la conexión a la base de datos.
builder.Services.AddDbContext<Alumnocontext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

/*builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
    {
        Version = "v1",
        Title = "My API",
        Description = "My ASP.NET Core Web API",
    });
});*/

var app = builder.Build();


 /*if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
    });
}*/


// app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthorization();

app.MapControllers();

/*app.UseSwagger();
app.UseSwaggerUI( c => {
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Cursos Online v1");
});*/

app.Run();