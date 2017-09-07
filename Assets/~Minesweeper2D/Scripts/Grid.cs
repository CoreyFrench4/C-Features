using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Minesweeper2D
{
    public class Grid : MonoBehaviour
    {
        public GameObject tilePrefab;
        public int width = 10;
        public int height = 10;
        public float spacing = .155f;
        public float offset = .1f;
        private Tile[,] tiles;
        Tile SpawnTile(Vector3 pos)
        {
            //Clone tile prefab
            GameObject clone = Instantiate(tilePrefab);
            clone.transform.position = pos; // position tile
            Tile currentTile = clone.GetComponent<Tile>(); // Get Tile component
            return currentTile; // return it
        }
        void GenerateTiles()
        {
            //creat new 2d array of size width * height
            tiles = new Tile[width, height];

            //loop throught the entire tile list
            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    // >> Part 2 goes here
                    Vector2 halfSize = new Vector2(width / 2, height / 2);
                    // Pivot tiles around Grid
                    Vector2 pos = new Vector2(x - halfSize.x,
                        y - halfSize.y);
                    pos *= spacing;
                    //spawn the tile
                    Tile tile = SpawnTile(pos);
                    // Attach newly spawned tile to
                    tile.transform.SetParent(transform);
                    //Store it's array coordinates within itself for future refrence
                    tile.x = x;
                    tile.y = y;
                    //store tile in array at those coordinates
                    tiles[x, y] = tile;
                }
            }

        }
        // Use this for initialization
        void Start()
        {
            GenerateTiles();
        }
        public void ScreenMouseRay()
        {
            Vector3 mousePosition = Input.mousePosition;
            mousePosition.z = Mathf.Infinity;

            //RaycastHit2D hit = Physics2D.Raycast(Input.mousePosition ,Vector2.zero,Mathf.Infinity); //Hit object that contains gameobject Information
            RaycastHit2D hit = Physics2D.Raycast(mousePosition, mousePosition - Camera.main.ScreenToWorldPoint(mousePosition), Mathf.Infinity);

            Debug.DrawRay(mousePosition, mousePosition - Camera.main.ScreenToWorldPoint(mousePosition), Color.blue);
            if (hit)
            {
             
                if (gameObject.CompareTag("Tile"))
                {
                    gameObject.SetActive(false);

                    Debug.Log("this works");
                }
            }
        }
        
        void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                ScreenMouseRay();
                
            }
        }
        public int GetAdjacentMineCount(Tile t)
        {
            int count = 0;
            //Loop through all elements and have each axis go between -1 to 1
            for (int x = -1; x <= 1; x++)
            {
                //Calculate desired coordinates from one attained
                int desiredX = t.x + x;
                //IF desiredX is within range of tiles array length
                //IF the element at index is a mine
                // Increment count by 1
            }
            return count;
        }
    }
}
