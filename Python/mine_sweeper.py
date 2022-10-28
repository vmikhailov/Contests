from typing import List


def solve_mine(field_string, n):
    field = parse(field_string)

    while True:
        mines, border, linked, known_mines, hidden_cells = expand(field, n)
        if len(hidden_cells) == 0:
            # printf(field)
            return field
        if not find_mines(field, n, mines, border, linked, known_mines, hidden_cells):
            return None


def expand(field, n):
    changed = True
    mines = {}
    border = {}
    linked = {}
    known_mines = list(filter(lambda _: is_mine(_[2]), iterate(field)))
    hidden_cells = list(filter(lambda _: is_hidden(_[2]), iterate(field)))

    while changed:
        changed = False
        mines.clear()
        border.clear()

        for p in list(filter(lambda _: is_digit(_[2]), iterate(field))):
            m = around(field, p[0], p[1], is_mine)
            d = around(field, p[0], p[1], is_hidden)
            v = int(field[p[1]][p[0]])
            r = v - len(m)  # remaining mines
            if r == 0:
                for c in d:
                    field[c[1]][c[0]] = str(game.open(c[1], c[0]))
                    changed = True
            else:
                border[(p[0], p[1])] = r
                linked[(p[0], p[1])] = len(d)
                for c in d:
                    if not (c in mines):
                        mines[c] = []
                    mines[c].append((p[0], p[1]))

    return mines, border, linked, known_mines, hidden_cells


def find_mines(field, n, mines, border, linked, known_mines, hidden_cells):
    options = []
    keys = list(mines.keys())

    if len(hidden_cells) > 0 and n == len(known_mines):
        for c in hidden_cells:
            field[c[1]][c[0]] = str(game.open(c[1], c[0]))
        return True

    if n - len(known_mines) == len(hidden_cells):
        for c in hidden_cells:
            field[c[1]][c[0]] = "x"
        return True

    find_mines_impl(keys, mines, 0, border, linked, [], options)

    # printf(field)
    max_mines = n - len(known_mines)
    if len(hidden_cells) == len(mines):
        f = lambda z: sum(z) == max_mines
    else:
        f = lambda z: sum(z) <= max_mines

    options = list(filter(f, options))
    if len(options) == 0:
        return False

    determined_mines = options[0].copy()
    determined_no_mines = options[0].copy()

    for p in options[1:]:
        for i, v in enumerate(p):
            determined_mines[i] &= v
            determined_no_mines[i] |= v

    changed = False
    for p in zip(determined_mines, keys):
        c = p[1]
        if p[0]:
            field[c[1]][c[0]] = "x"
            changed = True

    for p in zip(determined_no_mines, keys):
        c = p[1]
        if not p[0]:
            field[c[1]][c[0]] = str(game.open(c[1], c[0]))
            changed = True

    # printf(field)
    return changed


def find_mines_impl(keys, mines, i, border, linked, r, results):
    if i == len(keys):
        if all(border[m] == 0 for k in keys for m in mines[k]):
            results.append(r.copy())
        return

    can_continue = i == 0 or all(linked[b] != 0 or (linked[b] == 0 and border[b] == 0) for b in mines[keys[i - 1]])
    if not can_continue:
        return

    c = keys[i]
    can_set_mine = all(border[b] > 0 for b in mines[c])

    if can_set_mine:
        for b in mines[c]:
            border[b] -= 1
            linked[b] -= 1

        r.append(1)
        find_mines_impl(keys, mines, i + 1, border, linked, r, results)
        r.pop()

        for b in mines[c]:
            border[b] += 1
            linked[b] += 1

    for b in mines[c]:
        linked[b] -= 1

    r.append(0)
    find_mines_impl(keys, mines, i + 1, border, linked, r, results)
    r.pop()

    for b in mines[c]:
        linked[b] += 1


def is_digit(c):
    return not (is_mine(c) or is_hidden(c))


def is_mine(c):
    return c == "x"


def is_hidden(c):
    return c == "?"


def iterate(field, f=None):
    for y, row in enumerate(field):
        for x, c in enumerate(row):
            yield x, y, c


