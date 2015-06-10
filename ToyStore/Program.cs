using System;

namespace ToyStore
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Toy car = new Toy("Car", 3, 2014, "BiH");
            Toy plane = new Toy("Plane", 2, 2013);
            Toy ball = new Toy("Ball", 0, 2013);
            
            ToyStore store = new ToyStore("Camp");
            store.BuyToy(car);
            store.BuyToy(car);
            store.BuyToy(plane);
            store.BuyToy(plane);
            store.BuyToy(plane);
            store.BuyToy(ball);
            store.BuyToy(ball);
            store.BuyToy(ball);
            store.BuyToy(ball);
           
            store.PrintInventory();
           
            store.SellToy(car);
            store.PrintInventory();
            store.SellToy(car);
            
            store.PrintInventory();
        }
    }
}
