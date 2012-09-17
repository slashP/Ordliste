using System.Globalization;
using System.Linq;

namespace WordExists.Controllers
{
    public class HomeViewModel
    {
        public HomeViewModel()
        {
            RandomWord = RandomString.GetRandomString(12).Aggregate(string.Empty, (current, character) => current + character.ToString(CultureInfo.InvariantCulture) + "   ");
        }

        public string RandomWord { get; set; }
    }
}