from four_squares import four_squares


def fore_squares_tests():
    for i in [0, 1, 17, 33, 215, 333, 2 ** 12 - 3, 1234567890, 106369249365575352836589875696130383747]:
        # for i in [1234567890, 106369249365575352836589875696130383747]:
        a, b, c, d = four_squares(i)
        error_msg = None
        if type(a) is not int: error_msg = "1st square is not of type int"
        if type(b) is not int: error_msg = "2nd square is not of type int"
        if type(c) is not int: error_msg = "3rd square is not of type int"
        if type(d) is not int: error_msg = "4th square is not of type int"
        s = a * a + b * b + c * c + d * d
        if s != i:
            error_msg = f"Incorrect sum.\nSquares: [{a}, {b}, {c}, {d}]\nActual: {a * a + b * b + c * c + d * d}\nExpected: {i}"
        if error_msg is not None:
            print(error_msg)
        # else:
        #    //test.pass_()


fore_squares_tests()
