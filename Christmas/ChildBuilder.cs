
namespace Christmas
{
    public class ChildBuilder
    {
        private Child _child;
        public ChildBuilder()
        {
            this.Reset();
        }
        private void Reset()
        {
            this._child = new Child();
        }
        public void SetFirstName(string firstName)
        {
            this._child.FirstName = firstName;
        }
        public void SetLastName(string lastName)
        {
            this._child.LastName = lastName;
        }
        public void SetAge(int age)
        {
            this._child.Age = age;
        }
        public Child GetChild()
        {
            Child currentChild = this._child;
            Reset();
            return currentChild;
        }
    }
}
