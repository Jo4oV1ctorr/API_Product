using Microsoft.AspNetCore.Mvc;

namespace ChatbotApiSimples.Controllers
{
    [ApiController]
    [Route("[controller]")] // Define a rota base como /Chat
    public class ChatController : ControllerBase
    {
        [HttpPost] // Define que este método responde a requisições POST
        public IActionResult SendMessage([FromBody] MessageRequest request)
        {
            if (string.IsNullOrWhiteSpace(request.Message))
            {
                return BadRequest(new { response = "Por favor, envie uma mensagem válida." });
            }

            string userMessage = request.Message.ToLowerInvariant();
            string botResponse = "";

            // Lógica simples do chatbot
            if (userMessage.Contains("olá") || userMessage.Contains("oi"))
            {
                botResponse = "Olá! Como posso ajudar você?";
            }
            else if (userMessage.Contains("ajuda") || userMessage.Contains("suporte"))
            {
                botResponse = "Estou aqui para ajudar. Qual é a sua dúvida?";
            }
            else if (userMessage.Contains("horas") || userMessage.Contains("que horas são"))
            {
                botResponse = $"Agora são {DateTime.Now.ToShortTimeString()} no meu fuso horário.";
            }
            else if (userMessage.Contains("nome"))
            {
                botResponse = "Eu sou um chatbot simples, não tenho um nome.";
            }
            else if (userMessage.Contains("obrigado") || userMessage.Contains("valeu"))
            {
                botResponse = "De nada! Fico feliz em ajudar.";
            }
            else if (userMessage.Contains("sair") || userMessage.Contains("tchau"))
            {
                botResponse = "Até mais! Se precisar de algo, é só chamar.";
            }
            else
            {
                botResponse = "Desculpe, não entendi. Você pode reformular sua pergunta?";
            }

            return Ok(new { response = botResponse });
        }
    }

    // Classe para representar o corpo da requisição da mensagem
    public class MessageRequest
    {
        public string Message { get; set; }
    }
}