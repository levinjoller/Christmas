using System;
using System.Collections.Generic;

namespace Christmas
{
    public class Santa
    {
        private static Santa _instance;
        public List<GiftOrder> EnqueuedOrders = new List<GiftOrder>();
        public List<GiftOrder> ReadyOrders = new List<GiftOrder>();
        private Santa() { }

        public static Santa GetInstance() {
            if (_instance == null) {
                _instance = new Santa();
            }
            return _instance;
        }

        public void EnqueueGift(GiftOrder order)
        {
            this.EnqueuedOrders.Add(order);
        }

        public void OrderGiftsFromGiftMaker()
        {
            GiftMaker.GetInstance().Produce(EnqueuedOrders);
        }

        public void ItsChristmasTime()
        {
            foreach (GiftOrder giftOrder in ReadyOrders)
            {
                giftOrder.Child.Gift = giftOrder.Gift;
            }
        }
    }
}
