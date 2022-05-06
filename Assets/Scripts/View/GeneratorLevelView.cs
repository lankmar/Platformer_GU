using System.Collections;
using UnityEngine;
using UnityEngine.Tilemaps;
namespace Platformer.View
{
    public class GeneratorLevelView : MonoBehaviour
    {
        [SerializeField] private Tilemap _tilemap;
        [SerializeField] private Tile _groundTile;
        [SerializeField] private int _mapHeight;
        [SerializeField] private int _mapWidht;
        [SerializeField] private bool _borders;
        [SerializeField] [Range(0, 100)] private int _fillPercent;
        [SerializeField] [Range(0, 100)] private int _factorPercent;

        public Tilemap Tilemap { get => _tilemap; set => _tilemap = value; }
        public Tile GroundTile { get => _groundTile; set => _groundTile = value; }
        public int MapHeight { get => _mapHeight; set => _mapHeight = value; }
        public int MapWidht { get => _mapWidht; set => _mapWidht = value; }
        public bool Borders { get => _borders; set => _borders = value; }
        public int FillPercent { get => _fillPercent; set => _fillPercent = value; }
        public int FactorPercent { get => _factorPercent; set => _factorPercent = value; }
    }
}