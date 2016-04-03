
using Microsoft.Xna.Framework.Graphics;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FireEmblem.Engine {

    // Stores references to all textures used for easy access
    static class TextureManager {

        private static GraphicsDevice m_graphics_device;

        private static Dictionary<string, Texture2D> m_textures;
        private static Dictionary<string, Spritesheet> m_spritesheets;
        
        public static void init( GraphicsDevice gd, Texture2D null_tex) {

            // Save graphics device
            m_graphics_device = gd;

            // Create texture dictionary and store null texture
            m_textures = new Dictionary<string, Texture2D>();
            storeTexture(Constants.TEXTURE_NULL, null_tex);

            // Create spritesheet dictionary
            m_spritesheets = new Dictionary<string, Spritesheet>();

        }

        // Store a texture
        public static void storeTexture( string key, Texture2D tex ) {
            m_textures.Add(key, tex);
        }

        // Gets requested texture
        // Returns null texture if not found
        public static Texture2D getTexture(string key) {
            if (m_textures.ContainsKey(key)) {
                return m_textures[key];
            }
            return m_textures[Constants.TEXTURE_NULL];
        }

        // Create a new spritesheet
        public static void createSpritesheet(string key, Texture2D tex, int num_sprites, int tile_width, int tile_height, int tile_offset_x = 0, int tile_offset_y = 0) {
            Spritesheet sprite_sheet = new Spritesheet(m_graphics_device, tex, num_sprites, tile_width, tile_height, tile_offset_x, tile_offset_y);
            m_spritesheets.Add(key, sprite_sheet);
        }

        // Gets requested spritesheet
        // Returns null if not found
        public static Spritesheet getSpritesheet( string key ) {
            if (m_spritesheets.ContainsKey(key)) {
                return m_spritesheets[key];
            }
            return null;
        }

    }

}
