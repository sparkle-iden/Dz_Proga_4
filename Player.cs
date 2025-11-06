using System;

namespace Dz_Proga_4
{
    internal class Player
    {
        private readonly string name;
        private readonly PlayerInventory inventory;

        public Player(string name, PlayerInventory inventory)
        {
            this.name = name;
            this.inventory = inventory ?? new PlayerInventory();
        }

        public string Name { get { return name; } }
        public PlayerInventory Inventory { get { return inventory; } }

        public void PickUpItem(Item item)
        {
            Console.WriteLine($"{Name} пытается подобрать \"{item.Name}\"...");
            inventory.AddItem(item);
        }

        public void ShowInventory()
        {
            Console.WriteLine($"--- Инвентарь игрока: {Name} ---");
            var items = inventory.Items;
            bool any = false;
            for (int i = 0; i < items.Length; i++)
            {
                if (items[i] != null)
                {
                    Console.Write($"Слот {i}: ");
                    items[i].DisplayInfo();
                    any = true;
                }
            }
            if (!any) Console.WriteLine("Инвентарь пуст.");
            Console.WriteLine($"Суммарный вес: {inventory.GetTotalWeight()}");
            Console.WriteLine($"Суммарная стоимость: {inventory.GetTotalPrice()}");
        }

        public int GetInventoryValue()
        {
            return inventory.GetTotalPrice();
        }
    }
}