using System;
using System.Globalization;
using System.Text;

namespace Dz_Proga_4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;

            // Уровень 1: ввод двух предметов пользователем и вывод
            Console.WriteLine("=== Уровень 1: Введите 2 предмета ===");
            Item item1 = ReadItemFromConsole("Введите данные первого предмета");
            Item item2 = ReadItemFromConsole("Введите данные второго предмета");

            Console.WriteLine();
            Console.WriteLine("Введённые предметы:");
            item1.DisplayInfo();
            item2.DisplayInfo();
            Console.WriteLine();

            // Уровень 2: PlayerInventory — интерактивное добавление в инвентарь
            Console.WriteLine("=== Уровень 2: PlayerInventory (интерактивно) ===");
            var inventory = new PlayerInventory(5, 10.0f); // длина массива 5, вместимость по весу 10
            while (true)
            {
                if (!HasFreeSlot(inventory))
                {
                    Console.WriteLine("Инвентарь полностью заполнен (по слотам).");
                    break;
                }

                Console.Write("Добавить предмет в инвентарь? (y/n): ");
                var key = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(key) || key.Trim().ToLower() != "y") break;

                var it = ReadItemFromConsole("Введите данные предмета для инвентаря");
                inventory.AddItem(it);
            }

            Console.WriteLine($"Суммарный вес в инвентаре: {inventory.GetTotalWeight()}");
            Console.WriteLine();

            // Уровень 3: Player — игрок подбирает предметы (интерактивно)
            Console.WriteLine("=== Уровень 3: Player (интерактивно) ===");
            var playerInventory = new PlayerInventory(4, 12.0f);
            var player = new Player("Игрок1", playerInventory);

            while (true)
            {
                if (!HasFreeSlot(player.Inventory))
                {
                    Console.WriteLine("Инвентарь игрока заполнен (по слотам).");
                    break;
                }

                Console.Write("Игрок подбирает предмет? (y/n): ");
                var key = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(key) || key.Trim().ToLower() != "y") break;

                var it = ReadItemFromConsole("Введите данные предмета для подбора");
                player.PickUpItem(it);
            }

            Console.WriteLine();
            player.ShowInventory();
            Console.WriteLine($"Общая стоимость инвентаря: {player.GetInventoryValue()}");
            Console.WriteLine($"Общий вес инвентаря: {player.Inventory.GetTotalWeight()}");

            Console.WriteLine();
            Console.WriteLine("Нажмите любую клавишу для выхода...");
            Console.ReadKey();
        }

        private static bool HasFreeSlot(PlayerInventory inv)
        {
            foreach (var it in inv.Items)
                if (it == null) return true;
            return false;
        }

        private static Item ReadItemFromConsole(string prompt)
        {
            Console.WriteLine(prompt);
            string name = ReadNonEmptyString("  Название: ");
            int price = ReadInt("  Цена (целое число): ");
            float weight = ReadFloat("  Вес (например 1.5): ");
            return new Item(name, price, weight);
        }

        private static string ReadNonEmptyString(string prompt)
        {
            while (true)
            {
                Console.Write(prompt);
                var s = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(s)) return s.Trim();
                Console.WriteLine("  Введите непустую строку.");
            }
        }

        private static int ReadInt(string prompt)
        {
            while (true)
            {
                Console.Write(prompt);
                var s = Console.ReadLine();
                if (int.TryParse(s, out int v) && v >= 0) return v;
                Console.WriteLine("  Неверный ввод. Введите неотрицательное целое число.");
            }
        }

        private static float ReadFloat(string prompt)
        {
            while (true)
            {
                Console.Write(prompt);
                var s = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(s))
                {
                    Console.WriteLine("  Неверный ввод. Введите число.");
                    continue;
                }

                // Поддержим запятую и точку
                s = s.Trim().Replace(',', '.');
                if (float.TryParse(s, NumberStyles.Float, CultureInfo.InvariantCulture, out float v) && v >= 0f)
                    return v;

                Console.WriteLine("  Неверный ввод. Введите неотрицательное число (например 1.5).");
            }
        }
    }
}