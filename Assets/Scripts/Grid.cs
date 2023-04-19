using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grid
{
    public int mines;
    public bool[,] grid;
    public Grid(int difficulty)
    {
        switch (difficulty)
        {
            case 1:
                {
                    mines = 10;
                    grid = new bool[10,8];
                    break;
                }
            case 2:
                {
                    mines = 20;
                    grid = new bool[12, 10];
                    break;
                }
            case 3:
                {
                    mines = 40;
                    grid = new bool[18, 14];
                    break;
                }
        }
        Populate();
    }
    private void Populate()
    {
        Fill();
        while(mines > 0)
        {
            int x = Random.Range(0, grid.GetLength(0));
            int y = Random.Range(0, grid.GetLength(1));
            if (!grid[x, y])
            {
                grid[x, y] = true;
                mines--;
            }
        }
    }

    private void Fill()
    {
        for (int i = 0; i < grid.GetLength(0); i++)
        {
            for (int j = 0; j < grid.GetLength(1); j++)
            {
                grid[i,j] = false;
            }
        }
    }
}
