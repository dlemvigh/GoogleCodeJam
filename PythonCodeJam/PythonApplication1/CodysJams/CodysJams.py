import StringIO
from string import Template

inputString = """2
3
15 20 60 75 80 100
4
9 9 12 12 12 15 16 20"""

input = StringIO.StringIO(inputString)
fIn = open("CodysJams/A-large-practice.in")
fOut = open("CodysJams/A-large-practice.out", 'w')
input = fIn

T = int(input.readline())

def getDiscountPrices(P):
    disc = []
    normal = []
    for p in P:
        if p in normal:
            normal.remove(p)
        else:
            disc.append(p)
            normal.append(p * 4 / 3)
    return disc

for t in range(T):
    N = int(input.readline())
    P = map(int, input.readline().split(" "))
    disc = getDiscountPrices(P)
    output = " ".join(map(str, disc))
    outStr = "Case #{0}: {1}".format(t + 1, output)
    print(outStr)
    fOut.write(outStr + "\n")

