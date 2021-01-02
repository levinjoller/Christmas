using System.Collections.Generic;
using Xunit;
using Christmas;
using Christmas.GiftType;

namespace ChristmasTest
{
    public class GeneralTest
    {
        private readonly List<Child> ChildList;
        private readonly ChildDirector Director;
        private readonly ChildBuilder Builder;
        public GeneralTest()
        {
            ChildList = new List<Child>();
            Director = new ChildDirector();
            Builder = new ChildBuilder();
            GenerateChildren(20);
        }
        private void GenerateChildren(int number)
        {
            ChildList.Clear();
            for (int i = 0; i < number; i++)
            {
                Director.ConstructChild(Builder);
                ChildList.Add(Builder.GetChild());
            }
        }
        private static void OrderAndDeliverGifts(GiftOrder order)
        {
            Santa.GetInstance().EnqueueGift(order);
            Santa.GetInstance().OrderGiftsFromGiftMaker();
            Santa.GetInstance().ItsChristmasTime();
        }
        [Fact]
        public void GenerateHundredChildren_ReturnAmnount100()
        {
            GenerateChildren(100);
            Assert.Equal(100, ChildList.Count);
        }
        [Fact]
        public void GenerateTenChildren_ReturnMiddleChildNameIsNotNull()
        {
            Assert.NotNull(ChildList[5].FirstName);
        }
        [Fact]
        public void OrderGift_ReturnGiftTypeForAk47()
        {
            var child = ChildList[0];
            var order = new GiftOrder(child, typeof(Ak47), GiftColor.Black);
            OrderAndDeliverGifts(order);
            Assert.Equal(typeof(Ak47), child.Gift.GiftType.GetType());
        }
        [Fact]
        public void OrderFortniteVBucks_ReturnDollInstead()
        {
            var child = ChildList[0];
            var order = new GiftOrder(child, typeof(FortniteVBucks), GiftColor.Black);
            OrderAndDeliverGifts(order);
            Assert.Equal(typeof(Doll), child.Gift.GiftType.GetType());
        }
        [Fact]
        public void OrderGift_ReturnGiftColorForDoll()
        {
            var child = ChildList[0];
            var order = new GiftOrder(child, typeof(Doll), GiftColor.Green);
            OrderAndDeliverGifts(order);
            Assert.Equal(GiftColor.Green, child.Gift.Color);
        }
        [Fact]
        public void OrderGift_ReturnFunctionBeepForDoll()
        {
            var child = ChildList[0];
            var order = new GiftOrder(child, typeof(Doll), GiftColor.Green);
            OrderAndDeliverGifts(order);
            Assert.Equal("Christmas.GiftStrategy.Beep", order.Gift.Function.ToString());
        }
        [Fact]
        public void OrderGiftDirectlyAtGoblin_ReturnFunctionEatHomeworkForDoll()
        {
            var goblin = new Goblin();
            var child = ChildList[0];
            var order = new GiftOrder(child, typeof(Doll), GiftColor.Black);
            Assert.Equal("Christmas.GiftStrategy.EatHomework", goblin.Create(order).Function.ToString());
        }
    }
}
