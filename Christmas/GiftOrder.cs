using System;

namespace Christmas
{
    public class GiftOrder
    {
        public GiftOrder(Child child, Type giftType, GiftColor color)
        {
            this.GiftType = giftType;
            this.Color = color;
            this.Child = child;
        }
        public Child Child { get; set; }
        public Type GiftType { get; set; }
        public GiftColor Color { get; set; }
        public Gift Gift { get; set; }
    }
}