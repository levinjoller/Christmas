using System;
using System.Collections.Generic;
using System.Text;

namespace Christmas.GiftStrategy
{
    public class NoFortnite : IGiftStrategy
    {
        public void Execute()
        {
            Console.WriteLine("We don't like Fortnite, so here's a doll instead.");
        }
    }
}
