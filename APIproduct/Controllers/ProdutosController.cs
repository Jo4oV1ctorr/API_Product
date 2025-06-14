// Dentro da pasta Controllers, crie ProdutosController.cs
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic; // Necessário para List
using System.Linq; // Necessário para FirstOrDefault

namespace FirstAPI.Controllers // Certifique-se de que o namespace corresponda ao seu projeto
{
    [ApiController]
    [Route("api/[controller]")] // Define que a rota para este controlador será /api/Produtos
    public class ProdutosController : ControllerBase
    {
        // Lista em memória para simular um "banco de dados" temporário
        private static List<string> _produtos = new List<string>
        {
            "Notebook", "Mouse", "Teclado", "Cadeira Gamer", "Monitor", 
        };

        // GET api/produtos
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            return Ok(_produtos); // Retorna a lista de produtos com status 200 OK
        }

        // POST api/produtos
        [HttpPost]
        public IActionResult Post([FromBody] string novoProduto)
        {
            if (string.IsNullOrEmpty(novoProduto))
            {
                return BadRequest("O nome do produto não pode ser vazio.");
            }
            _produtos.Add(novoProduto);
            return CreatedAtAction(nameof(Get), new { id = _produtos.IndexOf(novoProduto) }, novoProduto);
            // Isso é um exemplo simples. Em um cenário real, você retornaria o produto com um ID real.
        }
    }
}