namespace Api.Models.Global
{
    public class PaginacaoResponseModel
    {
        public long Total { get; set; }
        public long? TotalPaginas { get; set; }
        public long? PaginaCorrente { get; set; }
        public long? PaginaTamanho { get; set; }
    }
}
