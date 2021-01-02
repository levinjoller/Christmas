using System;
using System.Collections.Generic;
using System.Text;

namespace Christmas.GiftStrategy
{
    public class Shoot : IGiftStrategy
    {
        public void Execute()
        {
            Console.WriteLine("Pew Pew");
        }
    }
}
