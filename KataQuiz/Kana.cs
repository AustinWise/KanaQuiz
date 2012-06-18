using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KataQuiz
{
    class Kana
    {
        private Kana(string rom, string hira, string kata)
        {
            this.Romaji = rom;
            this.Hiragana = hira;
            this.Katakana = kata;
        }

        public string Romaji { get; private set; }
        public string Hiragana { get; private set; }
        public string Katakana { get; private set; }

        public static List<Kana> GetAll()
        {
            List<Kana> ret = new List<Kana>();

            foreach (var line in Properties.Resources.TheKata.Split(new[] { '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(l => l.Trim())
                .Where(l => !l.StartsWith("#")))
            {
                var fields = line.Split(',');
                ret.Add(new Kana(fields[0], fields[1], fields[2]));
            }

            return ret;
        }
    }
}
