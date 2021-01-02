using System;

namespace Christmas
{
    public class Goblin
    {
        public Gift Create(GiftOrder giftOrder)
        {
            Gift gift = new Gift
            {
                Color = giftOrder.Color
            };
            gift.GiftType = (GiftTypeState)Activator.CreateInstance(giftOrder.GiftType, gift);
            return gift;
        }
    }
}