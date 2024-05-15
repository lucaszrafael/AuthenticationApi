namespace Api.Models.Global
{
    public class PaginacaoRequestModel
    {
        private int? _pagina = 1;
        public int? Pagina
        {
            get { return _pagina; }
            set
            {
                if (value <= 0)
                    value = 1;

                _pagina = value;
            }
        }

        private int? _tamanho = 10;
        public int? Tamanho
        {
            get { return _tamanho; }
            set
            {
                if (value > 100)
                    value = 100;
                else if (value <= 0)
                    value = 10;

                _tamanho = value;
            }
        }
    }
}
