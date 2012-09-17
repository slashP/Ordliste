using System.Linq;

namespace WordExists.Controllers
{
    public class WordResponse
    {
        public bool IsValid { get; set; }
        public string Word { get; set; }
        public bool IsContained { get; set; }

        public string RandomWord { get; set; }

    }
}