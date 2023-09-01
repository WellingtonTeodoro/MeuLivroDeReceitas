using MeuLivroDeReceitas.Domain.Extension;
using MeuLivroDeReceitas.Infrastructure.Migrations;
using MeuLivroDeReceitas.Infrastructure;
using Microsoft.OpenApi.Models;
using MeuLivroDeReceitas.Api.Filtros;

var builder = WebApplication.CreateBuilder(args); 

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddRepositorio(builder.Configuration);
builder.Services.AddControllers();
builder.Services.AddMvc(options => options.Filters.Add(typeof(FiltroDasExceptions)));

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen( c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Meu Livro de Receitas", Version = "v1" }); 
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

AtualizarBaseDeDados();

app.Run();

void AtualizarBaseDeDados() 
{
    var conexao = builder.Configuration.GetConexao();
    var nomeDatabase = builder.Configuration.GetNomeDatabase();
    Database.CriarDatabase(conexao, nomeDatabase);
    app.MigrateBancoDeDados();
}
