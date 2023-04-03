using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;
using System.IO;
using TMPro;
using Unity.VisualScripting;
using UnityEngine.SceneManagement;
using Random = UnityEngine.Random;

public class GenerateTiles : MonoBehaviour
{
    //these are the variables that control how many times of tiles are generated each level
    public int tileMaxX = 6;
    public int tileMaxY = 6;

    public GameObject tile;
    public GameObject dirt;
    public GameObject edge;
    public GameObject player;
    

    private const string FILE_PATH = "/Levels/";

    private int rowLengthNumber;
    private int leftBlankNumber;
    
    //it is the variable that returns the player's start position to game manager script
    //public float tileStartX;

    public float startXPos;
    public float startYPos;

    public void referenceFile(int levelNum)
    {
        //create a file
        //create the path
        string DATA_PATH = Application.dataPath + FILE_PATH + "Level" + levelNum.ToString() + ".txt";

        if (!File.Exists(DATA_PATH))
        {
            //generate signs and put it into the file
            //w:wall F:floor(floor+dust) p:player(player+floor)

            List<string> levelList = new List<string>();

            //generate the up edge
            for (int width = 0; width < levelNum * tileMaxX; width++)
            {
                levelList.Add("w");
            }
            
            levelList.Add("\n");
            
            //generate by y
            for (int j = 0; j < levelNum * tileMaxY -1; j++)
            {
                //for every row, generate a new random number
                //set up how many blocks in this row 
                rowLengthNumber = (int)Random.Range((tileMaxX * levelNum) / 2, tileMaxX * levelNum-2);
                //set up which block is the start of this row
                leftBlankNumber = (int)Random.Range(1, tileMaxX * levelNum - rowLengthNumber);

                //generate the left wall
                for (int bl = 0; bl < leftBlankNumber; bl++)
                {
                    levelList.Add("w");
                }
                //generate the floor
                for (int f = 0; f < rowLengthNumber; f++)
                {
                    levelList.Add("F");
                }
                //generate the righ floor
                for (int rl = 0; rl < levelNum * tileMaxX - leftBlankNumber - rowLengthNumber; rl++)
                {
                    levelList.Add("w");
                }
                
                //at the end of each row, make it to the new row
                levelList.Add("\n");
            }
            
            //generate the row with player
            rowLengthNumber = (int)Random.Range((tileMaxX * levelNum) / 2, tileMaxX * levelNum-2);
            leftBlankNumber = (int)Random.Range(1, tileMaxX * levelNum - rowLengthNumber);
            for (int plr = 0; plr < leftBlankNumber; plr++)
            {
                levelList.Add("w");
            }
            levelList.Add("p");
            for (int pp = 0; pp < rowLengthNumber - 1; pp++)
            {
                levelList.Add("F");
            }

            for (int pll = 0; pll < levelNum * tileMaxX - leftBlankNumber - rowLengthNumber; pll++)
            {
                levelList.Add("w");
            }
           
            levelList.Add("\n");

            //generate the down edge
            for (int width_down = 0; width_down < levelNum * tileMaxX; width_down++)
            {
                levelList.Add("w");
            }
            
            //write them in the file
            for (int q = 0; q < levelList.Capacity; q++)
            {
                File.AppendAllText(DATA_PATH,levelList[q]);
            }

        }
    }

    private GameObject levelParent;
    
    public int InstantiateFromFile(int level, float tileLength)
    {
        int dustNum = 0;
        
        DestroyImmediate(levelParent);
        levelParent = new GameObject("LEVEL" + level.ToString());
        
        //search file path
        string DATA_PATH = Application.dataPath + "/Levels/" + "Level" + level.ToString() + ".txt";
        //read from file path
        //make it an array for lines
        string[] fileLines = File.ReadAllLines(DATA_PATH);

        //for each line (a box for an array)
        for (int yPos = 0; yPos < fileLines.Length; yPos++)
        {
            //make it to an array of chars
            char[] lineChars = fileLines[yPos].ToCharArray();
            for (int xPos = 0; xPos < lineChars.Length; xPos++)
            {
                //for each char
                Char c = lineChars[xPos];

                //generate corresponding objects
                //w:wall F:floor(floor+dust) p:player(player+floor)
                switch (c)
                {
                    case 'w':
                        GameObject wall = Instantiate(edge);
                        wall.transform.position = TilePos(xPos, yPos, tileLength);
                        wall.transform.parent = levelParent.transform;
                        break;
                    case 'F':
                        GameObject floorTile = Instantiate(tile);
                        floorTile.transform.position = TilePos(xPos, yPos, tileLength);
                        floorTile.transform.parent = levelParent.transform;

                        GameObject floorDust = Instantiate(dirt);
                        floorDust.transform.position = TilePos(xPos, yPos, tileLength);
                        floorDust.transform.parent = levelParent.transform;
                        dustNum++;
                        break;
                    case 'p':
                        GameObject floor = Instantiate(tile);
                        floor.transform.position = TilePos(xPos, yPos, tileLength);
                        floor.transform.parent = levelParent.transform;

                        GameObject playerNew = Instantiate(player);
                        playerNew.transform.position = TilePos(xPos, yPos, tileLength);
                        playerNew.transform.parent = levelParent.transform;
                        break;
                }
            }
        }

        return dustNum;
    }

