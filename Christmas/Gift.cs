
namespace Christmas
{
    public enum GiftColor
    {
        Black,
        Green
    }
    public class Gift
    {
        private GiftTypeState _type;
        public GiftTypeState GiftType
        {
            get 
            {
                return _type;
            }
            set
            {
                _type = value;
                _type.SetFunction();
            }
        }
        public GiftColor Color { get; set; }
        public IGiftStrategy Function { get; set; }
    }
}