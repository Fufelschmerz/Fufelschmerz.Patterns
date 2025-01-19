using Fufelschmerz.Patterns.Iterator.Interfaces.Interfaces;

namespace Fufelschmerz.Patterns.Iterator;

public class IntegerAggregate : IIntegerAggregate
{
    private readonly int[] _integerCollection;

    private int _currentIndex;
    private int _version;

    public IntegerAggregate(int length)
    {
        if (length <= 0)
        {
            throw new ArgumentException(nameof(length));
        }

        _integerCollection = new int[length];
        _currentIndex = 0;
        _version = 0;
        Length = length;
    }

    public int this[int index]
    {
        get
        {
            if (index < 0 || index > Length - 1)
            {
                throw new IndexOutOfRangeException();
            }

            return _integerCollection[index];
        }
    }

    public int Length { get; private set; }

    public void Add(int item)
    {
        if (_currentIndex > Length - 1)
        {
            throw new IndexOutOfRangeException();
        }

        _version++;
        _integerCollection[_currentIndex++] = item;
    }

    public IIntegerEnumerator GetEnumerator() => new IntegerEnumerator(this);

    private struct IntegerEnumerator : IIntegerEnumerator
    {
        private readonly IntegerAggregate _integerAggregate;
        private readonly int _version;

        private int _current;
        private int _currentIndex;

        public IntegerEnumerator(IntegerAggregate integerAggregate)
        {
            _integerAggregate = integerAggregate;
            _currentIndex = -1;
            _version = integerAggregate._version;
        }

        public int Current
        {
            get
            {
                if (_currentIndex == -1 ||
                    _currentIndex == _integerAggregate.Length)
                {
                    throw new InvalidOperationException();
                }

                _current = _integerAggregate[_currentIndex];

                return _current;
            }
            private set => _current = value;
        }

        public bool MoveNext()
        {
            IsCollectionModified();

            _currentIndex++;
            return _currentIndex < _integerAggregate.Length;
        }

        public void Reset()
        {
            IsCollectionModified();

            _currentIndex = -1;
            Current = default;
        }

        private void IsCollectionModified()
        {
            if (_version != _integerAggregate._version)
            {
                throw new InvalidOperationException("Collection was modified");
            }
        }
    }
}