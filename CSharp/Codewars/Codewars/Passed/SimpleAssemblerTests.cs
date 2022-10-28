using System.Collections.Generic;
using System.Linq;
using Codewars.Codewars.Asm;
using NUnit.Framework;

namespace Codewars.Codewars.Passed
{
    [TestFixture, Description("Fixed tests")]
    public class SimpleAssemblerTests
    {
        private void Test(Dictionary<string, int> expected, Dictionary<string, int> actual)
        {
            var expectedStr = "{ " +
                              string.Join(", ", expected.Select(kv => $"{kv.Key}: {kv.Value}"))
                            + " }";
            var actualStr = "{ " +
                            string.Join(", ", actual.Select(kv => $"{kv.Key}: {kv.Value}"))
                          + " }";

            Assert.AreEqual(expected, actual, $"Expected: {expectedStr}, Actual: {actualStr}");
        }

        [Test, Description("Should work for some example programs")]
        public void ExamplePrograms()
        {
            Test(
                new Dictionary<string, int> { { "a", 1 } },
                SimpleAssembler.Interpret(new[] { "mov a 5", "inc a", "dec a", "dec a", "jnz a -1", "inc a" }));
            Test(
                new Dictionary<string, int> { { "a", 0 }, { "b", -20 } },
                SimpleAssembler.Interpret(new[] { "mov a -10", "mov b a", "inc a", "dec b", "jnz a -2" }));

            Test(
                new Dictionary<string, int> { { "a", 318009 }, { "b", 196418 }, { "c", 0 }, { "d", 0 } },
                SimpleAssembler.Interpret(
                    new[]
                    {
                        "mov a 1",
                        "mov b 1",
                        "mov c 0",
                        "mov d 26",
                        "jnz c 2",
                        "jnz 1 5",
                        "mov c 7",
                        "inc d",
                        "dec c",
                        "jnz c -2",
                        "mov c a",
                        "inc a",
                        "dec b",
                        "jnz b -2",
                        "mov b c",
                        "dec d",
                        "jnz d -6",
                        "mov c 18",
                        "mov d 11",
                        "inc a",
                        "dec d",
                        "jnz d -2",
                        "dec c",
                        "jnz c -5"
                    }));
        }
    }
}