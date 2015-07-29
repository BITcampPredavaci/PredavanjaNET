using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace S11D03_SecurityGrep
{
    class SearchParam
    {

        private string keyword;
        private string pattern;


        public SearchParam(string input)
        {
            string[] parts = input.Trim().Split(' ');
            keyword = parts[0];
            pattern = parts[1];
        }

        public SearchParam(string keyword, string pattern)
        {
            this.keyword = keyword;
            this.pattern = pattern;
        }

        public string Pattern { get { return pattern; } }
        public string Keyword { get { return keyword; } }

    }
}
