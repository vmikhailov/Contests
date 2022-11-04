namespace LeetCode.Tasks;

public class MedianFinder
{
	private long _n;
	private List<int> _data = new();

	public void AddNum(int num)
	{
		_n++;

		var p = _data.BinarySearch(num);
		p = p < 0 ? ~p : p;
		_data.Insert(p, num);
	}

	public double FindMedian()
	{
		var c = _data.Count;
		if (c % 2 == 0)
		{
			return (_data[c / 2 - 1] + _data[c / 2]) / 2.0;
		}
		else
		{
			return _data[c / 2];
		}
	}
}