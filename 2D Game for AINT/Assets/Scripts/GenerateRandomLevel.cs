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

    // called when the map amanger would like a new level to be created, it is passed the current level the player is on and an empty gameobject to generate it's self within
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

            currRoom = rooms[rand.Next(1, rooms.Length)]; // sets a room object to be used as the room being placed

            // if it is the first room it creates the spawn room object
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
                // this sets the previous directionas the oposite of the current direction so when the room removes walls it removes the wall leading back into the previous room
                if (direction <= 2)
                {
                    prevDirection = direction + 2;
                }
                else
                {
                    prevDirection = direction - 2;
                }

                // this will choose a random direction from 1-4, 1 is left, 2 is up, 3 is right, 4 is down
                do
                {
                    direction = rand.Next(1, 5);
                    
                } while (direction == prevDirection || GoingToClash(direction)); //this checks to see if the chosen direction is possible without it clashing with its self

                dirList.Add(direction);


                amountX = 0;
                amountY = 0;

                // these if statements spawn the corridor so that the new room and previous room are connected
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

                // this spawns the room object that was selected eariler in the correct position
                currentRoomObject = Instantiate(currRoom.levelObject, new Vector3(currX, currY, 0), Quaternion.identity);

                // this gets rid of the wall that blocks the movement between rooms using the index of the child within the room, the wall to be deleted matches up with direction so as to make the level walkable
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

            // sets the map object as the parent so that it can be destoryed easily in the map manager after a portal has been used
            currentRoomObject.transform.parent = map.transform;

            // moves to the next room
            currentRoomInt ++;
        }
    }

    // Uses a 2D array to check whether a new direction choice will clash with one of the current rooms
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


        // this try is used to make sure the level isn't generated outside of the bounds
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
