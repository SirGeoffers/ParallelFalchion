
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FireEmblem.Engine {

    // A Tilemap used for displaying a spritesheet in a tiled pattern
    class Tilemap {

        private Spritesheet m_spritesheet;
        private int m_tile_width;
        private int m_tile_height;

        private int[,] m_map;
        private int m_map_x;
        private int m_map_y;
        private int m_map_width;
        private int m_map_height;

        // Constructor
        public Tilemap(Spritesheet spritesheet) {

            // Set variables
            m_spritesheet = spritesheet;
            m_tile_width = spritesheet.getWidth();
            m_tile_height = spritesheet.getHeight();

            // Initialize map
            m_map = new int[0, 0];
            m_map_x = 0;
            m_map_y = 0;

        }

        // Sets the map to be drawn
        // Also stores the map's width and height
        public void setMap(int[,] map) {
            m_map = map;
            m_map_width = m_map.GetLength(1);
            m_map_height = m_map.GetLength(0);
        }

        public void setPosition(int x, int y) {
            m_map_x = x;
            m_map_y = y;
        }

        // Draws the map to the screen
        public void Draw(SpriteBatch spriteBatch, int scale) {

            // For each row
            for (int row = 0; row < m_map_height; row++) {
                // For each column
                for (int col = 0; col < m_map_width; col++) {
                    // Draw the sprite at its location
                    m_spritesheet.Draw(
                        spriteBatch, 
                        m_map[row, col], 
                        m_map_x + col * m_tile_width, 
                        m_map_y + row * m_tile_height, 
                        scale);
                }
            }

        }

    }

}
