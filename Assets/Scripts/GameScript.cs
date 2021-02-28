using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Build.Player;
using UnityEditor.Rendering;
using UnityEngine;
using Random = UnityEngine.Random;

public class GameScript : MonoBehaviour
{

    public ScreenScript screen;


    int playerX = 10;
    int playerY = 10;

    string playerColor = "red";

    int playerLength = 2;
    public int playerDirection = 4;

    int fruitX;
    int fruitY;

    string fruitColor = "green";

    float timer = 0;


    int[,] map = new int[16, 16];

    void Start()
    {
        fruitX = Random.Range(0, 15);
        fruitY = Random.Range(0, 15);
    }

    void Update()
    {
        timer += Time.deltaTime;

        if (Input.GetKeyDown("w") && playerDirection != 3)
            playerDirection = 1;
        if (Input.GetKeyDown("a") && playerDirection != 4)
            playerDirection = 2;
        if (Input.GetKeyDown("s") && playerDirection != 1)
            playerDirection = 3;
        if (Input.GetKeyDown("d") && playerDirection != 2)
            playerDirection = 4;

        if (timer >= 0.2)
        {
            //Update
            timer = 0;
           
            for (int y = 0; y < 16; y++)
            {
                for (int x = 0; x < 16; x++)
                {
                    map[x, y]--;
                }
            }

            switch (playerDirection)
            {
                case 1: //Up
                    playerY++;
                    break;
                case 2: //Left
                    playerX--;
                    break;
                case 3: //Down
                    playerY--;
                    break;
                case 4: //Right
                    playerX++;
                    break;
            }


            if (playerX > 15) //Keep player confined
                playerX = 0;
            else if (playerX < 0)
                playerX = 15;
            if (playerY > 15)
                playerY = 0;
            else if (playerY < 0)
                playerY = 15;

            if (playerX == fruitX && playerY == fruitY) // Eat fruit
            {
                playerLength++;
                do
                {
                    fruitX = Random.Range(0, 15);
                    fruitY = Random.Range(0, 15);
                } while (map[fruitX, fruitY] > 0);
            }


            if (map[playerX, playerY] > 0)
            {
                playerLength = 1;
                playerX = 10;
                playerY = 10;
                map = new int[16, 16];

            }

            map[playerX, playerY] = playerLength;
            
            //Draw
            screen.deactivateAll();


            for (int y = 0; y < 16; y++)
            {
                for (int x = 0; x < 16; x++)
                {
                   if (map[x, y] > 0)
                       screen.setColor(x, y, playerColor);
                }
            }



            screen.setColor(fruitX, fruitY, fruitColor);
        }
    }

    public void setDirection(int dir)
    {
        playerDirection = dir;
    }
}
