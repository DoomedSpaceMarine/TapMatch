using UnityEngine;

public class InitGrid : MonoBehaviour
{
    private EventManager _eventManager;

    //Exposed grid values for easy modification
    [SerializeField] private int gridWidth;
    [SerializeField] private int gridHeight;
    [SerializeField] private float gridCellSize;
    [SerializeField] private Vector3 originPosition;

    //Prefab matchable
    [SerializeField] private GameObject blankMatchable;

    //Game object that will be the parent of created matchables.
    [SerializeField] private Transform gridItemHolder;

    public Grid grid;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _eventManager = FindFirstObjectByType<EventManager>();

        InitializeGrid();
    }

    private void InitializeGrid()
    {
        //Creating a new grid
        grid = new Grid(gridWidth, gridHeight,gridCellSize,originPosition);

        //Draw Matchables to Grid
        for (int x = 0; x < gridWidth; x++)
        {
            for (int y = 0; y < gridHeight; y++)
            {
                GameObject newMatchable = Instantiate(blankMatchable, grid.GetWorldPosition(x, y) + new Vector3(gridCellSize, gridCellSize) * 0.5f, blankMatchable.transform.rotation, gridItemHolder);
                _eventManager.SetMatchableSize(newMatchable, gridCellSize);
                _eventManager.CreateRandomizedMatchable(newMatchable);
                grid.SetMatchableToGrid(x, y, newMatchable);

            }
        }
    }
}
