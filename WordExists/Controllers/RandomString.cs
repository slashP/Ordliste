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
            var w = word;
            string[] random = { sequence };
            var count = 0;
            foreach (var index in w.Select(c => random[0].IndexOf(c)).Where(index => index > 0 && index < random[0].Length))
            {
                random[0] = random[0].Remove(index);
                count++;
            }
            return count == w.Length;
        }
    }
}