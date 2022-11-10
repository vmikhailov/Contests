def postfix_evaluator(expr):
    num = False
    minus = False
    stack = []
    for c in expr:
        if num:
            if c.isdigit():
                stack[-1] += c
            else:
                num = False
                v = int(stack.pop())
                v = -v if minus else v
                stack.append(v)
                minus = False
        elif c.isdigit():
            num = True
            stack.append(c)
        elif c == '-':
            minus = True
        elif c in ['+', '*', '/']:
            stack.append(op(c, stack.pop(), stack.pop()))
        else:
            if minus:
                stack.append(op('-', stack.pop(), stack.pop()))
                minus = False

    if num:
        v = int(stack.pop())
        v = -v if minus else v
        stack.append(v)
        minus = False
    if minus:
        stack.append(op('-', stack.pop(), stack.pop()))

    return int(stack.pop()) if len(stack) > 0 else 0


def op(c, b, a):
    if c == '+':
        return a + b
    elif c == '-':
        return a - b
    elif c == '*':
        return a * b
    elif c == '/':
        return a // b if b != 0 else 0
        #return a / b


print(postfix_evaluator("20 10 -5 * -"))
print(postfix_evaluator(""))
print(postfix_evaluator("1"))
print(postfix_evaluator("-1"))
print(postfix_evaluator("2 3 9 4 / + *"), " ", 10)
print(postfix_evaluator("3 4 9 / *"), " ", 0)
print(postfix_evaluator("-42 42 +"), " ", 0)
print(postfix_evaluator("-55 63 + 58 -13 -37 36 32 + -52 -42 -80 -17 54 / / / + / - * + *"), " ", 4104)
print(postfix_evaluator("75 49 69 -40 * / +"), " ", 74)
