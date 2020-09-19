using BenchmarkDotNet.Attributes;
using System;
using System.Linq;
using System.Text;

namespace StringFormattingTechniques
{
    public class StringIntern
    {
        private static readonly Random rand = new Random(1);
        public static string GenerateRandomString(int length)
        {
            var res = length == 0 ? 
                string.Empty : 
                (char)rand.Next(65, 67) + GenerateRandomString(length - 1);
            return res;
        }
        public static string GenerateRandomStringAndIntern(int length)
        {
            var res = length == 0 ?
                string.Empty :
                (char)rand.Next(69, 71) + GenerateRandomString(length - 1);
            res = string.Intern(res);
            return res;
        }

        [Benchmark]
        public void NaiveConcatenation()
        {
            var sb = new StringBuilder();
            for (int _ = 0; _ < 10000; _++)
                sb.Append(GenerateRandomString(3));
            sb.ToString();
        }

        [Benchmark]
        public void ConcatenationAndIntern()
        {
            var sb = new StringBuilder();
            for (int _ = 0; _ < 10000; _++)
                sb.Append(GenerateRandomStringAndIntern(3));
            sb.ToString();
        }
    }
}