def around(field, x, y, v=None) -> List[tuple]:
    def f1(z):
        return field[z[1]][z[0]] == v

    def f2(z):
        return v(field[z[1]][z[0]])

    neighbors = [
        point(field, x - 1, y - 1),
        point(field, x, y - 1),
        point(field, x + 1, y - 1),
        point(field, x - 1, y),
        point(field, x + 1, y),
        point(field, x - 1, y + 1),
        point(field, x, y + 1),
        point(field, x + 1, y + 1)
    ]

    lst = filter(None, neighbors)
    if v:
        f = f2 if isinstance(v, type(lambda z: 0)) else f1
        lst = filter(f, lst)

    return list(lst)


def point(field, x, y):
    if x < 0 or y < 0 or y >= len(field) or x >= len(field[0]):
        return None
    return x, y


def to_text(field):
    return "\n".join([" ".join(row) for row in field])


def parse(str):
    return [s.split() for s in str.split("\n")]


def printf(f):
    for r in f:
        print(" ".join(r))
    print("-------------------")


class game:
    result = []

    @staticmethod
    def read(field_string, result_string):
        game.field = parse(field_string)
        game.result = parse(result_string)
        game.count = sum(row.count("x") for row in game.result)
        print(game.field)
        return 0

    @staticmethod
    def open(y, x) -> object:
        return game.result[y][x]