    //create a function to assign position to each item
    private Vector3 TilePos(int xPos, int yPos, float tileLength)
    {
        Vector3 pos;
        pos = new Vector3(startXPos + xPos * tileLength, startYPos - yPos * tileLength);
        return pos;
    }

    


    // public void InstantiateTile()
    // {
    //     //define data path
    //     //read the text in the file
    //     
    //     
    //     //make the level under one specific parent object
    //     //delete the previous object
    // }


    //
    // public void GenerateTile(int level, float startPositionX, float startPositionY, float tileLength)
    // {
    //     //create parents for the generating objects
    //     GameObject tileParent = new GameObject("TileParent");
    //     GameObject dirtParent = new GameObject("DirtParent");
    //     GameObject WallParent = new GameObject("WallParent");
    //     
    //     for (int i = 0; i < tileMaxY * level; i++)
    //     {
    //         //set up how many blocks in this row 
    //         int rowLengthNumber = (int)Random.Range((tileMaxX * level) / 2, tileMaxX * level-2);
    //         //set up which block is the start of this row
    //         int leftBlankNumber = (int)Random.Range(1, tileMaxX * level - rowLengthNumber);
    //         
    //         //generate tiles
    //         for (int j = 0; j < rowLengthNumber; j++)
    //         {
    //             //generate the tile that can be played
    //             GameObject newTile = Instantiate(tile, tileParent.transform);
    //             newTile.transform.position = new Vector3(startPositionX + tileLength * (leftBlankNumber + j),
    //                 startPositionY + i * tileLength);
    //             //generate the dirt at the same place
    //             GameObject newDirt = Instantiate(dirt, dirtParent.transform);
    //             newDirt.transform.position = new Vector3(startPositionX + tileLength * (leftBlankNumber + j),
    //                 startPositionY + i * tileLength);
    //         }
    //
    //         //generate the left tile
    //         GameObject leftEdge = Instantiate(edge, WallParent.transform);
    //         leftEdge.transform.position = new Vector3(startPositionX + tileLength * (leftBlankNumber -1),
    //             startPositionY + i * tileLength);
    //         //generate the right tile
    //         GameObject rightEdge = Instantiate(edge, WallParent.transform);
    //         rightEdge.transform.position = new Vector3(startPositionX + tileLength * (rowLengthNumber + leftBlankNumber),
    //             startPositionY + i * tileLength);
    //         
    //         //generate the up wall
    //         if ( i == 0 || i == tileMaxY * level - 1)
    //         {
    //             //row 0: make a line upon it
    //             //row last: make a line below it
    //             int q = 1;
    //             if (i == 0)
    //             {
    //                 q = -1;
    //             }
    //             
    //             //the code for generating the up and down wall
    //             for (int j = 0; j < rowLengthNumber + 2; j++)
    //             {
    //                 GameObject upEdge = Instantiate(edge, WallParent.transform);
    //                 upEdge.transform.position = new Vector3(startPositionX + tileLength * (leftBlankNumber + j -1),
    //                     startPositionY +( i + q ) * tileLength);
    //             }
    //         }
    //
    //         //rreturn the tile's startX to the GM so that it know where to put the player
    //         if (i == 0)
    //         {
    //             tileStartX = startPositionX + tileLength * leftBlankNumber;
    //         }
    //     }
    // }
    //
    //
    // public void GeneratePlayer(float startPositionX, float startPositionY, GameObject player)
    // {
    //     GameObject theplayer = Instantiate(player);
    //     theplayer.transform.position = new Vector3(startPositionX, startPositionY);
    // }
}
