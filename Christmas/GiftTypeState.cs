
namespace Christmas
{
    public abstract class GiftTypeState
    {
        protected readonly Gift Gift;
        protected GiftTypeState(Gift gift)
        {
            this.Gift = gift;
        }
        public abstract void SetFunction();
    }
}
