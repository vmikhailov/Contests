namespace LeetCode.Tasks2025;

using System.Numerics;
using System.Runtime.CompilerServices;
using System.Buffers.Binary;
using System.Numerics; // for BitOperations

public sealed class SegmentTree<T> where T : INumber<T>
{
    private readonly int _n; // реальная длина входа
    private readonly int _size; // степень двойки >= _n
    private readonly Func<T, T, T> _agg;
    private readonly T _identity; // нейтральный элемент для _agg
    private readonly T[] _tree; // длина = 2 * _size (индексация с 1 или 0 — см. ниже)

    /// <summary>
    /// agg должен быть ассоциативным. identity — нейтральный элемент для agg.
    /// Примеры: sum -> (a+b, 0), min -> (min, T.MaxValue), max -> (max, T.MinValue).
    /// </summary>
    public SegmentTree(ReadOnlySpan<T> nums, Func<T, T, T> agg, T identity)
    {
        _agg = agg;
        _identity = identity;

        _n = nums.Length;
        _size = (int)(_n == 0 ? 1 : BitOperations.RoundUpToPowerOf2((uint)_n));
        _tree = new T[_size * 2];

        // Инициализируем листья нейтральным элементом
        for (var i = 0; i < _size * 2; i++) _tree[i] = _identity;

        // Листья кладём начиная с индекса _size
        for (var i = 0; i < _n; i++)
            _tree[_size + i] = nums[i];

        // Строим родителей
        for (var i = _size - 1; i > 0; --i)
            _tree[i] = _agg(_tree[i << 1], _tree[(i << 1) | 1]);
    }

    /// <summary>
    /// Точечное обновление: nums[index] = val
    /// </summary>
    public void Update(int index, T val)
    {
        if ((uint)index >= (uint)_n) throw new ArgumentOutOfRangeException(nameof(index));

        var p = _size + index;
        _tree[p] = val;

        for (p >>= 1; p > 0; p >>= 1)
        {
            _tree[p] = _agg(_tree[p << 1], _tree[p << 1 | 1]);
        }
    }

    /// <summary>
    /// Запрос на отрезке [l, r] (включительно).
    /// </summary>
    public T Query(int l, int r)
    {
        if (_n == 0 || l > r) return _identity;

        if ((uint)l >= (uint)_n || (uint)r >= (uint)_n)
            throw new ArgumentOutOfRangeException();

        var left = l + _size;
        var right = r + _size;
        var resLeft = _identity;
        var resRight = _identity;

        while (left <= right)
        {
            if ((left & 1) == 1) resLeft = _agg(resLeft, _tree[left++]);
            if ((right & 1) == 0) resRight = _agg(_tree[right--], resRight);
            left >>= 1;
            right >>= 1;
        }

        return _agg(resLeft, resRight);
    }
}
