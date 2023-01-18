using Task1.Infrastructure.DataValidators;

namespace Task1.Models
{
    public class GeorgianLanguageTextModel
    {
        [GeorgianOnly]
        public string Text { get; set; }
    }
}
