namespace Api.Models.Global
{
    public class ListaPaginadaModel<TModel>
    {
        public List<TModel> Dados { get; set; }
        public PaginacaoResponseModel Paginacao { get; set; }
    }
}
