using MyLinkedListProj;

namespace MySetProj;
public class MySet<T> : IEnumerable<T> 
    where T : IComparable<T>
{
    private readonly MyLinkedList<T> _items = new MyLinkedList<T>();

    public MySet() { }

    public MySet(IEnumerable<T> items)
    {
        AddRange(items);
    }

    public void Add(T item)
    {
        if (!Contains(item))
            _items.Add(item);
    }

    public void AddRange(IEnumerable<T> items)
    {
        foreach (var item in items)
            Add(item);
    }

    public bool Remove(T item)
    {
        return _items.Remove(item);
    }

    public bool Contains(T item)
    {
        return _items.Contains(item);
    }

    public int Count => _items.Count;

    public MySet<T> Union(MySet<T> other)
    {
        var result = new MySet<T>(_items);
        result.AddRange(other._items);
        return result;
    }

    public MySet<T> Intersection(MySet<T> other)
    {
        var result = new MySet<T>();
        foreach (var item in _items)
            if (other.Contains(item))
                result.Add(item);

        return result;
    }

    public MySet<T> Difference(MySet<T> other)
    {
        var result = new MySet<T>();
        foreach (var item in _items)
            if (!other.Contains(item))
                result.Add(item);

        return result;
    }

    public MySet<T> SymmetricDifference(MySet<T> other)
    {
        var result = new MySet<T>();

        foreach (var item in _items)
            if (!other.Contains(item))
                result.Add(item);

        foreach (var item in other._items)
            if (!Contains(item))
                result.Add(item);

        return result;
    }

    public IEnumerator<T> GetEnumerator() => _items.GetEnumerator();

    System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        => GetEnumerator();
}