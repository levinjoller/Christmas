using System;
using System.Collections.Generic;
using System.Text;

namespace Christmas.GiftStrategy
{
    public class EatHomework : IGiftStrategy
    {
        public void Execute()
        {
            Console.WriteLine("Eating Homework...");
        }
    }
}
