import random

def triangle(row):
    n = len(row)

    char_map = {
        'R': 0,
        'G': 1,
        'B': 2
    }

    def get_line(rr, n):
        d = ""
        for v in range(0, n):
            for m in char_map:
                if char_map[m] == rr[v]:
                    d += m
                    break
        return d

    print("-----------------------")
    r = []
    for c in row:
        r.append(char_map[c])

    while n > 1:
        i = 0
        while i < n - 1:
            r[i] = (3 - r[i] - r[i+1]) % 3
            i += 1
        n -= 1
        print(get_line(r, n))


    for m in char_map:
        if char_map[m] == r[0]:
            return m

    pass


def _test(cases):
    for _in, _out in cases:
        assert(triangle(_in) == _out)


basic_cases = [
    ['B', 'B'],
    ['GB', 'R'],
    ['RRR', 'R'],
    ['RGBG', 'B'],
    ['RBRGBRB', 'G'],
    ['RBRGBRBGGRRRBGBBBGG', 'G']
]


def insane_tri_test():
    _test(basic_cases)


def get_random_string(length):
    letters = 'RGB'
    return ''.join(random.choice(letters) for i in range(length))


def insane_tri_test2():
    s = get_random_string(5)
    r = triangle(s)
    print(r)
    s = get_random_string(5)
    r = triangle(s)
    print(r)

    s = get_random_string(5)
    r = triangle(s)
    print(r)

    s = get_random_string(5)
    r = triangle(s)
    print(r)

    s = get_random_string(5)
    r = triangle(s)
    print(r)

    s = get_random_string(5)
    r = triangle(s)
    print(r)


    s = get_random_string(6)
    r = triangle(s)
    print(r)

    s = get_random_string(7)
    r = triangle(s)
    print(r)

    s = get_random_string(8)
    r = triangle(s)
    print(r)

    s = get_random_string(100)
    r = triangle(s)
    print(r)

    s = get_random_string(1000)
    r = triangle(s)
    print(r)

    s = get_random_string(2000)
    r = triangle(s)
    print(r)
