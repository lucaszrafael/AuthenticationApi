namespace Api.Models.Global;

public class ExcecaoModel
{
    public ExcecaoModel()
    {
        Mensagens = new List<string>();
    }
    public List<string> Mensagens { get; set; }
}
