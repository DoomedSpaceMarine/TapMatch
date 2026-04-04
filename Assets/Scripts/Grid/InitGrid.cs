using UnityEngine;

public class InitGrid : MonoBehaviour
{
    //Exposed grid values for easy modification
    [SerializeField] private int gridWidth;
    [SerializeField] private int gridHeight;
    [SerializeField] private float gridCellSize;
    [SerializeField] private Vector3 originPosition;

    Grid grid;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        InitializeGrid();
    }

    private void InitializeGrid()
    {
        grid = new Grid(gridWidth, gridHeight,gridCellSize,originPosition);
    }
}
