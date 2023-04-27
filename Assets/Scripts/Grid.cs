using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grid
{
    public int mines;
    public int[,] grid;
    /// <summary>
    /// Grille dans laquelle des mines sont placées et le nombre de mines adjacentes y est déterminé 
    /// </summary>
    /// <param name="difficulty">Entre 0 et 3; 0 = tuto; 1 = facile; 2 = medium; 3 = difficile</param>
    public Grid(int difficulty)
    {
        switch (difficulty)
        {
            case 0:
                {
                    mines = 3;
                    grid = new int[4,4];
                    break;
                }
            case 1:
                {
                    mines = 10;
                    grid = new int[10,8];
                    break;
                }
            case 2:
                {
                    mines = 20;
                    grid = new int[12, 10];
                    break;
                }
            case 3:
                {
                    mines = 50;
                    grid = new int[18, 14];
                    break;
                }
        }
        Populate();
    }
    /// <summary>
    /// Remplit la grille de mine et assigne le nombre de mines adjacentes
    /// </summary>
    private void Populate()
    {
        Fill();
        //Tant qu'il reste des mines à assigner
        while(mines > 0)
        {
            int x = Random.Range(0, grid.GetLength(0)); //Choisi un x aléatoire
            int y = Random.Range(0, grid.GetLength(1)); //Choisi un y aléatoire
            if (grid[x, y] == 0) //S'il n'y a pas de mine sur cette case
            {
                grid[x, y] = 9;
                mines--;
            }
        }
        AssignValue();
    }
    /// <summary>
    /// Remplit la grille de valeur 0
    /// </summary>
    private void Fill()
    {
        for (int i = 0; i < grid.GetLength(0); i++)
        {
            for (int j = 0; j < grid.GetLength(1); j++)
            {
                grid[i,j] = 0;
            }
        }
    }
    /// <summary>
    /// Assigne le nombe de mines adjacentes pour la grille
    /// </summary>
    private void AssignValue()
    {
        //Boucle de balayage de la grille
        for (int i = 0; i < grid.GetLength(0); i++)
        {
            for (int j = 0; j < grid.GetLength(1); j++)
            {
                if(grid[i, j] >= 9) // Si il y a une mine sur cette case
                {
                    //Boucle de balayge des 8 cases autour de la mine
                    for(int x = 0; x < 3; x++)
                    {
                        for (int y = 0; y < 3; y++)
                        {
                            //If nécessaire pour pas avoir de index out of bounds
                            if (!((i - 1 + x) > grid.GetLength(0) -1  || (j - 1 + y) > grid.GetLength(1) -1  || (i - 1 + x) < 0 || (j - 1 + y) < 0))
                            {
                                grid[i - 1 + x, j - 1 + y] += 1; //Ajoute 1 au compte de mines dans la case
                            }
                        }
                    }
                }
            }
        }
    }
}
