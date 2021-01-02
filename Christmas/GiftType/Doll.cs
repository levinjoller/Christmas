
namespace Christmas.GiftType
{
    public class Doll : GiftTypeState
    {
        public Doll(Gift gift) : base(gift) { }
        public override void SetFunction()
        {
            if (Gift.Color == GiftColor.Black)
            {
                Gift.Function = new GiftStrategy.EatHomework();
            }
            else
            {
                Gift.Function = new GiftStrategy.Beep();
            }
        }
    }
}
