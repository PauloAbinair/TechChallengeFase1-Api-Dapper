using Contatos.API.Interfaces;
using Contatos.API.Repositories;
using Contatos.API.Services;
using Microsoft.Data.SqlClient;
using Microsoft.OpenApi.Models;
using System.Data;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

var configuration = new ConfigurationBuilder()
    .AddJsonFile("appsettings.json")
    .Build();

var stringConexao = configuration.GetValue<string>("ConnectionString");
builder.Services.AddScoped<IDbConnection>((conexao) => new SqlConnection(stringConexao));
builder.Services.AddScoped<IContatoRepository, ContatoRepository>();
builder.Services.AddScoped<IContatoService, ContatoService>();
builder.Services.AddScoped<IRegiaoRepository, RegiaoRepository>();
builder.Services.AddScoped<IRegiaoService, RegiaoService>();


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Fase 1 - Tech Challenge - API com Dapper" });
    var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
    c.IncludeXmlComments(xmlPath);
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.Use(async (context, next) =>
{
    // Definindo o tipo de conteúdo padrão para application/json
    context.Response.ContentType = "application/json";

    // Chamada para o próximo middleware na pipeline
    await next();
});

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
