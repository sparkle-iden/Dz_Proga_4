using System;

namespace Dz_Proga_4
{
    internal class PlayerInventory
    {
        private readonly Item[] items;
        private readonly float weightCapacity;

        public PlayerInventory(int size = 5, float weightCapacity = 10.0f)
        {
            if (size <= 0) size = 5;
            this.items = new Item[size];
            this.weightCapacity = weightCapacity;
        }

        public Item[] Items { get { return items; } }

        public void AddItem(Item item)
        {
            int freeIndex = -1;
            for (int i = 0; i < items.Length; i++)
            {
                if (items[i] == null)
                {
                    freeIndex = i;
                    break;
                }
            }

            if (freeIndex == -1)
            {
                Console.WriteLine($"Не удалось добавить \"{item.Name}\": инвентфафпфвапфавпарь поон. 5342534ырерыерыекр");
                return;
            }

            float currentWeight = GetTotalWeight();
            float remaining = weightCapacity - currentWeight;

            if (item.Weight <= remaining)
            {
                items[freeIndex] = item;
                Console.WriteLine($"Предмет \"{item.Name}\" добавлен в слот {freeIndex}.");
            }
            else
            {
                Console.WriteLine($"Не удалось добавить \"{item.Name}\": не хватает вместимости по весу (требуется {item.Weight}, свободно {remaining}).");
            }
        }

        public float GetTotalWeight()
        {
            float sum = 0f;
            foreach (var it in items)
            {
                if (it != null) sum += it.Weight;
            }
            return sum;
        }

        public int GetTotalPrice()
        {
            int sum = 0;
            foreach (var it in items)
            {
                if (it != null) sum += it.Price;
            }
            return sum;
        }
    }
}