using System.Text.Json.Serialization;

namespace Livraria.Communication.Request;

public class RequestBooksJson
{
    [JsonIgnore]

    public string? Id { get; private set; }
    public string Title { get; set; }
    public string Author { get; set; }
    public string Genre { get; set; }
    public decimal Value { get; set; }
    public int Amount { get; set; }

    [JsonIgnore]
    public List<RequestBooksJson> listRequest { get; private set; }

    public RequestBooksJson()
    {
        listRequest = new List<RequestBooksJson>();
    }
}
