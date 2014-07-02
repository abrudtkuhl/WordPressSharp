namespace WordPressSharp.Models
{
    public abstract class FilterBase
    {
        public int Number { get; set; }
        protected FilterBase()
        {
            Number = int.MaxValue;
        }
    }
}
