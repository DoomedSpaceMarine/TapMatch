using System;
using UnityEngine;

public class Grid
{
    //Grid Values
    private int width;
    private int height;
    private float cellSize;
    private Vector3 originPosition;
    
    //Grid that holds gameobjects
    private GameObject[,] gridArray;

    //Grid Constructor
    public Grid(int width, int height, float cellSize, Vector3 originPosition)
    {
        this.width = width;
        this.height = height;
        this.cellSize = cellSize;
        this.originPosition = originPosition;

        //Grid array is created 
        gridArray = new GameObject[width, height];

        //For drawing debug grid lines
        for (int x = 0; x < gridArray.GetLength(0); x++)
        {
            for (int y = 0; y < gridArray.GetLength(1); y++)
            {
                //Draw vertical line
                Debug.DrawLine(GetWorldPosition(x, y), GetWorldPosition(x, y + 1), Color.white, 100f);
                //Draw horizontal line
                Debug.DrawLine(GetWorldPosition(x, y), GetWorldPosition(x + 1, y), Color.white, 100f);
            }
        }

        Debug.DrawLine(GetWorldPosition(0, height), GetWorldPosition(width, height), Color.white, 100f);
        //Draw horizontal line
        Debug.DrawLine(GetWorldPosition(width, 0), GetWorldPosition(width, height), Color.white, 100f);
    }

    public Vector3 GetWorldPosition(int x, int y)
    {
        return new Vector3(x, y) * cellSize + originPosition;
    }

    //Convert world position to grid position
    private void GetXY(Vector3 worldPosition, out int x, out int y)
    {
        x = Mathf.FloorToInt((worldPosition - originPosition).x / cellSize);
        y = Mathf.FloorToInt((worldPosition - originPosition).y / cellSize);
    }

    public void SetMatchableToGrid(int x, int y, GameObject matchable)
    {
        if (x >= 0 && y >= 0 && x < width && y < height)
        {
            gridArray[x, y] = matchable;
        }
    }

    private GameObject GetValue(int x, int y)
    {
        if (x >= 0 && y >= 0 && x < width && y < height)
        {
            Debug.Log(gridArray[x, y].gameObject.tag);
            return gridArray[x, y];
        }
        else
        {
            return null;
        }
    }

    public GameObject GetMatchableFromGrid(Vector3 worldPosition)
    {
        int x;
        int y;
        GetXY(worldPosition, out x, out y);
        return GetValue(x, y);
    }

}
