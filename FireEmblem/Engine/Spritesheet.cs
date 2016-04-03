
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace FireEmblem.Engine {

    // Stores and draws sprites from defined positions in a spritesheet
    class Spritesheet {

        private Texture2D m_texture;
        private Rectangle[] m_sprite_bounds;
        private int m_num_frames;

        private int m_width;
        private int m_height;

        // Constructor
        public Spritesheet(GraphicsDevice graphics_device, Texture2D tex, int num_frames, int tile_width, int tile_height, int tile_offset_x = 0, int tile_offset_y = 0) {

            m_texture = tex;
            m_sprite_bounds = new Rectangle[num_frames];
            int curr_sprite = 0;

            m_width = tile_width;
            m_height = tile_height;
            
            // Move on to next row if there is one
            for (int i = tile_offset_y; i < tex.Height; i += tile_height + tile_offset_y) {
                // Move on to next column if there is one
                for (int j = tile_offset_x; j < tex.Width; j += tile_width + tile_offset_x) {

                    // Break out if number of requested sprites is reached
                    if (curr_sprite == num_frames) break;

                    // Get sub texture from source texture
                    Rectangle source_rectangle = new Rectangle(j, i, tile_width, tile_height);

                    // Store in array
                    m_sprite_bounds[curr_sprite] = source_rectangle;
                    curr_sprite++;

                }

                // Break out if number of requested sprites is reached
                if (curr_sprite == num_frames) break;

            }

            this.m_num_frames = num_frames;

        }

        public int getNumFrames() {
            return m_num_frames;
        }

        public int getWidth() {
            return m_width;
        }

        public int getHeight() {
            return m_height;
        }

        // Draws the requested sprite at a given position and size
        public void Draw(SpriteBatch spriteBatch, int sprite_id, int x, int y, int scale) {

            spriteBatch.Draw(
                this.m_texture,
                new Rectangle(x * scale, y * scale, m_width * scale, m_height * scale),
                m_sprite_bounds[sprite_id],
                Color.White);

        }

    }

}
