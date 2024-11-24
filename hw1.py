import sys

def processFile(fileName):
    myDict = dict()
    for line in open(fileName):
        line = line.rstrip()
        # This splits the 3 into a list
        elements = line.split()
        firstPlaceColor = elements[0]
        secondPlaceColor = elements[1]
        thirdPlaceColor = elements[2]
        # if the color has not been intalized yet in the index
        # it creates it based on the first instance of either
        # first, second, or third
        # if already there, it will update by overwriting
        # since modifcation is not allowed
        if firstPlaceColor in myDict:
            curTuple = myDict[firstPlaceColor]
            indexZero = curTuple[0]
            indexZeroPlusOne = indexZero + 1
            indexOne = curTuple[1]
            indexTwo = curTuple[2]
            newTuple = (indexZeroPlusOne,indexOne,indexTwo)
            myDict[firstPlaceColor] = newTuple
        else:
            tupleFirst = (1,0,0)
            myDict[firstPlaceColor] = tupleFirst
        if secondPlaceColor in myDict:
            curTuple = myDict[secondPlaceColor]
            indexZero = curTuple[0]
            indexOne = curTuple[1]
            indexOnePlusOne = indexOne + 1
            indexTwo = curTuple[2]
            newTuple = (indexZero,indexOnePlusOne,indexTwo)
            myDict[secondPlaceColor] = newTuple
        else:
            tupleSecond = (0,1,0)
            myDict[secondPlaceColor] = tupleSecond
        if thirdPlaceColor in myDict:
            curTuple = myDict[thirdPlaceColor]
            indexZero = curTuple[0]
            indexOne = curTuple[1]
            indexTwo = curTuple[2]
            indexTwoPlusOne = indexTwo + 1
            newTuple = (indexZero,indexOne,indexTwoPlusOne)
            myDict[thirdPlaceColor] = newTuple
        else:
            tupleThird = (0,0,1)
            myDict[thirdPlaceColor] = tupleThird
    return myDict

def printDictionary(dictDisplay):
    print ("Hello")
    for key, value in dictDisplay.items():
        print(f"{key}: {value}")
        

def getFirstPlaceVotes(dictDisplay, color):
    if color in dictDisplay:
        firstPlaceVotes = dictDisplay[color][0]
        return firstPlaceVotes
    else:
        return 0

def sortKey(item):
    return (item[1][0], item[1][1], item[1][2], item[0])

def createFavoriteColorList(dictDisplay):
    # I need an empty tupple first
    keysGoldList = []
    # The key is using a function sortKey to return with 4 things to judge
    # 1st plarces, 2nd places, 3rd places, and 4th places
    # Its like the python version of a c++ where I return using mutiple
    # paremters to compare to sort
    sortedDict = sorted(dictDisplay.items(), key = sortKey, reverse=True)
    for key,value in sortedDict:
            # it will only print the color if the number of golds is at least 1
        if value[0] > 0:
         keysGoldList.append(f'"{key}"')
            
    print(f"{{{', '.join(keysGoldList)}}}")


def createColorScoreDict(dictDisplay):
    pointDict = dict()
    for key,(first,second,third) in dictDisplay.items():
        # Takes the total from the tuple
        totalPoints = first * 3 + second * 2 + third
        if key not in pointDict:
            pointDict[key] = totalPoints
    return pointDict
        
        
    
    
           
        
def main():
    fileName = sys.argv[1]
    mainDict = processFile(fileName)
    printDictionary(mainDict)
    numFirstBlue = getFirstPlaceVotes(mainDict,"blue")
    print(f"{numFirstBlue} Number of Blues")
    numFirstGreen = getFirstPlaceVotes(mainDict,"green")
    print(f"{numFirstGreen} Number of Greens")
    createFavoriteColorList(mainDict)
    newDict = createColorScoreDict(mainDict)
    printDictionary(newDict)
    
    

        
if __name__ == "__main__":
    main()        

