using Livraria.Communication.Request;

namespace Livraria.Entities.books;

public class DictionaryOfBooks
{
    public Dictionary<string, object> Shelf { get; set; }

	public DictionaryOfBooks()
	{
		Shelf = new Dictionary<string, object>();
	}
}
