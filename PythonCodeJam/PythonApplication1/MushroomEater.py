#-------------------------------------------------------------------------------
# Name:        module1
# Purpose:
#
# Author:      david
#
# Created:     23/04/2015
# Copyright:   (c) david 2015
# Licence:     <your licence>
#-------------------------------------------------------------------------------

import StringIO

def solve(buffer):
    line = buffer.readline()
    N = int(line)

    line = buffer.readline()
    M = [int(m) for m in line.split(" ")]

    D = [max(0, M[i] - M[i+1]) for i in range(N-1)]
    eaten1 = sum(D)

    rate = max(max(D), 0)
    E2 = [D[i] < rate and M[i] or rate for i in range(N-1)]
    eaten2 = sum(E2)

    return "%s %s" % (eaten1, eaten2)

def main():
    print("hello")
    input = """4
10 5 15 5"""
    buffer = StringIO.StringIO(input)
    result = solve(buffer)
    print(result    )

if __name__ == '__main__':
    main()
