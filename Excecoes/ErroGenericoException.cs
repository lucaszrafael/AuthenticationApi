namespace Servicos.Exceptions;

public class ErroGenericoException : Exception
{
    public List<string> MensagensErro { get; }
    public int StatusCode { get; }

    public ErroGenericoException(List<string> mensagensErro, int statusCode) : base("")
    {
        MensagensErro = mensagensErro;
        StatusCode = statusCode;
    }
}
