using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace S10D03_Adapters
{
    class Program
    {

        private static Bottle[] generateBottles()
        {
            Bottle[] bottles = new Bottle[1000000];
            string[] colors = new string[] { "Red", "Green", "Blue", "Black" };

            Random rand = new Random();

            for (int i = 0; i < bottles.Length; i++) {
                int volume = rand.Next(100, 1000);
                String color = colors[rand.Next(0, colors.Length)];
                Bottle.Materials material = 
                    i % 2 == 0 
                    ?
                    Bottle.Materials.Glass : Bottle.Materials.Plastic;

                bottles[i] = new Bottle(volume, color, material);
            }

            return bottles;
        }

        private static void withoutCompression()
        {
            Bottle[] bottles = generateBottles();

            FileStream fs = new FileStream("withoutCompressionBottles.dat", FileMode.OpenOrCreate);

            foreach (Bottle b in bottles)
                b.Save(fs);


            fs.Close();

        }

        private static void compress()
        {

            Bottle[] bottles = generateBottles();

            FileStream fs = new FileStream("compressedBottles.dat", FileMode.OpenOrCreate);
            Stream ds = new DeflateStream(fs, CompressionMode.Compress);

            foreach (Bottle b in bottles)
                b.Save(ds);


            ds.Close();
        }

        static void Main(string[] args)
        {

            foreach (string s in args) {
                Console.WriteLine(s);
            }

            Stream fs = new FileStream("bottles.dat", FileMode.OpenOrCreate);

            MemoryStream ms = new MemoryStream();

            Bottle b = new Bottle(100, "Red", Bottle.Materials.Glass);

            b.Save(fs);
            b.Save(ms);

            fs.Position = 0;
            ms.Position = 0;

            Bottle fromFile = Bottle.Load(fs);

            Bottle fromMemory = Bottle.Load(ms);

            Console.WriteLine(fromFile);
            Console.WriteLine(fromMemory);

            //compress();
            //withoutCompression();

            fs.Close();
            ms.Close();


        }
    }
}
