using System.Runtime.CompilerServices;

namespace LeetCode;

public class Fancy
{
	const int n = 1000;
	List<int> _data = new(n);
	List<int> _computed = new(n);
	List<int> _args = new(n);
	
	List<Func<long, int, long>> _instructions = new();

	private int _mod = (int)1e9 + 7;
	private bool _listChanged;
	
	public void Append(int val)
	{
		_data.Add(val);
		_computed.Add(_instructions.Count);
		_listChanged = true;
	}

	public void AddAll(int inc)
	{
		AddInstruction(Add, inc);
	}

	public void MultAll(int m)
	{
		AddInstruction(Mult, m);
	}

	private void AddInstruction(Func<long, int, long> func, int value)
	{
		var c = _instructions.Count;
		if (c > 0 && _instructions[c - 1] == func && !_listChanged)
		{
			_args[c - 1] = (int)func(_args[c - 1], value);
			return;
		}

		_listChanged = false;
		_instructions.Add(func);
		_args.Add(value);
	}

	private long Add(long x, int v) => x + v;

	private long Mult(long x, int v) => x * v;

	public int GetIndex(int idx)
	{
		if (idx >= _data.Count) { return -1; }

		var val = (long)_data[idx];
		for (var i = _computed[idx]; i < _instructions.Count; i++)
		{
			val = _instructions[i](val, _args[i]);
			if (val > _mod) val %= _mod;
		}

		_listChanged = true;
		_data[idx] = (int)val;
		_computed[idx] = _instructions.Count;

		return (int)val;
	}
}