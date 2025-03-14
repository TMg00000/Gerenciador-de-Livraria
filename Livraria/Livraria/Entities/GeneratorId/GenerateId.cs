using Livraria.Communication.Request;
using RandomDataGenerator.FieldOptions;
using RandomDataGenerator.Randomizers;
using System.Text.RegularExpressions;

namespace Livraria.Entities.GeneratorId;

public class GenerateId
{
    public string Generator()
    {
        string pattern = @"^[A-Z]{1}\d{1}[a-z]{2}\d{1}$";
        Regex regex = new Regex(pattern);

        var getId = RandomizerFactory.GetRandomizer(new FieldOptionsTextRegex { Pattern = pattern });
        var id = getId.Generate();

        return id;
    }
}
