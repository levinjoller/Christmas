using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Threading;

namespace Christmas
{
    class Program
    {
        private static readonly Random Rng = new Random();
        private static readonly List<Child> ChildList = new List<Child>();
        private static readonly ChildDirector Director = new ChildDirector();
        private static readonly ChildBuilder Builder = new ChildBuilder();
        private static IEnumerable<Type> AllGiftTypes;

        static void Main(string[] args)
        {
            int childAmnount = 100;
            int outputAmnount = 20;

            Console.WriteLine("Generating {0} children that wish gifts from Santa.", childAmnount);
            for (int i = 0; i < childAmnount; i++)
            {
                Director.ConstructChild(Builder);
                var child = Builder.GetChild();
                var order = new GiftOrder(child, GetRandomGiftType(), GetRandomGiftColor());
                Santa.GetInstance().EnqueueGift(order);
                ChildList.Add(child);
            }

            Console.WriteLine("Santa orders all gifts at once from gift maker.");
            Santa.GetInstance().OrderGiftsFromGiftMaker();
            Console.WriteLine("We are waiting for Christmas...\n");

            WaitForChristmas();
            Console.WriteLine("HOHOHOOO, it's Christmas so all gifts are delivered.\r\n");
            Santa.GetInstance().ItsChristmasTime();
            OutputTableWithFirstEntries(outputAmnount);
        }

        private static void OutputTableWithFirstEntries(int outputAmnount)
        {
            Console.WriteLine("Showing first {0} entries:", outputAmnount);
            Console.WriteLine("┌{0}┬{0}┬{0}┬{0}┬{0}┬{1}┐", new String('─', 10), new String('─', 11));
            Console.WriteLine("│{0,10}│{1,10}│{2,10}│{3,10}│{4,10}│{5,11}│", "Firstname", "Lastname", "Age", "Gift Type", "Color", "Function");
            Console.WriteLine("├{0}┼{0}┼{0}┼{0}┼{0}┼{1}┤", new String('─', 10), new String('─', 11));
            foreach (Child child in ChildList)
            {
                if (outputAmnount-- == 0)
                {
                    break;
                }
                var giftType = child.Gift.GiftType.GetType().Name;
                Console.WriteLine("│{0,10}│{1,10}│{2,10}│{3,10}│{4,10}│{5,11}│", child.FirstName, child.LastName, child.Age, giftType, child.Gift.Color, child.Gift.Function.GetType().Name);

                if (outputAmnount > 0)
                {
                    Console.WriteLine("├{0}┼{0}┼{0}┼{0}┼{0}┼{1}┤", new String('─', 10), new String('─', 11));
                }
            }
            Console.WriteLine("└{0}┴{0}┴{0}┴{0}┴{0}┴{1}┘", new String('─', 10), new String('─', 11));
        }

        private static void WaitForChristmas()
        {
            DateTime today = DateTime.Today;
            DateTime next = new DateTime(today.Year, 12, 24);

            if (next < today)
            {
                next = next.AddYears(1);
            }
            int numDays = (next - today).Days;
            for (int i = numDays; i > 0; i--)
            {
                Console.Write("\r{0} days to christmas, please wait...", i);
                Thread.Sleep(10);
            }
        }
        private static Type GetRandomGiftType()
        {
            if (AllGiftTypes == null)
            {
                var entries = AppDomain.CurrentDomain.GetAssemblies();
                AllGiftTypes = entries.SelectMany(t => t.GetTypes())
                    .Where(t => t.IsClass && t.Namespace == typeof(GiftType.Ak47).Namespace);
            }
            return AllGiftTypes.ElementAt(Rng.Next(0, AllGiftTypes.Count()));

        }
        private static GiftColor GetRandomGiftColor()
        {
            return (GiftColor) Rng.Next(0, Enum.GetNames(typeof(GiftColor)).Length);
        }
    }
}