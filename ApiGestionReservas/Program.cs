using LogicaAccesoADatos;
using LogicaAccesoADatos.Repositorios;
using LogicaAccesoDatos;
using LogicaAplicacion.CasosDeUso.CUHorarioDisponible;
using LogicaAplicacion.CasosDeUso.CULogin;
using LogicaAplicacion.CasosDeUso.CUReserva;
using LogicaAplicacion.CasosDeUso.CUUsuario;
using LogicaAplicacion.ICasosDeUso.HorarioDisponible;
using LogicaAplicacion.ICasosDeUso.ICUReserva;
using LogicaAplicacion.ICasosDeUso.ICUReserva.LogicaAplicacion.ICasosDeUso.ICUReserva;
using LogicaAplicacion.ICasosDeUso.ICUUsuario;
using LogicaNegocio.IRepositorio;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddScoped<IRepositorioUsuario, RepositorioUsuario>();
builder.Services.AddScoped<IRepositorioReserva, RepositorioReserva>();
builder.Services.AddScoped<IRepositorioHorarioDisponible, RepositorioHorarioDisponible>();
builder.Services.AddScoped<IRepositorioServicio, RepositorioServicio>();
builder.Services.AddScoped<IRepositorioNegocio, RepositorioNegocio>();



builder.Services.AddScoped<ICURegistrarReserva, CURegistrarReserva>();
builder.Services.AddScoped<ICUAltaHorarioDisponible, CUAltaHorarioDisponible>();
builder .Services.AddScoped<ICUAltaUsuario, CUAltaUsuario>();
builder.Services.AddScoped<ICUListarHorariosPorDia, CUListarHorariosPorDia>();
builder.Services.AddScoped<ICUCancelarReserva, CUCancelarReserva>();
builder.Services.AddScoped<ICUConfirmarAsistencia, CUConfirmarAsistencia>();
builder.Services.AddScoped<ICUMarcarNoAsistio, CUMarcarNoAsistio>();
builder.Services.AddScoped<ICUListarReservasUsuario, CUListarReservasUsuario>();
builder.Services.AddScoped<ICUListarReservasPorHorario, CUListarReservasPorHorario>();
builder.Services.AddScoped<ICUListarHorarios, CUListarHorarios>();
builder.Services.AddScoped<ICUVerRankingAsistencias, CUVerRankingAsistencias>();
builder.Services.AddScoped<ICUBuscarHorarioPorId, CUBuscarHorarioPorId>();
builder.Services.AddScoped<ICUModificarHorario, CUModificarHorario>();
builder.Services.AddScoped<ICUBajaHorario, CUBajaHorario>();
builder.Services.AddScoped<ICUBuscarUsuarioPorId, CUBuscarUsuarioPorId>();
builder.Services.AddScoped<ICUListarUsuarios, CUListarUsuarios>();
builder.Services.AddScoped<ICUModificarUsuario, CUModificarUsuario>();
builder.Services.AddScoped<ICUBajaUsuario, CUBajaUsuario>();
builder.Services.AddScoped<ICULogin, CULogin>();


builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("DefaultConnection")
    ));

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
