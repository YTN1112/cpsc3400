import sys

#Excpetion for duplicate entry
class DuplicateEntry(Exception):
    def __init__(self, message, value):
        super().__init__(message)  # Initialize the base Exception with the message
        self.value = value
        
        

def insert(tree, value):
    if tree is None:
        return [value, None, None]
    curNode = tree
    # sets curnode as tree root
    while True:
        if value == curNode[0]:
            raise DuplicateEntry("Duplcate value detected", value)
        else:
            # This assigns if the right node is empty, otherwise the new node to traverse is the right child
            if (value > curNode[0]):
                if (curNode[2] is None):
                    listInsert = [value,None,None]
                    curNode[2] = listInsert
                    return tree
                else:
                    curNode = curNode[2]
            # This assigns if the left node is empty, otherwise the new node to traverse is the left child
            if (value < curNode[0]):
                if (curNode[1] is None):
                    listInsert = [value,None,None]
                    curNode[1] = listInsert
                    return tree
                else:
                    curNode = curNode[1]


def search(tree,value):
    curNode = tree
    # looks for value in the tree based on BST priniples
    if tree is None:
        return False
    while curNode is not None:
        if (value == curNode[0]):
            return True
        elif(value > curNode[0]):
            curNode = curNode[2]
        else:
            curNode = curNode[1]
    return False
        

def inOrderTraversal(root):
    # This is a recursive in order traversial yield.
    # yield from will pass it on recursively
    # A yield will happen at yield(root[0])
    if root is not None:
        if root[1] is not None:
            yield from inOrderTraversal(root[1])
            
        yield (root[0])
        
        if root[2] is not None:
            yield from inOrderTraversal(root[2])
            
def heightDictionary(myDict, root, height):
    # keeps track of the dict, root, and height
    # every recursion stack passes height +1
    if root is not None:
        if root[1] is not None:
            heightDictionary(myDict, root[1], height + 1)
        myDict[root[0]] = height
        if root[2] is not None:
            heightDictionary(myDict, root[2], height + 1)
        return myDict
            

        
         
        
    

def main():
    fileName = sys.argv[1]
    myTree = None
    for line in open(fileName):
        line = line.rstrip()
        #Exception handling for duplicate value and invalid line
        try:
            numValue = int(line)
            myTree = insert(myTree,numValue)
        except DuplicateEntry as e:
             print(f"Caught an error: {e}, Value: {e.value}")
        except ValueError:
            print(f"{line} is not an int. It's an invalid line. Moving to next line.")
    for x in range(1,10):
        ifFound = search(myTree, x)
        print(ifFound)
    print("In-Order Traversal:")
    for value in inOrderTraversal(myTree):
        print(value)
    myDict = {}
    myDict = heightDictionary(myDict,myTree,0)
    dictString = str(myDict)
    print(dictString)
    if myDict:
        print(max(myDict.values()))  
    else:
        print("The tree is empty")
    

  
  
    
if __name__ == "__main__":
    main()
            