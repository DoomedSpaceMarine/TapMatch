using UnityEngine;

public class MatchableGrid
{
    public Grid<Matchable> grid;

    public MatchableGrid(int width, int height, float cellSize, Vector3 gridOriginPosition)
    {
        grid = new Grid<Matchable>(width, height, cellSize, gridOriginPosition, (Grid<Matchable> g, int x, int y) => new Matchable(g, x, y));
    }

}
