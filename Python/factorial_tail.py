from math import sqrt


def zeroes(base, number):
    compute_primes(int(sqrt(number)) + 1)

    if (base == 0) or (number == 0):
        return 0

    ff = {}
    bb = {}
    for f in factors(base):
        bb[f] = bb[f] + 1 if f in bb else 1

    for b in bb:
        ff[b] = 0
        for n in range(2, number + 1):
            k = n
            while k % b == 0:
                ff[b] += 1
                k //= b

    c = 0
    while True:
        for f in bb:
            if (not (f in ff)) or ff[f] < bb[f]:
                return c
            ff[f] -= bb[f]
        c += 1


def factors(n):
    f = []
    while n > 1:
        d = find_divider(n)
        if d == 1:
            f.append(n)
            break
        else:
            f.append(d)
            n //= d

    return f


primes = [2, 3]


def compute_primes(n):
    for k in range(5, n + 1):
        if find_divider(k) == 1:
            primes.append(k)


def find_divider(n):
    for p in primes:
        if n % p == 0:
            return p
    return 1

def test():
    print(zeroes(249998, 1000000)) #249998
    print(zeroes(256, 1000000)) #124999
    print(zeroes(147, 7364)) # 613
    print(zeroes(1, 0))
    print(zeroes(111, 4039))
    print(zeroes(68, 1689))
    print(zeroes(16, 16))
    print(zeroes(13, 16))
    print(zeroes(221, 100), "=", 5)
    print(zeroes(10, 10))
    print(zeroes(147, 7364)) # 613
    print(zeroes(37, 7844)) #217
    print(zeroes(83, 2547)) #30
    print(zeroes(21, 1103)) #182
    print(zeroes(97, 6880)) #70
    print(zeroes(34, 6249)) #389
    print(zeroes(34, 4711)) #783
    print(zeroes(7, 6842)) #1137
    print(zeroes(256, 1000)) #124

