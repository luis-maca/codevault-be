using CodeVault.API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Linq;

namespace CodeVault.API.Controllers
{
    [ApiController]
    [Route("api/snippets")]
    public class SnippetController : ControllerBase
    {
        private readonly Supabase.Client _supabaseClient;
        private readonly ILogger<SnippetController> _logger;

        public SnippetController(Supabase.Client supabaseClient, ILogger<SnippetController> logger)
        {
            _supabaseClient = supabaseClient;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> GetSnippets()
        {
            try
            {
                var response = await _supabaseClient
                    .From<SnippetDto>()
                    .Get();

                if (response.Models == null || response.Models.Count == 0)
                {
                    return NotFound("No se encontraron snippets.");
                }

                var output = response.Models.Select(s => new ResponseSnippetDto
                {
                    Id = s.Id,
                    Title = s.Title,
                    Code = s.Code
                }).ToList();

                return Ok(output);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al obtener snippets.");
                return Problem("Ocurrió un error al obtener los snippets.", statusCode: 500);
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateSnippet([FromBody] CreateSnippetDto createDto)
        {
            try
            {
                if (createDto == null)
                    return BadRequest("Datos inválidos.");

                var snippet = new SnippetDto
                {
                    Title = createDto.Title,
                    Code = createDto.Code
                };

                var response = await _supabaseClient
                    .From<SnippetDto>()
                    .Insert(snippet);

                if (response.Models == null || response.Models.Count == 0)
                {
                    return Problem("Error al crear el snippet.", statusCode: 500);
                }

                var created = response.Models[0];
                var output = new ResponseSnippetDto
                {
                    Id = created.Id,
                    Title = created.Title,
                    Code = created.Code
                };

                return CreatedAtAction(nameof(GetSnippets), new { id = output.Id }, output);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al crear snippet.");
                return Problem("Ocurrió un error al crear el snippet.", statusCode: 500);
            }
        }
    }
}