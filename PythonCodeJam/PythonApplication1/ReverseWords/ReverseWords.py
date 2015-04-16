import time

def solve(file):
    line = file.readline()[:-1]

    words = line.split(" ")
    words.reverse()
    line = ' '.join(words)
    return line

start_time = time.time()

file = open("ReverseWords/B-large-practice.in")
fOut = open("ReverseWords/B-large-practice.out", 'w')

T = int(file.readline())


for t in range(T):
    line = solve(file)
    out = "Case #%i: %s" % (t+1, line)
    print(out, file = fOut)

end_time = time.time()
print("--- %s seconds --" % (end_time - start_time))

