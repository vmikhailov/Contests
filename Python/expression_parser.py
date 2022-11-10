# 2 kyu task
from collections import deque
from enum import Enum

class TokenType(Enum):
    End = 0
    Number = 1
    Operator = 2
    OpenParenthesis = 3
    CloseParenthesis = 4
    Unknown = 6


class Token:
    def __init__(self, token_type, value):
        self.type = token_type
        self.value = value


def tokenize(expression: str) -> [TokenType]:
    r = deque()
    s = ""
    number_parsing = False
    dot_passed = False
    for c in expression:
        if number_parsing:
            if c.isdigit():
                s += c
                continue
            elif c == '.' and not dot_passed:
                dot_passed = True
                s += c
                continue
            else:
                r.append(Token(TokenType.Number, s))
                number_parsing = False
                dot_passed = False
                s = ""
        elif c.isdigit():
            number_parsing = True
            s += c
            continue

        if ord(c) == 32:
            continue

        token = TokenType.Unknown
        if c == '(':
            token = TokenType.OpenParenthesis
        elif c == ')':
            token = TokenType.CloseParenthesis
        elif c in ['+', '-', '*', '/', '^']:
            token = TokenType.Operator

        r.append(Token(token, c))

    if number_parsing:
        r.append(Token(TokenType.Number, s))

    r.append(Token(TokenType.End, 0))
    return r


class Calc:
    def __init__(self, expression: str):
        self.tokens = tokenize(expression)
        self.iter = iter(self.tokens)
        self.processed = 1
        self.current = next(self.iter)

    def next(self) -> bool:
        if self.processed >= len(self.tokens):
            return False

        self.current = next(self.iter)
        self.processed += 1
        return True

    def get_value(self) -> [bool, float]:
        ok, a = self.calc_expression()
        if ok and self.current.type == TokenType.End:
            return [True, a]
        return [False, 0]

    def check(self, token_type: TokenType, values: list) -> bool:
        return self.current.type == token_type and self.current.value in values

    def calc_expression(self) -> [bool, float]:
        ok, a = self.calc_term()
        if not ok:
            return [False, 0]

        while self.check(TokenType.Operator, ['+', '-']):
            op = self.current.value
            if not self.next():
                return [False, 0]

            ok, b = self.calc_term()
            if not ok:
                return [False, 0]

            a = a + b if op == '+' else a - b

        return [True, a]

    def calc_term(self) -> [bool, float]:
        ok, a = self.calc_factor()
        if not ok:
            return [False, 0]

        while self.check(TokenType.Operator, ['*', '/']):
            op = self.current.value
            if not self.next():
                return [False, 0]

            ok, b = self.calc_factor()
            if not ok:
                return [False, 0]

            a = a * b if op == '*' else a / b

        return [True, a]

    def calc_factor(self) -> [bool, float]:
        if self.current.type == TokenType.Operator and self.current.value == '-':
            if self.next():
                ok, a = self.calc_factor()
                if ok:
                    return [True, -a]
            return [False, 0]
        elif self.current.type == TokenType.Number:
            return self.calc_number()
        elif self.current.type == TokenType.OpenParenthesis:
            if self.next():
                ok, a = self.calc_expression()
                if ok and self.current.type == TokenType.CloseParenthesis:
                    return [self.next(), a]
        return [False, 0]

    def calc_number(self) -> [bool, float]:
        if not self.current.type == TokenType.Number:
            return [False, 0]

        v = float(self.current.value)
        return [self.next(), v]


# tests
calc = Calc("2*3*4*5+99*321-12312312")
print(calc.get_value()[1])

calc = Calc("1*3-(7/1*3-9+1*4/8*9-9)*12+213")
print(calc.get_value()[1])

calc = Calc("1/10")
ok, a = calc.get_value()
print(a)

# for t in tokenize("(2 / (2 + 3.33) * 4) - -6"):
[print(t.type, "\t", t.value) for t in tokenize("2 + 3 * (4 + 4)")]