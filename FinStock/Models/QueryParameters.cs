namespace FinStock.Models
{
    public class QueryParameters
    {
        const int _maxSize = 100;
        private int _size = 10;

        public int Page { get; set; } = 1;
        public int Size
        {
            get { return _size; }

            set
            {
                _size = Math.Min(_maxSize, value);
            }
        }
    }
}