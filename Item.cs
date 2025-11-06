using System;

namespace Dz_Proga_4
{
    internal class Item
    {
        private readonly string name;
        private readonly int price;
        private readonly float weight;

        public Item(string name, int price, float weight)
        {
            this.name = name;
            this.price = price;
            this.weight = weight;
        }

        public string Name { get { return name; } }
        public int Price { get { return price; } }
        public float Weight { get { return weight; } }

        public void DisplayInfo()
        {
            Console.WriteLine($"Название: {Name}, Цена: {Price}, Вес: {Weight}");
        }
    }
}