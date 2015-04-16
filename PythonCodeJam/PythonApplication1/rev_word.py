def solve(file):
    line = file.readline()[:-1]

    words = line.split(" ")
    words.reverse()
    line = ' '.join(words)
    return line
