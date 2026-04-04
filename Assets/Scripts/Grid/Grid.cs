using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grid<T>
{
    public event EventHandler<OnGridValueChangedEventArgs> OnGridValueChanged;
    public class OnGridValueChangedEventArgs : EventArgs
    {
        public int x;
        public int y;
    }

    private int width;
    private int height;
    private float cellSize;

    private Vector3 originPosition;

    private T[,] gridArray;

    public Grid(int width, int height, float cellSize, Vector3 originPosition, Func<Grid<T>, int, int, T> createGridObject)
    {
        this.width = width;
        this.height = height;
        this.cellSize = cellSize;
        this.originPosition = originPosition;

        gridArray = new T[width, height];
        //Drawing grid lines. This is a debug grid
        for (int x = 0; x < gridArray.GetLength(0); x++){
            for(int y = 0; y < gridArray.GetLength(1); y++)
            {
                //Draw vertical line
                Debug.DrawLine(GetWorldPosition(x, y), GetWorldPosition(x, y + 1), Color.white, 100f);
                //Draw horizontal line
                Debug.DrawLine(GetWorldPosition(x, y), GetWorldPosition(x + 1, y), Color.white, 100f);
            }
        }

        Debug.DrawLine(GetWorldPosition(0, height), GetWorldPosition(width, height), Color.white, 100f);
        Debug.DrawLine(GetWorldPosition(width, 0), GetWorldPosition(width, height), Color.white, 100f);
    }

    private Vector3 GetWorldPosition(int x, int y)
    {
        return new Vector3(x, y) * cellSize + originPosition;
    }

    public void SetGridValue(Vector3 position, T value)
    {
        int x;
        int y;  
    }

    public int GetWidth()
    {
        return width;
    }

    public int GetHeight()
    {
        return height;
    }

    public float GetCellSize()
    {
        return cellSize;
    }

    public void SetGridValue(int x, int y, T value)
    {
        if (x >= 0 && y >= 0 && x < width && y < height)
        {
            gridArray[x, y] = value;

            if (OnGridValueChanged != null)
            {
                OnGridValueChanged(this, new OnGridValueChangedEventArgs { x = x, y = y });
            }
        }
    }

    public void TriggerGridObjectChanged(int x, int y)
    {
        if (OnGridValueChanged != null)
        {
            OnGridValueChanged(this, new OnGridValueChangedEventArgs { x = x, y = y });
        }
    }

    //Convert world position to grid position
    private void GetYX(Vector3 worldPosition, out int x, out int y)
    {
        x = Mathf.FloorToInt((worldPosition - originPosition).x / cellSize);
        y = Mathf.FloorToInt((worldPosition - originPosition).y / cellSize);
    }

    public T GetGridObject(int x, int y)
    {
        if (x >= 0 && y >= 0 && x < width && y < height)
        {
            return gridArray[x, y];
        }
        else
        {
            return default(T);
        }
    }

    public T GetGridObject(Vector3 worldPosition)
    {
        int x, y;
        GetYX(worldPosition, out x, out y);
        return GetGridObject(x, y);
    }
}
