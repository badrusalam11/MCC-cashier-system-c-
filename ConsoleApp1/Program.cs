using System;
using System.Collections.Generic;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            //declare variable
            int confirm = 0;
            int totalPrice = 0;
            List<string> menus;
            List<int> prices;
            MenuList(out menus, out prices);
            do
            {
            pilihan:
                // print menu
                PrintMenuList(menus, prices);
                try
                {
                    //Order Procedure
                    Console.Write($"Silahkan Pilih Menu Anda (1-{menus.Count}) : ");
                    int choice = Convert.ToInt32(Console.ReadLine());
                    Console.Write("Quantity                       : ");
                    int quantity = Convert.ToInt32(Console.ReadLine());


                    Console.WriteLine("  ");
                    Console.WriteLine($"Anda memesan : {menus[choice - 1]}");
                    Console.WriteLine($"Harga        : {prices[choice - 1]}");
                    totalPrice = CalculatePrice(prices, totalPrice, choice, quantity);
                    Console.WriteLine($"Total Harga  : {totalPrice}");


                }
                catch (FormatException ex)
                {
                    Console.WriteLine("Format Salah! Masukkan Format yang benar!");
                    goto pilihan;
                }
                catch (ArgumentOutOfRangeException ex)
                {
                    Console.WriteLine("Pilihan anda salah!");
                    goto pilihan;
                }
            choose:
                try
                {
                    Console.WriteLine("  ");
                    Console.WriteLine("Beli lagi ?");
                    Console.WriteLine("1. Ya");
                    Console.WriteLine("2. Tidak");
                    Console.Write("jawab : ");
                    confirm = Convert.ToInt32(Console.ReadLine());
                    if (confirm > 2 || confirm < 1)
                    {
                        Console.WriteLine("Masukkan pilihan yang benar");
                        goto choose;
                    }
                }
                catch (FormatException ex)
                {
                    Console.WriteLine("Format Salah! Masukkan Format yang benar!");
                    goto choose;
                }
            }
            while (confirm != 2);
            Console.WriteLine("TRANSAKSI SELESAI");
            

        }

        private static void PrintMenuList(List<string> menus, List<int> prices)
        {
            Console.WriteLine("  ");
            Console.WriteLine("Daftar Menu :");
            for (int i = 0; i < menus.Count; i++)
            {
                //Console.Write(i + 1);
                Console.WriteLine($"{i + 1}. {menus[i]}   {prices[i]}");
            }
        }

        private static int CalculatePrice(List<int> prices, int totalPrice, int choice, int quantity)
        {
            totalPrice = totalPrice + quantity * prices[choice - 1];
            return totalPrice;
        }

        private static void MenuList(out List<string> menus, out List<int> prices)
        {
            menus = new List<string>(3);
            menus.Add("Baso");
            menus.Add("Seblak");
            menus.Add("Sate Taichan");

            prices = new List<int>(3);
            prices.Add(10000);
            prices.Add(12000);
            prices.Add(30000);
        }
    }

}
