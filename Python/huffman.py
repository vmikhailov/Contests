class HuffmanTree:
    def __init__(self):
        pass

    def build(self, s):
        freqs = {}
        for c in s:
            if c not in freqs:
                freqs[c] = 0
            freqs[c] += 1

        nodes = []
        for f in freqs:
            nodes.append(HuffmanTreeLeaf(f, freqs[f]))

        while len(nodes) > 1:
            nodes.sort(key=lambda z: z.frequency)
            n1 = nodes.pop(0)
            n2 = nodes.pop(0)
            n3 = HuffmanTreeNode(n1, n2)
            nodes.append(n3)
        return nodes[0]


class HuffmanTreeNodeBase:
    def __init__(self, frequency, left, right):
        self.frequency = frequency
        self.left = left
        self.right = right


class HuffmanTreeLeaf(HuffmanTreeNodeBase):
    def __init__(self, char, frequency):
        super().__init__(frequency, None, None)
        self.char = char


class HuffmanTreeNode(HuffmanTreeNodeBase):
    def __init__(self, left, right):
        super().__init__(left.frequency + right.frequency, left, right)
