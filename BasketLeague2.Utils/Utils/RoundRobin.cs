namespace BasketLeague2.Utils.Utils;

public class RoundRobin<T>
{
    private readonly List<T> _items;
    private int _currentIndex;

    public RoundRobin(IEnumerable<T> items)
    {
        _items = items.ToList();
        _currentIndex = -1;
    }

    public T GetNext()
    {
        lock (_items)
        {
            if (_items.Count == 0)
            {
                throw new InvalidOperationException("No items available");
            }

            _currentIndex = (_currentIndex + 1) % _items.Count;
            return _items[_currentIndex];
        }
    }

    public void Shuffle()
    {
        lock (_items)
        {
            Random rng = new();
            var n = _items.Count;
            while (n > 1)
            {
                n--;
                var k = rng.Next(n + 1);
                (_items[k], _items[n]) = (_items[n], _items[k]);
            }
        }
    }
}