using System;
using System.Collections.Generic;
using System.Threading;
namespace Christmas
{
    public class GiftMaker
    {
        private static GiftMaker _instance;
        private GiftMaker() { }
        public static GiftMaker GetInstance()
        {
            if (_instance == null)
            {
                _instance = new GiftMaker();
            }
            return _instance;
        }
        private static void GenerateGift(object order)
        {
            if (!(order is GiftOrder actualOrder))
            {
                throw new ArgumentException();
            }
            Goblin goblin = new Goblin();
            actualOrder.Gift = goblin.Create(actualOrder);
            Santa.GetInstance().ReadyOrders.Add(actualOrder);
        }
        public void Produce(List<GiftOrder> giftOrders)
        {
            // Switch for multithreading.
#if true
            int orderCount = giftOrders.Count;
            CountdownEvent doneEvent = new CountdownEvent(orderCount);
            for (int i = 0; i < orderCount; i++)
            {
                ThreadPool.QueueUserWorkItem(
                    gift => {
                        GenerateGift(gift);
                        doneEvent.Signal(); // Tell that the thread is done
                    }, giftOrders[i]);
            }
            doneEvent.Wait();
            doneEvent.Dispose();
#else
			foreach (var order in giftOrders) {
				GenerateGift (order);
			}
#endif
        }
    }
}