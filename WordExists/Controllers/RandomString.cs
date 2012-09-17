using System;
using System.Linq;
using System.Text;

namespace WordExists.Controllers
{
    public class RandomString
    {
        private static readonly Random Random = new Random((int)DateTime.Now.Ticks);

        public static string GetRandomString(int size)
        {
            var builder = new StringBuilder();
            for (var i = 0; i < size; i++) {
                var ch = Convert.ToChar(Convert.ToInt32(Math.Floor(26 * Random.NextDouble() + 65)));
                builder.Append(ch);
            }
            return builder.ToString();
        }

        public static bool WordIsContainedInSequence(string word, string sequence)
        {
            var w = word.ToUpper();
            var count = 0;
            foreach (var character in w) {
                var index = sequence.IndexOf(character);
                if (index < 0 || index >= sequence.Length) continue;
                sequence = sequence.Remove(index, 1);
                count++;
            }
            return count == w.Length;
        }
    }
}