using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridManager : MonoBehaviour
{
    public int difficulty;
    public Grid grid;
    public GameObject mine;

    // Start is called before the first frame update
    void Start()
    {
        grid = new Grid(difficulty);
        RenderGrid();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void RenderGrid()
    {
        for (int i = 0; i < grid.grid.GetLength(0); i++)
        {
            for (int j = 0; j < grid.grid.GetLength(1); j++)
            {
                if (grid.grid[i, j])
                {
                    GameObject placedMine = mine;
                    placedMine.transform.position = new Vector3(i*3f, j*3f , 0f);
                }
            }
        }
    }
}
