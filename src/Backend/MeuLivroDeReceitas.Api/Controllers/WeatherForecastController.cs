using MeuLivroDeReceitas.Application.UseCases.Usuario.Registrar;
using Microsoft.AspNetCore.Mvc;

namespace MeuLivroDeReceitas.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class WeatherForecastController : ControllerBase
{
    [HttpGet(Name = "GetWeatherForecast")]
    public async Task<IActionResult> Get()
    { 
        var mensagem = new RegistrarUsuarioUseCase();
        await mensagem.Executar(new Comunicacao.Requisicoes.RequisicaoRegistrarUsuarioJson
        {

        });
        return Ok(); 
    }  
}
