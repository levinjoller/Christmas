using System;
using System.Collections.Generic;
using System.Text;

namespace Christmas.GiftStrategy
{
    public class Beep : IGiftStrategy
    {
        public void Execute()
        {
            Console.WriteLine("Beep");
        }
    }
}
