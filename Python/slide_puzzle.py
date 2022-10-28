def slide_puzzle(ar):
    printf(ar)
    size = len(ar)
    offset = 0
    moves = []
    while offset < size - 3:
        arrange_top_row(ar, offset, moves)
        arrange_left_col(ar, offset, moves)
        offset += 1

    arrange_top_row(ar, offset, moves)

    printf(ar)
    return moves


def arrange_top_row(ar, offset, moves):
    size = len(ar)
    min_v = offset * (size + 1) + 1
    max_v = (offset + 1) * size - 2
    x = offset

    v = min_v
    while v <= max_v:
        move(ar, v, x, offset, moves)
        v += 1
        x += 1

    if size > 3:
        move(ar, v, size - 1, offset, moves, True)
        move(ar, v + 1, size - 1, offset + 1, moves, True)
        turn(ar, size - 2, offset, size - 1, offset + 1, -1, moves)


def arrange_left_col(ar, offset, moves):
    size = len(ar)
    min_v = (offset + 1) * (size + 1)
    max_v = size * (size - 3) + offset + 1
    y = offset + 1

    v = min_v
    while v <= max_v:
        move(ar, v, offset, y, moves)
        v += size
        y += 1

    move(ar, v, offset, size - 1, moves)
    move(ar, v + size, offset + 1, size - 1, moves)
    turn(ar, offset, size - 2, offset + 1, size - 1, 1, moves)


def move(ar, value, x, y, moves, force=False):
    if ar[y][x] == value:
        return

    size = len(ar)

    xv, yv = find(ar, value)
    if not force and (xv < x or yv < y):
        xt = xv + max(0, (x - xv))
        yt = yv + max(0, (y - yv))
        move(ar, value, xt, yt, moves, True)
        printf(ar)

    xz, yz = find(ar, 0)
    shift_zero(ar, xz, yz, x, y, moves)
    xv, yv = find(ar, value)
    printf(ar)

    x1, y1, x2, y2 = min(x, xv), min(y, yv), max(x, xv), max(y, yv)
    if x1 == x2:
        if x2 < size - 1:
            x2 += 1
        else:
            x1 -= 1

    if y1 == y2:
        if y2 < size - 1:
            y2 += 1
        else:
            y1 -= 1

    while ar[y][x] != value:
        turn(ar, x1, y1, x2, y2, 1, moves)

    printf(ar)
    pass


def turn(ar, x1, y1, x2, y2, offset, moves):
    if not has_zero(ar, x1, y1, x2, y2):
        shift_zero_to_rect(ar, x1, y1, x2, y2, moves)

    x, y = find(ar, 0)
    count = (x2 - x1 + y2 - y1) * 2
    step = 1 if offset > 0 else - 1
    for i in range(0, abs(offset)):
        for j in range(0, count - 1):
            xt, yt = next_cell(x, y, x1, y1, x2, y2, -step)
            ar[y][x] = ar[yt][xt]
            x, y = xt, yt
            ar[y][x] = 0
            moves.append((x, y))


def next_cell(x, y, x1, y1, x2, y2, step):
    if x == x1:
        if y == y1 and step == 1:
            return x1 + 1, y1
        if y == y2 and step == -1:
            return x1 + 1, y2
        return x, y - step

    if x == x2:
        if y == y1 and step == -1:
            return x2 - 1, y1
        if y == y2 and step == 1:
            return x2 - 1, y2
        return x, y + step

    if y == y1:
        if x == x1 and step == -1:
            return x1, y1 + 1
        if x == x2 and step == 1:
            return x2, y1 + 1
        return x + step, y

    if y == y2:
        if x == x1 and step == 1:
            return x1, y2 - 1
        if x == x2 and step == -1:
            return x2, y2 - 1
        return x - step, y

    return None


def has_zero(ar, x1, y1, x2, y2):
    for y in range(y1, y2 + 1):
        if ar[y][x1] == 0 or ar[y][x2] == 0:
            return True

    for x in range(x1, x2 + 1):
        if ar[y1][x] == 0 or ar[y2][x] == 0:
            return True

    return False


def shift_zero_to_rect(ar, x1, y1, x2, y2, moves):
    x, y = find(ar, 0)

    xt = closest(x, x1, x2)
    yt = closest(y, y1, y2)

    shift_zero(ar, x, y, xt, yt, moves)


def shift_zero(ar, x, y, xt, yt, moves):
    dx = 1 if x < xt else -1
    dy = 1 if y < yt else -1

    while x != xt:
        x += dx
        ar[y][x - dx] = ar[y][x]
        ar[y][x] = 0
        moves.append((x, y))

    while y != yt:
        y += dy
        ar[y - dy][x] = ar[y][x]
        ar[y][x] = 0
        moves.append((x, y))


def closest(v, v1, v2):
    if abs(v - v1) < abs(v - v2):
        return v1
    else:
        return v2


def find(ar, value):
    size = len(ar)
    for y in range(0, size):
        for x in range(0, size):
            if ar[y][x] == value:
                return x, y
    return None


def printf(ar):
    print("-----------------------------------")
    for r in ar:
        print(" ".join([str(d).rjust(2) for d in r]))
