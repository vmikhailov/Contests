using FluentAssertions;
using NUnit.Framework;

namespace LeetCode.Tasks2025;

[TestFixture]
public class BasicCalculatorTaskTests
{
	private BasicCalculatorTask _task = null!;

	[SetUp]
	public void SetUp() => _task = new BasicCalculatorTask();

	[Test]
	public void Calculate_SimpleAddition_ReturnsCorrectResult()
	{
		_task.Calculate("1 + 1").Should().Be(2);
	}

	[Test]
	public void Calculate_SimpleSubtraction_ReturnsCorrectResult()
	{
		_task.Calculate("2 - 1").Should().Be(1);
	}

	[Test]
	public void Calculate_MultipleAdditions_ReturnsCorrectResult()
	{
		_task.Calculate("2 + 3 + 4").Should().Be(9);
	}

	[Test]
	public void Calculate_MixedAdditionSubtraction_ReturnsCorrectResult()
	{
		_task.Calculate("10 - 2 + 5").Should().Be(13);
	}

	[Test]
	public void Calculate_SimpleMultiplication_ReturnsCorrectResult()
	{
		_task.Calculate("3 * 4").Should().Be(12);
	}

	[Test]
	public void Calculate_SimpleDivision_ReturnsCorrectResult()
	{
		_task.Calculate("12 / 3").Should().Be(4);
	}

	[Test]
	public void Calculate_OrderOfOperations_ReturnsCorrectResult()
	{
		_task.Calculate("2 + 3 * 4").Should().Be(14);
	}

	[Test]
	public void Calculate_OrderOfOperationsWithDivision_ReturnsCorrectResult()
	{
		_task.Calculate("20 - 10 / 2").Should().Be(15);
	}

	[Test]
	public void Calculate_MultipleMultiplicationAndDivision_ReturnsCorrectResult()
	{
		_task.Calculate("2 * 3 / 2").Should().Be(3);
	}

	[Test]
	public void Calculate_SimpleParentheses_ReturnsCorrectResult()
	{
		_task.Calculate("(1 + 1)").Should().Be(2);
	}

	[Test]
	public void Calculate_ParenthesesChangeOrder_ReturnsCorrectResult()
	{
		_task.Calculate("(2 + 3) * 4").Should().Be(20);
	}

	[Test]
	public void Calculate_NestedParentheses_ReturnsCorrectResult()
	{
		_task.Calculate("((2 + 3) * 4)").Should().Be(20);
	}

	[Test]
	public void Calculate_ComplexNestedParentheses_ReturnsCorrectResult()
	{
		_task.Calculate("2 * (3 + (4 - 1))").Should().Be(12);
	}

	[Test]
	public void Calculate_UnaryMinus_ReturnsCorrectResult()
	{
		_task.Calculate("-5").Should().Be(-5);
	}

	[Test]
	public void Calculate_UnaryMinusWithAddition_ReturnsCorrectResult()
	{
		_task.Calculate("-5 + 10").Should().Be(5);
	}

	[Test]
	public void Calculate_UnaryMinusInParentheses_ReturnsCorrectResult()
	{
		_task.Calculate("(-5)").Should().Be(-5);
	}

	[Test]
	public void Calculate_UnaryMinusWithMultiplication_ReturnsCorrectResult()
	{
		_task.Calculate("-5 * 2").Should().Be(-10);
	}

	[Test]
	public void Calculate_DoubleUnaryMinus_ReturnsCorrectResult()
	{
		_task.Calculate("--5").Should().Be(5);
	}

	[Test]
	public void Calculate_UnaryMinusAfterOperator_ReturnsCorrectResult()
	{
		_task.Calculate("5 + -3").Should().Be(2);
	}

	[Test]
	public void Calculate_UnaryMinusAfterMultiplication_ReturnsCorrectResult()
	{
		_task.Calculate("5 * -3").Should().Be(-15);
	}

	[Test]
	public void Calculate_SingleNumber_ReturnsNumber()
	{
		_task.Calculate("42").Should().Be(42);
	}

	[Test]
	public void Calculate_WithWhitespace_ReturnsCorrectResult()
	{
		_task.Calculate("  2  +  3  ").Should().Be(5);
	}

	[Test]
	public void Calculate_NoWhitespace_ReturnsCorrectResult()
	{
		_task.Calculate("2+3*4").Should().Be(14);
	}

	[Test]
	public void Calculate_LargeNumbers_ReturnsCorrectResult()
	{
		_task.Calculate("1000 + 2000").Should().Be(3000);
	}

	[Test]
	public void Calculate_ComplexExpression1_ReturnsCorrectResult()
	{
		_task.Calculate("1 + 1").Should().Be(2);
	}

	[Test]
	public void Calculate_ComplexExpression2_ReturnsCorrectResult()
	{
		_task.Calculate(" 2-1 + 2 ").Should().Be(3);
	}

	[Test]
	public void Calculate_ComplexExpression3_ReturnsCorrectResult()
	{
		_task.Calculate("(1+(4+5+2)-3)+(6+8)").Should().Be(23);
	}

	[Test]
	public void Calculate_DivisionWithRemainder_TruncatesResult()
	{
		_task.Calculate("7 / 2").Should().Be(3);
	}

	[Test]
	public void Calculate_MultipleParenthesesGroups_ReturnsCorrectResult()
	{
		_task.Calculate("(1 + 2) + (3 + 4)").Should().Be(10);
	}

	[Test]
	public void Calculate_ParenthesesWithMultiplication_ReturnsCorrectResult()
	{
		_task.Calculate("2 * (3 + 4) * 5").Should().Be(70);
	}

	[Test]
	public void Calculate_DeeplyNestedParentheses_ReturnsCorrectResult()
	{
		_task.Calculate("(((1 + 2) * 3) - 4) / 5").Should().Be(1);
	}

	[Test]
	public void Calculate_ZeroResult_ReturnsZero()
	{
		_task.Calculate("5 - 5").Should().Be(0);
	}

	[Test]
	public void Calculate_NegativeResult_ReturnsNegativeNumber()
	{
		_task.Calculate("5 - 10").Should().Be(-5);
	}

	[Test]
	public void Calculate_MultiplicationByZero_ReturnsZero()
	{
		_task.Calculate("5 * 0").Should().Be(0);
	}

	[Test]
	public void Calculate_AdditionOfNegatives_ReturnsCorrectResult()
	{
		_task.Calculate("-5 + -3").Should().Be(-8);
	}

	[Test]
	public void Calculate_SubtractionWithNegatives_ReturnsCorrectResult()
	{
		_task.Calculate("-5 - -3").Should().Be(-2);
	}

	[Test]
	public void Calculate_ComplexWithAllOperators_ReturnsCorrectResult()
	{
		_task.Calculate("10 + 2 * 6 - 4 / 2").Should().Be(20);
	}
}

