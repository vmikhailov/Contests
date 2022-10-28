import unittest

from huffman import HuffmanTree


class MyTestCase(unittest.TestCase):
    def test_something(self):
        hf = HuffmanTree()
        tree = hf.build("During handling of the above exception, another exception occurred")

        print(tree)

        self.assertEqual(True, False)


if __name__ == '__main__':
    unittest.main()
