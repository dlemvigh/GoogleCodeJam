import time

start_time = time.time()

file = open("AlienLanguage/A-small-practice.in")
fOut = open("AlienLanguage/A-small-practice.out", 'w')

T = int(file.readline())

for t in range(T):
    line = file.readline()[:-1]
    base = len(set(line))
    print("base", base)
    order = []
    for c in line:
        if not c in order:
            order.append(c)

    print("ordering", order)

    value_map = {}
    if (base > 0):
        value_map[order[0]] = 1
    if (base >= 2):
        value_map[order[1]] = 0
    if (base > 2):
        for i in range(2, base):
            value_map[order[i]] = i
    print("value map", value_map)
        
    result = 0
    base = max(base, 2)
    for c in line:
        result *= base
        result += value_map[c]
    print("value", result)

    out = "Case #%i: %s" % (t+1, result)
    print(out, file = fOut)

end_time = time.time()
print("--- %s seconds --" % (end_time - start_time))
