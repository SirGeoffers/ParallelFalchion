
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using FireEmblem.Engine;

namespace FireEmblem.Controller {

    class Battlefield {

        private Tilemap m_tilemap;
        private Animation m_selector;

        public Battlefield() {

            m_tilemap = new Tilemap(TextureManager.getSpritesheet(Constants.SPRITESHEET_MAP));
            int[,] tempMap = {
                { 0, 8, 7, 0},
                { 1, 0, 0, 6},
                { 2, 9, 0, 5},
                { 0, 3, 4, 0}
            };
            m_tilemap.setMap(tempMap);

            m_selector = new Animation(TextureManager.getSpritesheet(Constants.SPRITESHEET_SELECTOR),
                Constants.FRAMERATE_DEFAULT, Constants.ANIMATION_OFFSET_X_SELECTOR, Constants.ANIMATION_OFFSET_Y_SELECTOR);
            m_selector.setSize(24, 26);
            m_selector.setPosition(Constants.SIZE_X_TILE, Constants.SIZE_Y_TILE);

        }

        public Tilemap getTilemap() {
            return m_tilemap;
        }

    }

}
