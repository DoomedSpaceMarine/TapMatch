using UnityEngine;

public class InitGrid : MonoBehaviour
{
    //Exposed grid values for easy modification
    [SerializeField] private int gridWidth;
    [SerializeField] private int gridHeight;
    [SerializeField] private float gridCellSize;
    [SerializeField] private Vector3 originPosition;

    [SerializeField] private GameObject blankMatchable;

    [SerializeField] private Transform gridItemHolder;

    private Grid grid;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        InitializeGrid();
    }

    private void InitializeGrid()
    {
        //Creating a new grid
        grid = new Grid(gridWidth, gridHeight,gridCellSize,originPosition);

        //Draw Matchables to Grid
        for (int x = 0; x < gridWidth; x++)
        {
            for (int z = 0; z < gridHeight; z++)
            {
                Instantiate(blankMatchable, grid.GetWorldPosition(x, z), blankMatchable.transform.rotation, gridItemHolder);
            }
        }
    }
}