def test():
    gamemap = """
    ?
    """.strip()
    result = """
    x
    """.strip()
    game.read(gamemap, result)
    assert solve_mine(gamemap, game.count) == parse(result)

    gamemap = """
    ?
    """.strip()
    result = """
    0
    """.strip()
    game.read(gamemap, result)
    assert solve_mine(gamemap, game.count) == parse(result)

    gamemap = """
    0 0 0 0
    0 0 0 0
    ? ? 0 0
    ? ? ? ?
    ? ? ? ?
    ? ? ? ?
    ? ? 0 0
    0 0 0 0
    0 0 0 0
    0 0 0 0
    """.strip()
    result = """
    0 0 0 0
    0 0 0 0
    1 1 0 0
    x 2 1 1
    x 3 1 x
    x 2 1 1
    1 1 0 0
    0 0 0 0
    0 0 0 0
    0 0 0 0
    """.strip()
    game.read(gamemap, result)
    assert solve_mine(gamemap, game.count) == parse(result)

    gamemap = """
    0 0 0 0 0 0 0 0 0 0 0
    0 0 0 ? ? ? ? ? ? 0 0
    0 0 ? ? ? ? ? ? ? 0 0
    0 0 ? ? ? ? ? ? ? 0 0
    0 0 ? ? ? ? ? ? ? 0 0
    0 0 ? ? ? ? ? ? ? 0 0
    0 0 ? ? ? ? ? ? ? 0 0
    0 0 ? ? ? ? ? ? 0 0 0
    0 0 0 0 0 0 0 0 0 0 0
    """.strip()
    result = """
    0 0 0 0 0 0 0 0 0 0 0
    0 0 0 1 2 3 3 2 1 0 0
    0 0 1 3 x x x x 1 0 0
    0 0 2 x x x x 5 2 0 0
    0 0 3 x x x x x 2 0 0
    0 0 3 x x x x x 2 0 0
    0 0 2 x x x x 3 1 0 0
    0 0 1 2 3 3 2 1 0 0 0
    0 0 0 0 0 0 0 0 0 0 0
    """.strip()
    game.read(gamemap, result)
    assert solve_mine(gamemap, game.count) == parse(result)

    gamemap = """
    ? ? ? ? ? ?
    ? ? ? ? ? ?
    ? ? ? 0 ? ?
    ? ? ? ? ? ?
    ? ? ? ? ? ?
    0 0 0 ? ? ?
    """.strip()
    result = """
    1 x 1 1 x 1
    2 2 2 1 2 2
    2 x 2 0 1 x
    2 x 2 1 2 2
    1 1 1 1 x 1
    0 0 0 1 1 1
    """.strip()
    game.read(gamemap, result)
    assert solve_mine(gamemap, game.count) == parse(result)

    gamemap = """
    0 ? ?
    0 ? ?
    """.strip()
    result = """
    0 1 x
    0 1 1
    """.strip()
    game.read(gamemap, result)
    assert solve_mine(gamemap, game.count) is None

    gamemap = """
    ? ? ? ? 0 0 0
    ? ? ? ? 0 ? ?
    ? ? ? 0 0 ? ?
    ? ? ? 0 0 ? ?
    0 ? ? ? 0 0 0
    0 ? ? ? 0 0 0
    0 ? ? ? 0 ? ?
    0 0 0 0 0 ? ?
    0 0 0 0 0 ? ?
    """.strip()
    result = """
    1 x x 1 0 0 0
    2 3 3 1 0 1 1
    1 x 1 0 0 1 x
    1 1 1 0 0 1 1
    0 1 1 1 0 0 0
    0 1 x 1 0 0 0
    0 1 1 1 0 1 1
    0 0 0 0 0 1 x
    0 0 0 0 0 1 1
    """.strip()
    game.read(gamemap, result)
    assert solve_mine(gamemap, game.count) == parse(result)

    gamemap = """
    ? ? 0 ? ? ? 0 0 ? ? ? 0 0 0 0 ? ? ? 0
    ? ? 0 ? ? ? 0 0 ? ? ? 0 0 0 0 ? ? ? ?
    ? ? 0 ? ? ? ? ? ? ? ? 0 0 0 0 ? ? ? ?
    0 ? ? ? ? ? ? ? ? ? ? 0 0 0 0 0 ? ? ?
    0 ? ? ? ? ? ? ? ? ? 0 0 0 0 0 0 0 0 0
    0 ? ? ? 0 0 0 ? ? ? 0 0 0 0 0 0 0 0 0
    0 0 0 0 0 0 0 ? ? ? ? ? ? ? 0 0 0 0 0
    0 0 0 0 0 0 0 0 0 0 ? ? ? ? 0 0 0 0 0
    0 0 ? ? ? 0 ? ? ? 0 ? ? ? ? 0 0 0 0 0
    0 0 ? ? ? ? ? ? ? 0 0 0 0 0 0 ? ? ? 0
    0 0 ? ? ? ? ? ? ? ? ? 0 0 0 0 ? ? ? 0
    0 0 0 0 ? ? ? ? ? ? ? 0 0 0 0 ? ? ? 0
    0 0 0 0 0 ? ? ? ? ? ? 0 0 0 0 0 ? ? ?
    0 0 ? ? ? ? ? ? 0 0 0 0 0 0 0 0 ? ? ?
    0 0 ? ? ? ? ? ? ? 0 0 0 0 0 0 0 ? ? ?
    0 0 ? ? ? ? ? ? ? ? 0 0 0 0 0 0 0 ? ?
    0 0 0 0 0 0 ? ? ? ? 0 0 0 ? ? ? 0 ? ?
    0 0 0 ? ? ? ? ? ? ? 0 0 0 ? ? ? ? ? ?
    0 0 0 ? ? ? ? ? 0 0 0 ? ? ? ? ? ? ? ?
    0 0 0 ? ? ? ? ? 0 0 0 ? ? ? 0 ? ? ? ?
    0 0 0 0 ? ? ? ? ? ? ? ? ? ? 0 ? ? ? ?
    0 0 0 0 ? ? ? ? ? ? ? ? ? ? 0 ? ? ? ?
    0 0 0 0 ? ? ? ? ? ? ? ? ? ? 0 ? ? ? ?
    """.strip()
    result = """
    1 1 0 1 1 1 0 0 1 1 1 0 0 0 0 1 1 1 0
    x 1 0 1 x 1 0 0 2 x 2 0 0 0 0 1 x 2 1
    1 1 0 2 3 3 1 1 3 x 2 0 0 0 0 1 2 x 1
    0 1 1 2 x x 1 2 x 3 1 0 0 0 0 0 1 1 1
    0 1 x 2 2 2 1 3 x 3 0 0 0 0 0 0 0 0 0
    0 1 1 1 0 0 0 2 x 2 0 0 0 0 0 0 0 0 0
    0 0 0 0 0 0 0 1 1 1 1 2 2 1 0 0 0 0 0
    0 0 0 0 0 0 0 0 0 0 1 x x 1 0 0 0 0 0
    0 0 1 1 1 0 1 1 1 0 1 2 2 1 0 0 0 0 0
    0 0 1 x 2 1 3 x 2 0 0 0 0 0 0 1 1 1 0
    0 0 1 1 2 x 3 x 3 1 1 0 0 0 0 1 x 1 0
    0 0 0 0 1 2 3 2 2 x 1 0 0 0 0 1 1 1 0
    0 0 0 0 0 1 x 1 1 1 1 0 0 0 0 0 1 1 1
    0 0 1 1 2 2 2 1 0 0 0 0 0 0 0 0 1 x 1
    0 0 1 x 2 x 2 1 1 0 0 0 0 0 0 0 1 1 1
    0 0 1 1 2 1 3 x 3 1 0 0 0 0 0 0 0 1 1
    0 0 0 0 0 0 2 x x 1 0 0 0 1 1 1 0 1 x
    0 0 0 1 1 1 1 2 2 1 0 0 0 1 x 1 1 2 2
    0 0 0 1 x 3 2 1 0 0 0 1 1 2 1 1 1 x 2
    0 0 0 1 2 x x 1 0 0 0 1 x 1 0 1 2 3 x
    0 0 0 0 1 2 2 1 1 1 1 1 1 1 0 1 x 3 2
    0 0 0 0 1 1 1 1 2 x 1 1 1 1 0 2 3 x 2
    0 0 0 0 1 x 1 1 x 2 1 1 x 1 0 1 x 3 x
    """.strip()
    game.read(gamemap, result)
    assert solve_mine(gamemap, game.count) is None

    gamemap = """
    0 0 0 0 0 0 0 0 ? ? ? ? ? 0 ? ? ? 0 ? ? ?
    0 0 0 0 0 0 0 0 ? ? ? ? ? 0 ? ? ? ? ? ? ?
    0 0 0 0 0 0 0 0 0 0 ? ? ? 0 ? ? ? ? ? ? ?
    0 0 0 0 0 ? ? ? 0 0 ? ? ? 0 ? ? ? ? ? ? 0
    ? ? 0 0 0 ? ? ? 0 ? ? ? ? 0 0 ? ? ? ? ? ?
    ? ? 0 0 0 ? ? ? 0 ? ? ? 0 0 0 ? ? ? ? ? ?
    ? ? ? 0 0 0 0 0 0 ? ? ? 0 0 0 0 0 0 ? ? ?
    ? ? ? 0 0 0 0 0 0 0 ? ? ? ? 0 0 ? ? ? 0 0
    ? ? ? 0 0 0 0 0 0 0 ? ? ? ? 0 0 ? ? ? 0 0
    """.strip()
    result = """
    0 0 0 0 0 0 0 0 1 x x 2 1 0 1 x 1 0 1 2 x
    0 0 0 0 0 0 0 0 1 2 3 x 1 0 2 2 2 1 2 x 2
    0 0 0 0 0 0 0 0 0 0 2 2 2 0 1 x 1 1 x 2 1
    0 0 0 0 0 1 1 1 0 0 1 x 1 0 1 2 2 2 1 1 0
    1 1 0 0 0 1 x 1 0 1 2 2 1 0 0 1 x 1 1 1 1
    x 1 0 0 0 1 1 1 0 1 x 1 0 0 0 1 1 1 1 x 1
    2 2 1 0 0 0 0 0 0 1 1 1 0 0 0 0 0 0 1 1 1
    1 x 1 0 0 0 0 0 0 0 1 2 2 1 0 0 1 1 1 0 0
    1 1 1 0 0 0 0 0 0 0 1 x x 1 0 0 1 x 1 0 0
    """.strip()
    game.read(gamemap, result)
    assert solve_mine(gamemap, game.count) is None
    pass
