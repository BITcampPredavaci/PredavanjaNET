using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace S07D01_Homework
{
    class Artifact : Exponat
    {
        public enum Period { Classic, MiddleAge, Modern }

        private string origin;
        private Period period;

        public Artifact(string name, string description,
            string origin, Period period)
            : base(name, description)
        {
            this.origin = origin;
            this.period = period;
        }

        public override string ToString()
        {
            return base.ToString() +
                String.Format("Origin: {0}\nPeriod: {1}", origin, period);
        }

        public override ISearchable FitsSearch(string s)
        {
            if (this.Name.Contains(s) || this.Description.Contains(s)
                || this.origin.Contains(s))
                return this;
            else
                return null;
        }
    }
}
