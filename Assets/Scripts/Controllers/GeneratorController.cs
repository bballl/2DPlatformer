using UnityEngine;
using UnityEngine.Tilemaps;

namespace PlatformerMVC
{
    public class GeneratorController
    {
        private Tilemap _tilemap;
        private Tile _groundTile;
        private int _mapWidht;
        private int _mapHeight;
        private bool _borders;

        private int _fillPercent;
        private int _smoothFactor;

        private int[,] _map;

        private int _countWall = 4;

        public GeneratorController(GeneratorLevelView generatorLevelView)
        {
            _tilemap = generatorLevelView.Tilemap;
            _groundTile = generatorLevelView.GroundTile;
            _mapWidht = generatorLevelView.MapWidht;
            _mapHeight = generatorLevelView.MapHeight;
            _borders = generatorLevelView.Borders;
            _fillPercent = generatorLevelView.FillPercent;
            _smoothFactor = generatorLevelView.SmoothFactor;

            _map = new int[_mapWidht, _mapHeight];
        }

        public void Init()
        {
            RandomFillMap();

            for (int i = 0; i < _smoothFactor; i++)
            {
                SmoothMap();
            }
            
            DrawTiles();
        }

        private void RandomFillMap()
        {
            //float rand = Random.Range(0.00f, 0.05f);

            for (int x = 0; x < _mapWidht; x++)
            {
                for (int y = 0; y < _mapHeight; y++)
                {
                    if (x == 0 || x == _mapWidht - 1 || y == 0 || y == _mapHeight - 1)
                    {
                        if (_borders)
                        {
                            _map[x, y] = 1;
                        }
                    }
                    else
                    {
                        _map[x, y] = (Random.Range(0, 100) < _fillPercent) ? 1 : 0;
                    }
                }
            }
        }

        private void SmoothMap()
        {
            for (int x = 0; x < _mapWidht; x++)
            {
                for (int y = 0; y < _mapHeight; y++)
                {
                    int neighbourWall = GetWallCount(x,y);

                    if (neighbourWall > _countWall)
                    {
                        _map[x, y] = 1;
                    }
                    else if (neighbourWall < _countWall)
                    {
                        _map[x, y] = 0;
                    }
                }
            }
        }

        private int GetWallCount(int x, int y)
        {
            int wallCount = 0;

            for (int gridX = x -1; gridX <= x+1; gridX++)
            {
                for (int gridY = y - 1; gridY <= y + 1; gridY++)
                {
                    if (gridX >= 0 && gridX < _mapWidht && gridY >= 0 && gridY < _mapHeight)
                    {
                        if (gridX != x || gridY != y)
                        {
                            wallCount += _map[gridX, gridY];
                        }
                    }
                    else
                    {
                        wallCount++;
                    }
                }
            }

            return wallCount;
        }

        private void DrawTiles()
        {
            if (_map == null) return;

            for (int x = 0; x < _mapWidht; x++)
            {
                for (int y = 0; y < _mapHeight; y++)
                {
                    Vector3Int positionTile = new Vector3Int(-_mapWidht / 2 + x, -_mapHeight / 2 + y, 0);

                    if (_map[x,y] == 1)
                    {
                        _tilemap.SetTile(positionTile, _groundTile);
                    }
                }
            }
        }
    }
}

