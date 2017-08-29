using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Minesweeper2D
{
    public class Tile : MonoBehaviour
    {
        //store x and y coordinate in array for later use
        public int x = 0;
        public int y = 0;
        public bool isMine = false; // is this tile a mine
        public bool isRevealed = false; // has the tile been revealed?
        [Header("Refrences")]
        public Sprite[] emptySprites; // List of empty sprites (as an array)
        public Sprite[] mineSprites; // The mine sprites

        private SpriteRenderer rend; // refrence to sprite renderer
                                     // Use this for initialization
        void Awake()
        {
            //Grab refrence to sprite renderer
            rend = GetComponent<SpriteRenderer>();
        }
        void Start()
        {
            //Decide if the tile is a mine or not
            isMine = Random.value < .05f;
        }

        // Update is called once per frame
        void Update()
        {

        }
        public void Reveal(int adjacentMines, int mineState = 0)
        {
            // Flags the tile as being revealed
            isRevealed = true;
            //checks if the tile is a mine
            if(isMine)
            {
                //sets sprite to mine sprite
                rend.sprite = mineSprites[mineState];
            }
            else
            {
                //Sets sprite to appropriate texture based on adjacent mines
                rend.sprite = emptySprites[adjacentMines];
            }
        }
    }
}
