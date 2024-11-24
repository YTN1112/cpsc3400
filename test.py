def heightDictionary(myDict, root, height):
    if root is not None:
        # Check if the left child exists and is not None
        if root[1] is not None:
            heightDictionary(myDict, root[1], height + 1)
        # Assign the height for the current node's value
        myDict[root[0]] = height
        # Check if the right child exists and is not None
        if root[2] is not None:
            heightDictionary(myDict, root[2], height + 1)

# Example usage
tree = [20, [10, [5, [2, None, None], [8, None, None]], [15, None, None]], [30, [25, [22, None, None], [27, None, None]], [35, None, [37, None, None]]]]
heights = {}
heightDictionary(heights, tree, 0)
print(heights)
