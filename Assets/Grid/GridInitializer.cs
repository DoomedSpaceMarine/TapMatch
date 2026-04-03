using UnityEngine;

public class GridInitializer : MonoBehaviour
{
    [SerializeField] private int gridWidth;
    [SerializeField] private int gridHeight;
    [SerializeField] private float gridSize;

    void Start()
    {
        //Creating a grid based on given parameters at the start of the game
        Grid grid = new Grid(gridWidth,gridHeight, gridSize);
    }

}
