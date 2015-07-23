using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace S10D03_Adapters
{
    class Bottle
    {

        public enum Materials { Glass, Plastic };

        public int Volume { get; set; }

        public string Color { get; set; }

        public Materials Material { get; set; }


        public Bottle(int volume, string color, Materials material)
        {
            Volume = volume;
            Color = color;
            this.Material = material;
        }


        public void Save(Stream s)
        {
            BinaryWriter bw = new BinaryWriter(s);
            bw.Write(Volume);
            bw.Write(Color);
            bw.Write((int)Material);
            bw.Flush();
        }


        public static Bottle Load(Stream s)
        {
            BinaryReader br = new BinaryReader(s);
            int volume = br.ReadInt32();
            string color = br.ReadString();
            Materials material = (Materials)br.ReadInt32();

            return new Bottle(volume, color, material);
        }


        public override string ToString()
        {
            return String.Format("Volume: {0}, Color: {1}, Material: {2}", Volume, Color, Material);
        }

    }
}
