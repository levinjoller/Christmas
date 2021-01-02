
namespace Christmas.GiftType
{
    public class Ak47 : GiftTypeState
    {
        public Ak47(Gift gift) : base(gift) { }
        public override void SetFunction()
        {
            Gift.Function = new GiftStrategy.Shoot();
        }
    }
}
