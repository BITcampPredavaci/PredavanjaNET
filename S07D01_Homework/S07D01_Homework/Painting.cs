using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace S07D01_Homework
{
    class Painting : Exponat
    {
        public enum Period { Renessanse, NeoClassicism, Modern, Contemporary }

        private string author;
        private Period period;

        public Painting(string name, string description,
            string author, Period period)
            : base(name, description)
        {
            this.author = author;
            this.period = period;
        }

        public override string ToString()
        {
            return base.ToString() +
                String.Format("Author: {0}\nPeriod: {1}", author, period);
        }

        public override ISearchable FitsSearch(string s)
        {
            if (this.Name.Contains(s) || this.Description.Contains(s)
                || this.author.Contains(s))
                return this;
            else
                return null;
        }


    }
}
