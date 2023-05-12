f = open("termins.txt", "r", encoding="utf-8").readlines()
for i in f:
    if len(i.split(":")) != 2:
        print(i)
input()