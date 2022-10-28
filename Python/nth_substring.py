def find_nth_occurrence(substring, string, occurrence=1):
    i = 0
    while occurrence > 0 and i >= 0:
        i = string.find(substring, i + 1)
        occurrence -= 1

    if occurrence > 0:
        return -1
    else:
        return i

