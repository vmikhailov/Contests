import unittest


class SlidePuzzleTest(unittest.TestCase):
    def test_should_form_top_line(self):
        print([x for x in puzzle1])
        print([x[:] for x in puzzle1])
        self.assertEqual(True, True)


if __name__ == '__main__':
    unittest.main()

puzzle1 = [
    [4, 1, 3],
    [2, 8, 0],
    [7, 6, 5]
]
puzzle2 = [
    [10, 3, 6, 4],
    [1, 5, 8, 0],
    [2, 13, 7, 15],
    [14, 9, 12, 11]
]
puzzle3 = [
    [3, 7, 14, 15, 10],
    [1, 0, 5, 9, 4],
    [16, 2, 11, 12, 8],
    [17, 6, 13, 18, 20],
    [21, 22, 23, 19, 24]
]

puzzle4 = [
    [3, 7, 14, 15, 10],
    [1, 2, 5, 9, 4],
    [16, 0, 11, 12, 8],
    [17, 6, 13, 18, 20],
    [21, 22, 23, 19, 24]
]

#validate_solution(puzzle1, slide_puzzle([x[:] for x in puzzle1]))
#validate_solution(puzzle2, slide_puzzle([x[:] for x in puzzle2]))
#validate_solution(puzzle3, slide_puzzle([x[:] for x in puzzle3]))
