using AutoMapper;
using Api.Core;
using Repositorios.Base;
using Repositorios.Interfaces.Base;
using UnitOfWorks;
using UnitOfWorks.Interfaces;
using Repositorios;
using Repositorios.Interfaces;
using Servicos;
using Servicos.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<IMeusGastosContexto, MeusGastosContexto>();
builder.Services.AddScoped<IUsuarioServico, UsuarioServico>();
builder.Services.AddScoped<IUsuarioRepositorio, UsuarioRepositorio>();
builder.Services.AddDommelCustomizado();
builder.Services.AddControllers(options =>
{
    options.Filters.Add<ErroGenericoFilterAttribute>();
});

builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(builder =>
    {
        builder.AllowAnyOrigin()
               .AllowAnyMethod()
               .AllowAnyHeader();
    });
});


var mappingConfig = new MapperConfiguration(mc =>
{
    mc.AllowNullDestinationValues = true;
    mc.AllowNullCollections = true;
    mc.AddProfile(new MappingProfile());
});

var mapper = mappingConfig.CreateMapper();
builder.Services.AddSingleton(mapper);




var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors();
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();


public class MappingProfile : Profile
{
    public MappingProfile()
    {
       
    }
}
