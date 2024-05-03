using Financial.Queue.Models.Request;
using Financial.Queue.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace Financial.Producer.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MessageController : ControllerBase
    {
        private readonly IRabbitMessageService _rabbitMessageService;
        public MessageController(IRabbitMessageService rabbitMessageService)
        {
            _rabbitMessageService = rabbitMessageService;
        }


        /// <summary>
        /// Envia uma mensagem para a fila especificada.
        /// </summary>
        /// <param name="request">Objeto que contém a mensagem e o nome da fila.</param>
        /// <returns>Retorna uma resposta indicando sucesso ou falha na operação.</returns>
        /// <response code="200">Mensagem enviada com sucesso.</response>
        /// <response code="400">Dados inválidos fornecidos.</response>
        [HttpPost]
        [SwaggerOperation(Summary = "Envia uma mensagem para a fila especificada.", Description = "Requer um objeto com a mensagem e o nome da fila.")]
        [SwaggerResponse(200, "Mensagem enviada com sucesso.")]
        [SwaggerResponse(400, "Dados inválidos fornecidos.")]
        public async Task<IActionResult> Post([FromBody] MessageRequest request)
        {
            if (string.IsNullOrEmpty(request.QueueName))
            {
                return BadRequest("O nome da fila é necessário.");
            }

            await _rabbitMessageService.SendMessageAsync(request.Message, request.QueueName);
            return Ok();
        }
    }
}
