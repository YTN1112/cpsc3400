#hello
import sys


def readFile(fileName):
    with open(fileName, 'r') as file:
        firstLine = int(file.readline().strip())
        
        tuples = []
        for line in file:
            parts = line.strip().split(',')
            if len(parts) == 2:
                part1, part2 = parts
                try:
                    # Convert both parts if possible, if part 1 is not an int, it will raise an exception
                    part1 = int(part1)
                    part2 = int(part2)
                    tuples.append((part1, part2))
                except ValueError:
                    try:
                        # if part 1 fails, then we know only to convert part 2(second element of tupple)
                        part2 = int(part2)
                        tuples.append((part1, part2))
                    except ValueError:
                        # This is for invalid line
                        print(f"Error: Invalid line")
            else:
                print("Error: Line does not contain exactly two elements")
    return firstLine, tuples



def DFSTraversal(markedNodes, tuples):
    # This is an iterative DFS traversal using a stack
    # We will directly use the tuples list to manage traversal
    
    stack = []
    for x in tuples:
        if not isinstance(x[0], int):
            pointerInt = int(x[1])  # Convert destination to an integer index
            if markedNodes[pointerInt] == 0:
                stack.append(pointerInt)

    while stack:
        visitNode = stack.pop()
        if markedNodes[visitNode] == 0:
            markedNodes[visitNode] = 1
            # Look for nodes pointed by the current node to traverse further
            for a in tuples:
                if isinstance(a[0], int) and a[0] == visitNode:
                    adjacentIndex = int(a[1])
                    if markedNodes[adjacentIndex] == 0 and adjacentIndex not in stack:
                        stack.append(adjacentIndex)
    return markedNodes

                            
                    
            
    
    


def main():
    fileName = sys.argv[1]
    firstLine, tuples = readFile(fileName)
    markedNodes = []
    for x in range(firstLine):
        markedNodes.append(0)
    markedNodes = DFSTraversal(markedNodes,tuples)    
    print("Marked nodes: ", end = " ")
    count = 0
    count2 = 0
    for x in markedNodes:
        if x == 1:
            print(count, end=" ")
        count = count + 1
    print("\n")
    print("Swept nodes: ", end = " ")
    for y in markedNodes:
        if y == 0:
            print(count2, end=" ")
        count2 = count2 + 1
    print("\n")
            
    


if __name__ == "__main__":
    main()