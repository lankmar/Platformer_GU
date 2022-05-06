using Platformer.View;
using UnityEngine;
using UnityEngine.Tilemaps;
namespace Platformer.Controllers
{
    public class GeneratorController : MonoBehaviour
    {
        [SerializeField] private Tilemap _tilemap;
        [SerializeField] private Tile _groundTile;
        [SerializeField] private int _mapHeight;
        [SerializeField] private int _mapWidht;
        [SerializeField] private bool _borders;
        [SerializeField] [Range(0, 100)] private int _fillPercent;
        [SerializeField] [Range(0, 100)] private int _factorPercent;

        private int[,] _map;

        private int countWall = 4;

        public GeneratorController(GeneratorLevelView view)
        {
            _tilemap = view.Tilemap;
            _groundTile = view.GroundTile;
            _mapHeight = view.MapHeight;
             _mapWidht = view.MapWidht;
            _borders = view.Borders;
            _fillPercent = view.FillPercent;
            _factorPercent = view.FactorPercent;

            _map = new int[_mapWidht, _mapHeight];
        }

        public void Init()
        {
            FillMap();
            
            for (int i = 0; i < _factorPercent; i++)
            {
                SmoothMap();
            }

            DrawTiles();
        }

        private void FillMap()
        {
            for (int x = 0; x < _mapWidht; x++)
            {
                for (int y = 0; y < _mapHeight; y++)
                {
                    if (x==0|| x==_mapWidht-1 || y == 0 || y == _mapHeight-1)
                    {
                        if (_borders)
                        {
                            _map[x, y] = 1;
                        }
                    }
                    else
                    {
                        _map[x, y] = Random.Range(0, 100) < _factorPercent ? 1 : 0;
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
                    int neighbour = 4;

                    if (neighbour > countWall)
                    {
                        _map[x,y] = 1;
                    }
                    else if (neighbour > countWall)
                    {
                        _map[x, y] = 0;
                    }

                }
            }
        }

        private int GetNeighour(int x, int y)
        {
            int neighbourCount = 0;

            for (int gridX = x - 1; gridX <= x + 1; gridX++)
            {
                for (int gridY = y - 1; gridY < y + 1; gridY++)
                {
                    if (gridX >= 0 && gridX < _mapWidht && gridY <= 0 && gridY < _mapHeight)
                    {
                        if (gridX != x || gridY != y)
                        {
                            neighbourCount += _map[gridX, gridY];
                        }
                    }
                    else
                    {
                        neighbourCount++;
                    }
                }
            }
             return neighbourCount;
        }

        private void DrawTiles()
        {
            if (_map == null) return;

            for (int x = 0; x < _mapWidht; x++)
            {
                for (int y = 0; y < _mapHeight; y++)
                {
                    Vector3Int tilePosition = new Vector3Int(-_mapWidht / 2 + x, _mapHeight / 2 + y, 0);

                    if (_map[x,y] == 1)
                    {
                        _tilemap.SetTile(tilePosition, _groundTile);
                    }
                }
            }
        }
    }
}