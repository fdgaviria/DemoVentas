using Ventas.Aplicacion.Mapeo;
using Ventas.Aplicacion.Servicios;
using Ventas.Infraestructura.Repositorios;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

// Configuración de la cadena de conexión
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
if (string.IsNullOrEmpty(connectionString))
{
    throw new InvalidOperationException("La cadena de conexión 'DefaultConnection' no está configurada.");
}

// Inyección de dependencia Repositorios
builder.Services.AddScoped<IVentaRepository>(provider => new VentaRepository(connectionString));
builder.Services.AddScoped<IPuntoDeVentaRepository>(provider => new PuntoDeVentaRepository(connectionString)); 
builder.Services.AddScoped<IClienteRepository>(provider => new ClienteRepository(connectionString));

// Inyección de dependencia Servicios
builder.Services.AddScoped<IVentaService,VentaService>();
builder.Services.AddScoped<IPuntoDeVentaService, PuntoDeVentaService>();
builder.Services.AddScoped<IClienteService, ClienteService>();

// Configuración de AutoMapper utilizando el ensamblado para descubrir las clases de mapeo
builder.Services.AddAutoMapper(typeof(VentaProfile).Assembly); 

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
