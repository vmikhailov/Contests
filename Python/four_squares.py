from math import isqrt
from typing import Tuple


def four_squares(n: int) -> Tuple[int, int, int, int]:
    if n == 0:
        return 0, 0, 0, 0
    if n == 1:
        return 1, 0, 0, 0
    if n == 2:
        return 1, 1, 0, 0
    if n == 3:
        return 1, 1, 1, 0
    if n == 4:
        return 1, 1, 1, 1

    q1 = isqrt(n)
    while True:
        n1 = n - q1 * q1
        if is_three_squares(n1):
            break
        q1 -= 1

    q2 = isqrt(n1)
    while True:
        n2 = n1 - q2 * q2
        q3, q4 = get_two_squares(n2)
        if q3 != 0:
            break
        q2 -= 1

    return q1, q2, q3, q4


def is_three_squares(n: int) -> bool:
    while n != 0 and n % 4 == 0:
        n /= 4
    n -= 7
    return n % 8 != 0


def get_two_squares(n: int) -> Tuple[int, int]:
    q3 = isqrt(n)
    while q3 * q3 > n / 2:
        mm = n - q3 * q3
        q4 = isqrt(mm)
        if q4 * q4 == mm:
            return q3, q4
        q3 -= 1

    return 0, 0
