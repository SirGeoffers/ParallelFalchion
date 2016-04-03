using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FireEmblem.Engine {

    // Holds constants for specific variables
    static class Constants {

        // Values
        public static int SCALE_DEFAULT = 2;
        public static int FRAMERATE_DEFAULT = 30;

        public static int SIZE_X_TILE = 16;
        public static int SIZE_Y_TILE = 16;
        public static int OFFSET_X_TILE = 1;
        public static int OFFSET_Y_TILE = 1;

        public static int SIZE_X_SELECTOR = 20;
        public static int SIZE_Y_SELECTOR = 21;
        public static int OFFSET_X_SELECTOR = 1;
        public static int OFFSET_Y_SELECTOR = 1;
        public static int ANIMATION_OFFSET_X_SELECTOR = -2;
        public static int ANIMATION_OFFSET_Y_SELECTOR = -2;

        // Files
        public static string FILE_TEXTURE_NULL = "sprites/null_texture";
        public static string FILE_TEXTURE_MAP = "sprites/map/mapsprites";
        public static string FILE_TEXTURE_SELECTOR = "sprites/map/selector";
        public static string FILE_TEXTURE_SELECTOR_STATIC = "sprites/map/selector_static";

        // Textures
        public static string TEXTURE_NULL = "texture_null";
        public static string TEXTURE_MAP = "texture_map";
        public static string TEXTURE_SELECTOR = "texture_selector";
        public static string TEXTURE_SELECTOR_STATIC = "texture_selector_static";

        // Spritesheets
        public static string SPRITESHEET_MAP = "spritesheet_map";
        public static int NUMSPRITES_MAP = 1000;

        public static string SPRITESHEET_SELECTOR = "spritesheet_selector";
        public static int NUMSPRITES_SELECTOR = 15;

    }

}
