using System;

namespace Christmas
{
    public class ChildDirector
    {
        private readonly string[] _childFirstNames = { "Bruno", "Hans", "Albin", "Calliou", "Po", "Tinkiwinki", "Ute" };
        private readonly string[] _childLastNames = { "Mayer", "Keller", "Huber", "Müller", "Mauerer", "Obongo", "Üktüktal" };
        private readonly Random random = new Random();
        public void ConstructChild(ChildBuilder builder)
        {
            builder.SetFirstName(RandomName(this._childFirstNames));
            builder.SetLastName(RandomName(this._childLastNames));
            builder.SetAge(this.random.Next(5, 40));
        }
        private string RandomName(string[] nameList)
        {
            return nameList[this.random.Next(nameList.Length)];
        }
    }
}