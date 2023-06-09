using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridManager : MonoBehaviour
{
    public int difficulty;
    public Grid grid;
    public GameObject winningCanvas;
    public GameObject mine;
    public GameObject safe;
    public Material[] numbers;
    private float z;
    private float x;
    public float scale;
    public float scaleY;
    public AudioSource winningSound;

    // Start is called before the first frame update
    void Start()
    {
        grid = new Grid(difficulty);
        // Essai de placer le GameObject au milieu du champs de mines
        x = grid.grid.GetLength(0) * scale / 2; 
        z = grid.grid.GetLength(1) * scale / 2;
        RenderGrid();
    }

    /// <summary>
    /// Place les cases de la grille dans la sc�ne � partir du GameObject et assigne le material n�cessaire � la case
    /// </summary>
    void RenderGrid()
    {
        for (int i = 0; i < grid.grid.GetLength(0); i++)
        {
            for (int j = 0; j < grid.grid.GetLength(1); j++)
            {
                if (grid.grid[i, j] >= 9)
                {
                    GameObject placedMine = Instantiate(mine, transform);
                    placedMine.GetComponent<Tile>().flagEvent.AddListener(Substract);
                    placedMine.GetComponent<Tile>().unflagEvent.AddListener(Add);
                    placedMine.transform.localPosition = new Vector3(i * scale - x, 0f, j * scale - z);
                    placedMine.transform.localScale = new Vector3(scale, scaleY, scale);
                }
                else if (grid.grid[i, j] >= 1)
                {
                    GameObject nearMine = Instantiate(safe, transform);
                    nearMine.GetComponent<Tile>().flagEvent.AddListener(Add);
                    nearMine.GetComponent<Tile>().unflagEvent.AddListener(Substract);
                    nearMine.GetComponent<Renderer>().material = numbers[grid.grid[i, j] - 1];
                    nearMine.transform.localPosition = new Vector3(i * scale - x, 0f, j * scale - z);
                    nearMine.transform.localScale = new Vector3(scale, scaleY, scale);
                }
                else
                {
                    GameObject safeSquare = Instantiate(safe, transform);
                    safeSquare.GetComponent<Tile>().flagEvent.AddListener(Add);
                    safeSquare.GetComponent<Tile>().unflagEvent.AddListener(Substract);
                    safeSquare.transform.localPosition = new Vector3(i * scale - x, 0f, j * scale - z);
                    safeSquare.transform.localScale = new Vector3(scale, scaleY, scale);
                }
            }
        }
    }
    public void Add()
    {
        grid.mines ++;
    }

    public void Substract()
    {
        grid.mines--;
        if (grid.mines == 0)
        {
            Win();
        }
    }
    void Win()
    {
        winningSound.Play();
        winningCanvas.SetActive(true);
    }
}
