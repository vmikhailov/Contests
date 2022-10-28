using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace Codewars.Codewars.Passed
{
    public class FluentCalculator : Operator
    {
        public FluentCalculator()
            : base(new List<Item>(), OperatorType.Result)
        {
        }
    }

    public static class ListExtension
    {
        public static T AddAndReturn<T>(this IList<T> list, T item)
        {
            list.Add(item);

            return item;
        }
    }

    public abstract class Item
    {
        public readonly IList<Item> Items;

        public Item(IList<Item> items)
        {
            Items = items;
        }
    }

    public class Value : Item
    {
        public int Val { get; }

        public Value(IList<Item> items, int value) : base(items)
        {
            Val = value;
        }

        public Operator Plus => (Operator)Items.AddAndReturn(new Operator(Items, OperatorType.Plus));
        public Operator Minus => (Operator)Items.AddAndReturn(new Operator(Items, OperatorType.Minus));
        public Operator Times => (Operator)Items.AddAndReturn(new Operator(Items, OperatorType.Times));
        public Operator DividedBy => (Operator)Items.AddAndReturn(new Operator(Items, OperatorType.DividedBy));

        public double Result()
        {
            var copy = new List<Item>(Items);
            Items.Clear();

            return Result(copy);
        }

        private double Result(IList<Item> items)
        {
            var ops = items.OfType<Operator>();
            var op = ops.LastOrDefault(x => x.Type == OperatorType.Plus || x.Type == OperatorType.Minus) ??
                     ops.LastOrDefault(x => x.Type == OperatorType.Times || x.Type == OperatorType.DividedBy);

            if (op == null)
            {
                return items.OfType<Value>().Single().Val;
            }

            var leftItems = items.TakeWhile(x => x != op).ToList();
            var rightItems = items.SkipWhile(x => x != op).Skip(1).ToList();
            var left = Result(leftItems);
            var right = Result(rightItems);

            return op.Type switch
            {
                OperatorType.Plus => left + right,
                OperatorType.Minus => left - right,
                OperatorType.Times => left * right,
                OperatorType.DividedBy => left / right,
                OperatorType.Result => 0,
                _ => 0
            };
        }

        public static implicit operator double(Value value) => value.Result();
    }

    public enum OperatorType
    {
        Plus,
        Minus,
        Times,
        DividedBy,
        Result
    }

    public class Operator : Item
    {
        public OperatorType Type { get; }

        public Operator(IList<Item> items, OperatorType type) : base(items)
        {
            Type = type;
        }

        public Value Zero => (Value)Items.AddAndReturn(new Value(Items, 0));
        public Value One => (Value)Items.AddAndReturn(new Value(Items, 1));
        public Value Two => (Value)Items.AddAndReturn(new Value(Items, 2));
        public Value Three => (Value)Items.AddAndReturn(new Value(Items, 3));
        public Value Four => (Value)Items.AddAndReturn(new Value(Items, 4));
        public Value Five => (Value)Items.AddAndReturn(new Value(Items, 5));
        public Value Six => (Value)Items.AddAndReturn(new Value(Items, 6));
        public Value Seven => (Value)Items.AddAndReturn(new Value(Items, 7));
        public Value Eight => (Value)Items.AddAndReturn(new Value(Items, 8));
        public Value Nine => (Value)Items.AddAndReturn(new Value(Items, 9));
        public Value Ten => (Value)Items.AddAndReturn(new Value(Items, 10));
    }

    [TestFixture]
    public class Tests
    {
        [Test]
        public static void BasicAddition()
        {
            var calculator = new FluentCalculator();

            //Test Result Call
            Assert.AreEqual(3, calculator.One.Plus.Two.Result());
        }

        [Test]
        public static void MultipleInstances()
        {
            var calculatorOne = new FluentCalculator();
            var calculatorTwo = new FluentCalculator();

            Assert.AreNotEqual((double)calculatorOne.Five.Plus.Five, (double)calculatorTwo.Seven.Times.Three);
        }

        [Test]
        public static void MultipleCalls()
        {
            //Testing that the expression or reference clears between calls
            var calculator = new FluentCalculator();
            Assert.AreEqual(4, calculator.One.Plus.One.Result() + calculator.One.Plus.One.Result());
        }

        [Test]
        public static void Bedmas()
        {
            //Testing Order of Operations
            var calculator = new FluentCalculator();
            //6*6+8/2*2+10*4/2-6
            Assert.AreEqual(58, (double)calculator.Six.Times.Six.Plus.Eight.DividedBy.Two.Times.Two.Plus.Ten.Times.Four.DividedBy.Two.Minus.Six);
            Assert.AreEqual(-11.972, calculator.Zero.Minus.Four.Times.Three.Plus.Two.DividedBy.Eight.Times.One.DividedBy.Nine, 0.01);
        }

        [Test]
        public static void StaticCombinationCalls()
        {
            //Testing Implicit Conversions
            var calculator = new FluentCalculator();
            Assert.AreEqual(177.5, 10 * calculator.Six.Plus.Four.Times.Three.Minus.Two.DividedBy.Eight.Times.One.Minus.Five.Times.Zero);
        }
    }
}