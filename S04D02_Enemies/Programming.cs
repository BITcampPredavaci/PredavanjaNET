using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace S04D02_Enemies
{
    class Programming : Enemy
    {
        private string language;

        public string Language
        {
            get { return language; }
        }

        public Programming(string name, int attack, int def, string language)
            : base(name, attack, def, "Programming Language")
        {
            this.language = language;
        }

        public override int Damage()
        {
            double multiplier = 0;
            
            switch (language.ToLower()) {
                case "c#":
                    multiplier = 2;
                    break;
                case "java":
                    multiplier = 1.5;
                    break;
                case "ruby":
                    multiplier = 1;
                    break;
                default:
                    multiplier = 1;
                    break;
            }
            return (int)(base.Attack * multiplier);
            }


        }
    
}
