
namespace Christmas.GiftType
{
    public class FortniteVBucks : GiftTypeState
    {
        public FortniteVBucks(Gift gift) : base(gift) { }
        public override void SetFunction()
        {
            Gift.Function = new GiftStrategy.NoFortnite();
            Gift.GiftType = new Doll(Gift);
        }
    }
}
