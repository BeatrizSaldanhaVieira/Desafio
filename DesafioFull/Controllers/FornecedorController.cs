using DesafioFull.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace DesafioFull.Controllers
{
    [ApiController]
    [Route("api/fornecedor")]
    public class FornecedorController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly CepService _cepService;

        public FornecedorController(AppDbContext context, CepService cepService)
        {
            _context = context;
            _cepService = cepService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll(string nome, string cpfCnpj)
        {
            var fornecedores = _context.Fornecedores.AsQueryable();

            // Filtrando por nome e CPF/CNPJ
            if (!string.IsNullOrEmpty(nome))
            {
                fornecedores = fornecedores.Where(f => f.Nome.Contains(nome));
            }
            if (!string.IsNullOrEmpty(cpfCnpj))
            {
                fornecedores = fornecedores.Where(f => f.CpfCnpj.Contains(cpfCnpj));
            }

            return Ok(await fornecedores.ToListAsync());
        }

        [HttpPost]
        public async Task<IActionResult> Create(Fornecedor fornecedor)
        {
            // Validação de CNPJ/CPF único
            bool cnpjCpfExistente = await _context.Fornecedores
                .AnyAsync(f => f.CpfCnpj == fornecedor.CpfCnpj);

            if (cnpjCpfExistente)
            {
                return BadRequest("CNPJ/CPF já cadastrado.");
            }

            var cepValido = await _cepService.ValidarCepAsync(fornecedor.CEP);
            if (!cepValido)
            {
                return BadRequest("CEP inválido.");
            }

            if (fornecedor.Tipo.Equals("Física")  && fornecedor.Empresa.Estado.Equals("PR"))
            {
                if (fornecedor.DataNascimento.HasValue && fornecedor.DataNascimento.Value.AddYears(18) > DateTime.Now)
                {
                    return BadRequest("Fornecedor pessoa física no Paraná deve ser maior de idade.");
                }
            }

            _context.Fornecedores.Add(fornecedor);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetAll), new { id = fornecedor.Id }, fornecedor);
        }
    }
}
