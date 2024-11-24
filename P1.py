import sys

def processFile(fileName):
    myDict = dict()
    for line in open(fileName):
        line = line.rstrip()
        elements = line.split()
        firstPlaceColor = elements[0]
        secondPlaceColor = elements[1]
        thirdPlaceColor = elements[2]
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
    
def createFavoriteColorList(dictDisplay):
    keysGoldList = []
    sortedDict = sorted(dictDisplay.items(), key=lambda item: (item[1][0], item[1][1],item[1][2],item[0]),reverse=True)
    for key,value in sortedDict:
        if value[0] > 0:
            keysGoldList.append(f'"{key}"')
            
    print(f"{{{', '.join(keysGoldList)}}}")


def createColorScoreDict(dictDisplay):
    pointDict = dict()
    for key,(first,second,third) in dictDisplay.items():
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
