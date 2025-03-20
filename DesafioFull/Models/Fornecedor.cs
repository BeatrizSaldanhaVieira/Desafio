namespace DesafioFull.Models
{
    public class Fornecedor
    {
        public int Id { get; set; }
        public string CnpjOuCPF { get; set; }
        public string Nome { get; set; }
        public string RG { get; set; }
        public string Email { get; set; }
        public DateTime? DataNascimento { get; set; }
        public string Tipo { get; set; }
        public string CEP { get; set; }
        public string Estado { get; set; }
        public string Empresa { get; set; }
 

    }
}
