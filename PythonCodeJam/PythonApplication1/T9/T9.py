import time

start_time = time.time()

file = open("T9/C-large-practice.in")
fOut = open("T9/C-large-practice.out", 'w')

T = int(file.readline())

dict = {
	'a': 2,
	'b': 22,
	'c': 222,
	'd': 3,
	'e': 33,
	'f': 333,
	'g': 4,
	'h': 44,
	'i': 444,
	'j': 5,
	'k': 55,
	'l': 555,
	'm': 6,
	'n': 66,
	'o': 666,
	'p': 7,
	'q': 77,
	'r': 777,
	's': 7777,
	't': 8,
	'u': 88,
	'v': 888,
	'w': 9,
	'x': 99,
	'y': 999,
	'z': 9999,
    ' ': 0
}

for t in range(T):
    msg  = file.readline()[:-1]

    prev = "\n"
    str_list = []

    for l in msg:
        encoded = str(dict[l])
        if prev[0] == encoded[0]:
            str_list.append(" ")
        str_list.append(encoded)
        prev = encoded
    final = ''.join(str_list)

    out = "Case #%i: %s" % (t+1, final)
    print(out, file = fOut)

end_time = time.time()
print("--- %s seconds --" % (end_time - start_time))
