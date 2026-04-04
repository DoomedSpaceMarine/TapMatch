using UnityEngine;

public class MatchableGrid
{
    private Grid<MatchableGridObject> grid;

    public MatchableGrid(int width, int height, float cellSize, Vector3 gridOriginPosition)
    {
        grid = new Grid<MatchableGridObject>(width, height, cellSize, gridOriginPosition, (Grid<MatchableGridObject> g, int x, int y) => new MatchableGridObject(g, x, y));
    }

   /* public void SetTileMapSprite(Vector3 worldPosition, TileMapObject.TileMapSprite tileMapSprite)
    {
        TileMapObject tileMapObject = grid.GetGridObject(worldPosition);
        if (tileMapObject != null)
        {
            tileMapObject.SetTileMapSprite(tileMapSprite);
        }
    }

    public void SetTileMapVisual(TileMapVisual tileMapVisual)
    {
        tileMapVisual.SetGrid(grid);
    }*/

    public class MatchableGridObject
    {
        public enum TileMapSprite
        {
            None,
            Ground
        }

        private Grid<MatchableGridObject> grid;
        private int x;
        private int y;
        private TileMapSprite tileMapSprite;

        public MatchableGridObject(Grid<MatchableGridObject> grid, int x, int y)
        {
            this.grid = grid;
            this.x = x;
            this.y = y;
        }

        public void SetTileMapSprite(TileMapSprite tileMapSprite)
        {
            this.tileMapSprite = tileMapSprite;
            grid.TriggerGridObjectChanged(x, y);
        }

        public TileMapSprite GetTileMapSprite()
        {
            return tileMapSprite;
        }

        public override string ToString()
        {
            return tileMapSprite.ToString();
        }
    }
}
