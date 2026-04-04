using Unity.VisualScripting;
using UnityEngine;

public class GridInitializer : MonoBehaviour
{
    //Core Managers
    private EventManager _eventManager;

    //Exposed Grid Settings
    [SerializeField] private int gridWidth;
    [SerializeField] private int gridHeight;
    [SerializeField] private float gridSize;
    [SerializeField] private Vector3 gridOriginPosition;

    //Blank matchable
    [SerializeField] private GameObject blankMatchablePrefab;

    //Grid parent gameObject
    [SerializeField] private GameObject gridParent;

    public MatchableGrid grid;

    void Start()
    {
        _eventManager = FindFirstObjectByType<EventManager>();

        InitiateGrid();
    }

    private void InitiateGrid()
    {
        //Creating a grid based on given parameters at the start of the game
        grid = new MatchableGrid(gridWidth, gridHeight, gridSize, gridOriginPosition);

        //Fill grid with randomized matchables
        for (int x = 0; x < gridWidth; x++)
        {
            for (int y = 0; y < gridHeight; y++)
            {
                Vector3 worldPosition = grid.grid.GetWorldPosition(x, y);
                //Instantiate blank matchable
                GameObject newBlankMatchable = Instantiate(blankMatchablePrefab, worldPosition + new Vector3(gridSize, gridSize) * 0.5f, blankMatchablePrefab.transform.rotation, gridParent.transform);
                //Randomize Matchable
                _eventManager.CreateRandomizedMatchable(blankMatchablePrefab.GetComponent<SpriteRenderer>(), worldPosition);
                //Set Matchable size to grid size
                _eventManager.SetMatchableSize(blankMatchablePrefab, gridSize);
            }
        }
    }

}
