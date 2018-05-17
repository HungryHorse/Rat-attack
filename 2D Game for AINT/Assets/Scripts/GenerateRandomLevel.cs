using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateRandomLevel : MonoBehaviour {

    public Room[] rooms;
    public System.Random rand = new System.Random();
    List<int> dirList = new List<int>();
    public GameObject corridorX;
    public GameObject corridorY;
    GameObject currCorridor;
    Room currRoom;
    int direction;
    int prevDirection;
    float amountX;
    float amountY;
    float currX;
    float currY;
    int[,] twoDCheckArray;
    int yPos;
    int xPos;


    public void GenNewLevel(int levelNumber, GameObject map)
    {
        int numberOfRooms = rand.Next(levelNumber + 4, levelNumber + 7);
        int currentRoomInt = 0;
        GameObject currentRoomObject;
        Room prevRoom = new Room();
        amountX = 0;
        amountY = 0;
        currX = 0;
        currY = 0;
        xPos = levelNumber + 6;
        yPos = levelNumber + 6;
        twoDCheckArray = new int[(levelNumber + 6) *2, (levelNumber + 6) * 2];

        while (currentRoomInt <= numberOfRooms)
        {
            if(currRoom != null)
            {
                prevRoom = currRoom;
            }

            currRoom = rooms[rand.Next(1, rooms.Length)];

            if(currentRoomInt == 0)
            {
                direction = rand.Next(1, 5);
                dirList.Add(direction);
                currRoom = rooms[0];
                currentRoomObject = Instantiate(currRoom.levelObject, new Vector3(0, 0, 0), Quaternion.identity);
                currentRoomObject.transform.GetChild(direction).gameObject.SetActive(false);
                twoDCheckArray[xPos, yPos] = 1;
            }
            else
            {                    
                if (direction <= 2)
                {
                    prevDirection = direction + 2;
                }
                else
                {
                    prevDirection = direction - 2;
                }

                do
                {
                    direction = rand.Next(1, 5);
                    
                } while (direction == prevDirection || GoingToClash(direction));

                dirList.Add(direction);


                amountX = 0;
                amountY = 0;

                if (prevDirection == 3)
                {
                    amountX = -((prevRoom.width) / 2f) - 3f - ((currRoom.width) / 2f);
                    currCorridor = Instantiate(corridorX, new Vector3(currX - (prevRoom.width/ 2 + 1.5f), currY, 0), Quaternion.Euler(new Vector3(0, 0, 90)));
                }
                if (prevDirection == 4)
                {
                    amountY = ((prevRoom.height) / 2f) + 3f + ((currRoom.height) / 2f);
                    currCorridor = Instantiate(corridorY, new Vector3(currX, currY + (prevRoom.height/ 2 + 1.5f), 0), Quaternion.identity);
                }
                if (prevDirection == 1)
                {
                    amountX = ((prevRoom.width) / 2f) + 3f + ((currRoom.width) / 2f);
                    currCorridor = Instantiate(corridorX, new Vector3(currX + (prevRoom.width/2 + 1.5f), currY, 0), Quaternion.Euler(new Vector3(0, 0, 90)));
                }
                if (prevDirection == 2)
                {
                    amountY = -((prevRoom.height) / 2f) - 3f - ((currRoom.height) / 2f);
                    currCorridor = Instantiate(corridorY, new Vector3(currX, currY - (prevRoom.height/ 2 + 1.5f), 0), Quaternion.identity);
                }

                currX += amountX;
                currY += amountY;

                currentRoomObject = Instantiate(currRoom.levelObject, new Vector3(currX, currY, 0), Quaternion.identity);

                if (currentRoomInt == numberOfRooms)
                {
                    currentRoomObject.transform.GetChild(prevDirection).gameObject.SetActive(false);
                }
                else
                {
                    currentRoomObject.transform.GetChild(direction).gameObject.SetActive(false);
                    currentRoomObject.transform.GetChild(prevDirection).gameObject.SetActive(false);
                }
                currCorridor.gameObject.transform.parent = map.transform;
                
            }


            currentRoomObject.transform.parent = map.transform;
            currentRoomInt ++;
        }
    }


    public bool GoingToClash(int tryDir)
    {
        int tempXPos = 0;
        int tempYPos = 0;
        if(tryDir == 1)
        {
            tempXPos = xPos - 1;
        }
        if (tryDir == 2)
        {
            tempYPos = yPos + 1;
        }
        if (tryDir == 3)
        {
            tempXPos = xPos + 1;
        }
        if (tryDir == 4)
        {
            tempYPos = yPos - 1;
        }

        try
        {
            if (twoDCheckArray[tempXPos, tempYPos] == 1)
            {
                return true;
            }
            else
            {
                twoDCheckArray[tempXPos, tempYPos] = 1;
                xPos = tempXPos;
                yPos = tempYPos;
                return false;
            }
        }
        catch
        {
            return true;
        }
    }
}
