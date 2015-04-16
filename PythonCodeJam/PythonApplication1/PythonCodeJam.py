import io
import rev_word

input = """3
a b c
1 2 3
hej med dig"""

buf = io.StringIO(input)
buf = open("ReverseWords/B-small-practice.in")
out = open("ReverseWords/B-small-practice.out", "w")
T = int(buf.readline())
for t in range(T):
    result = rev_word.solve(buf)
    print("Case #%i: %s" % (t+1, result), file=out)