using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace S04D02_Enemies
{
    class Enemy
    {
        string name;
        private int attack;
        private int deff;

        string type;

        public int Attack
        {
            get { return attack; }
        }
        public int Deff
        {
            get { return deff; }
        }

        public string Type
        {
            get { return type; }
        }

        public string Name
        {
            get { return name; }
        }

        public Enemy(string name, int attack, int deff, string type)
        {
            this.name = name;
            this.attack = attack;
            this.deff = deff;
            this.type = type;
        }

        public virtual int Damage(){
            return attack;
        }


        public override string ToString()
        {
            return String.Format("{0} named {1}\nAttack: {2}\nDef: {3}\nDmg: {4}", type, name, attack, deff , Damage());
        }


    }
}
