from fractions import gcd

def g(x):
    x

def p(x):
    x

def rho(n):
    x = 2
    y = 2
    d = 1
    while d == 1:
        x = g(x)
        y = g(g(y))
        d = gcd(abs(x-y), n)
    if d == n:
        return NoneType
    else:
        return d
