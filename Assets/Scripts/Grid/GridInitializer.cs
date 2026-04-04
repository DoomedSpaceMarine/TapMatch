using UnityEngine;

public class GridInitializer : MonoBehaviour
{
    [SerializeField] private int gridWidth;
    [SerializeField] private int gridHeight;
    [SerializeField] private float gridSize;
    [SerializeField] private Vector3 gridOriginPosition;

    void Start()
    {
        //Creating a grid based on given parameters at the start of the game
        MatchableGrid grid = new MatchableGrid(gridWidth, gridHeight, gridSize, gridOriginPosition);
    }

}
