def break_pieces(shape):
    field = [list(r) for r in shape.split('\n')]
    scaled = scale(field)
    rr = '\n'.join(["".join(r).rstrip() for r in scaled])
    print(rr)
    return [draw(zone) for zone in divide(scaled)]


def scale(f1):
    f2 = [[' ' for x in range(len(f1[y // 3]) * 3)] for y in range(len(f1) * 3)]
    for j in range(len(f1)):
        for i in range(len(f1[j])):
            c = f1[j][i]

            x = 3 * i + 1
            y = 3 * j + 1
            f2[y][x] = f1[j][i]

            if c == '-':
                f2[y][x - 1] = '-'
                f2[y][x + 1] = '-'

            if c == '|':
                f2[y - 1][x] = '|'
                f2[y + 1][x] = '|'

            if c == '+':
                f2[y][x + 1] = '-'
                f2[y][x - 1] = '-'
                f2[y - 1][x] = '|'
                f2[y + 1][x] = '|'
    return f2


def divide(field):
    zones = []
    for j in range(len(field)):
        for i in range(len(field[j])):
            zone = set()
            figure = traverse(field, i, j, zone)
            if figure and len(zone) > 0:
                zones.append(zone)
    return zones


def draw(z2):
    zone = set()
    for z in z2:
        zone.add((z[0] // 3, z[1] // 3))

    zone = z2

    x1 = min(zone, key=lambda z: z[0])[0]
    x2 = max(zone, key=lambda z: z[0])[0]
    y1 = min(zone, key=lambda z: z[1])[1]
    y2 = max(zone, key=lambda z: z[1])[1]

    field = [[' ' for x in range(x2 - x1 + 3)] for y in range(y2 - y1 + 3)]

    for y in range(y1, y2 + 1):
        for x in range(x1, x2 + 1):
            if (x, y) in zone:
                j = y - y1 + 1
                i = x - x1 + 1
                if (x, y - 1) not in zone:
                    field[j - 1][i] = '-' if (x - 1, y - 1) not in zone and (x + 1, y - 1) not in zone else '+'

                if (x - 1, y) not in zone:
                    field[j][i - 1] = '|' if (x - 1, y - 1) not in zone and (x - 1, y + 1) not in zone else '+'

                if (x + 1, y) not in zone:
                    field[j][i + 1] = '|' if (x + 1, y - 1) not in zone and (x + 1, y + 1) not in zone else '+'

                if (x, y + 1) not in zone:
                    field[j + 1][i] = '-' if (x - 1, y + 1) not in zone and (x + 1, y + 1) not in zone else '+'

                if (x - 1, y - 1) not in zone and field[j - 1][i - 1] == ' ':
                    field[j - 1][i - 1] = '+'

                if (x + 1, y - 1) not in zone and field[j - 1][i + 1] == ' ':
                    field[j - 1][i + 1] = '+'

                if (x - 1, y + 1) not in zone and field[j + 1][i - 1] == ' ':
                    field[j + 1][i - 1] = '+'

                if (x + 1, y + 1) not in zone and field[j + 1][i + 1] == ' ':
                    field[j + 1][i + 1] = '+'

    if x1 == x2:
        for r in field:
            r.pop(1)

    #field.pop(1)

    result = '\n'.join(["".join(r).rstrip() for r in field])
    print(result)
    return result


def traverse(field, i, j, zone):
    if i < 0 or j < 0 or j >= len(field) or i >= len(field[j]):
        return False

    if field[j][i] != ' ':
        return True

    zone.add((i, j))
    field[j][i] = '*'
    v1 = traverse(field, i + 1, j, zone)
    v2 = traverse(field, i - 1, j, zone)
    v3 = traverse(field, i, j + 1, zone)
    v4 = traverse(field, i, j - 1, zone)
    return v1 and v2 and v3 and v4


# -----------------------------------------------------------------------

shape1 = '\n'.join(["+------------+",
                    "|            |",
                    "|            |",
                    "|            |",
                    "+------+-----+",
                    "|      |     |",
                    "|      |     |",
                    "+------+-----+"])

shape2 = '\n'.join(["+-------------------+--+",
                    "|                   |  |",
                    "|                   |  |",
                    "|  +----------------+  |",
                    "|  |                   |",
                    "|  |                   |",
                    "+--+-------------------+"])

shape3 = '\n'.join(["        +-+        ",
                    "        | |        ",
                    "      +-+-+-+      ",
                    "      |     |      ",
                    "   +--+-----+--+   ",
                    "   |           |   ",
                    "+--+-----------+--+",
                    "|                 |",
                    "+-----------------+"])

shape4 = """
+------------+
|            |
|            |
|            |
+------++----+
|      ||    |
|      ||    |
+------++----+
""".strip('\n')

shape5 = """
+------------+
|            |
|            |
|            |
+-----+-+----+
|     | |    |
|     | |    |
+-----+-+----+
""".strip('\n')

solution = ['\n'.join(["+------------+",
                       "|            |",
                       "|            |",
                       "|            |",
                       "+------------+"]),
            '\n'.join(["+------+",
                       "|      |",
                       "|      |",
                       "+------+"]),
            '\n'.join(["+-----+",
                       "|     |",
                       "|     |",
                       "+-----+"])]


def test1():
    assert (sorted(break_pieces(shape1)) == sorted(solution))


def test2():
    sorted(break_pieces(shape2))


def test3():
    break_pieces(shape3)


def test4():
    break_pieces(shape4)
