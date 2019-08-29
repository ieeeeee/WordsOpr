using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordsOpr
{
    public class Words
    {
        public int Lesson{get;set;}
        public string Word { get; set; }
        public string Kana { get; set; }
        public int Tone { get; set; }
        public string Nature { get; set; }
        public string Meaning { get; set; }
        public string Category { get; set; }
        public int Freq { get; set; }
        public bool Holorfic { get; set; }
        public int RightCount { get; set; }
        public int ErrorCount { get; set; }
    }
}
