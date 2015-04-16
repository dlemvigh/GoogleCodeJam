import time

start_time = time.time()

file = open("FileFixIt/A-large-practice.in")
fOut = open("FileFixIt/A-large-practice.out", 'w')

T = int(file.readline())

def f(path, root):
    parts = path[1:-1].split("/")
    node = root
    count = 0
    for part in parts:
        if not part in node:
            node[part] = {}
            count += 1
        node = node[part]
    return count

for t in range(T):
    line = file.readline()
    N, M = map(int, line.split(" "))
    root = {}
    count = 0
    for n in range(N):
        path = file.readline()
        f(path, root)
    for m in range(M):
        path = file.readline()
        count += f(path, root)
    out = "Case #%i: %i" % (t+1, count)
    print(out, file = fOut)

end_time = time.time()
print("--- %s seconds --" % (end_time - start_time))
