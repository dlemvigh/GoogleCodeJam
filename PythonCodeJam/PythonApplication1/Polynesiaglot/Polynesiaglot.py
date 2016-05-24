from StringIO import StringIO

msg = """2
1 1 4
1 2 2"""

input = StringIO(msg)
T = int(input.readline())


for t in range(T):
    [C, V, L] = map(int, input.readline().split(" "))
    cWc = {}
    cW = {}
    cWv = {}

    def W(x):
        if not x in cW:
            if x == 0:
                return 1
            if x == 1:
                return V
            cW[x] = Wc(x) + Wv(x)
        return cW[x]

    def Wc(x):
        if (x < 2):
            return 0
        if not x in cWc:
            cWc[x] = C * Wv(x-1)
        return cWc[x]

    def Wv(x):
        if not x in cWv:
            cWv[x] = V * W(x-1)
        return cWv[x]
    
    X = W(L)
    print("Case #{0}: {1}".format((t+1), X))