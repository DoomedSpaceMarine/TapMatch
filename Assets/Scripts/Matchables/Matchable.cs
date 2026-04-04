using UnityEngine;
using static MatchableGrid;

[System.Serializable]
public class Matchable
{
    public Color matchableColor;
    public string matchableName;
    private bool isEmpty;

    private Grid<Matchable> grid;
    private int x;
    private int y;

    public Matchable(Grid<Matchable> grid, int x, int y)
    {
        this.grid = grid;
        this.x = x;
        this.y = y;
    }
}
