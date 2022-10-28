import copy


def validate_battlefield(battle_field):
    ships = [4, 3, 3, 2, 2, 2, 1, 1, 1, 1]
    zones = get_zones(battle_field)

    if sum(ships) != sum([len(z) for z in zones]):
        return False

    return position(ships, zones, 0)


def position(ships, zones, n):
    if n == len(ships):
        return True

    candidates = position_candidates(ships[n], zones)
    for c in candidates:
        if position(ships, c[1], n + 1):
            return True

    return False


def position_candidates(ship, zones):
    candidates = []
    for zone in zones:
        for point in zone:
            for d in [0, 1]:
                p = can_position_ship(ship, zone, point, d)
                if p[0]:
                    z = copy.deepcopy(zones)
                    z.remove(zone)
                    z.append(p[1])
                    candidates.append((point, z))
    return candidates


def can_position_ship(ship, zone, point, horizontal):
    x = point[0]
    y = point[1]
    dx = 1 if horizontal else 0
    dy = 0 if horizontal else 1
    z = copy.copy(zone)
    s = ship
    while (x, y) in z and s:
        z.remove((x, y))
        x += dx
        y += dy
        s -= 1
    return s == 0, z


def get_zones(field):
    zones = []
    for i in range(len(field)):
        for j in range(len(field[i])):
            zone = []
            traverse(field, i, j, zone)
            if len(zone) > 0:
                zones.append(zone)
    return zones


def traverse(field, i, j, zone):
    if i < 0 or j < 0 or i >= len(field) or j >= len(field[i]):
        return

    if field[i][j] != 1:
        return

    zone.append((i, j))
    field[i][j] = 2
    traverse(field, i + 1, j, zone)
    traverse(field, i - 1, j, zone)
    traverse(field, i, j + 1, zone)
    traverse(field, i, j - 1, zone)


assert validate_battlefield(
    [[1, 0, 0, 0, 0, 1, 1, 0, 0, 0],
     [1, 0, 1, 0, 0, 0, 0, 0, 1, 0],
     [1, 0, 1, 0, 1, 1, 1, 0, 1, 0],
     [1, 0, 0, 0, 0, 0, 0, 0, 0, 0],
     [0, 0, 0, 0, 0, 0, 0, 0, 1, 0],
     [0, 0, 0, 0, 1, 1, 1, 0, 0, 0],
     [0, 0, 0, 0, 0, 0, 0, 0, 1, 0],
     [0, 0, 0, 1, 0, 0, 0, 0, 0, 0],
     [0, 0, 0, 0, 0, 0, 0, 1, 0, 0],
     [0, 0, 0, 0, 0, 0, 0, 0, 0, 0]])

assert validate_battlefield(
    [[1, 0, 0, 0, 0, 1, 1, 0, 0, 0],
     [1, 1, 0, 0, 0, 0, 0, 0, 1, 0],
     [1, 1, 0, 0, 1, 1, 1, 0, 1, 0],
     [1, 0, 0, 0, 0, 0, 0, 0, 0, 0],
     [1, 0, 0, 0, 0, 0, 0, 0, 1, 0],
     [0, 0, 0, 0, 1, 1, 1, 0, 0, 0],
     [0, 0, 0, 0, 0, 0, 0, 0, 1, 0],
     [0, 0, 0, 0, 0, 0, 0, 0, 0, 0],
     [0, 0, 0, 0, 0, 0, 0, 1, 0, 0],
     [0, 0, 0, 0, 0, 0, 0, 0, 0, 0]])
