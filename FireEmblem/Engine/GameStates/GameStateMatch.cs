
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using FireEmblem.Controller;

namespace FireEmblem.Engine.GameStates {

    class GameStateMatch : GameState {

        private Battlefield m_battlefield;
        private Animation m_selector;

        public GameStateMatch() {

            m_battlefield = new Battlefield();
            m_selector = new Animation(TextureManager.getSpritesheet(Constants.SPRITESHEET_SELECTOR), Constants.FRAMERATE_DEFAULT, 
                Constants.ANIMATION_OFFSET_X_SELECTOR, Constants.ANIMATION_OFFSET_Y_SELECTOR);

        }

        public override void Update(float dt, KeyboardState current_keyboard_state, KeyboardState previous_keyboard_state) {

            // Determine key presses
            bool RIGHT = current_keyboard_state.IsKeyDown(Keys.Right) && !previous_keyboard_state.IsKeyDown(Keys.Right);
            bool DOWN = current_keyboard_state.IsKeyDown(Keys.Down) && !previous_keyboard_state.IsKeyDown(Keys.Down);
            bool LEFT = current_keyboard_state.IsKeyDown(Keys.Left) && !previous_keyboard_state.IsKeyDown(Keys.Left);
            bool UP = current_keyboard_state.IsKeyDown(Keys.Up) && !previous_keyboard_state.IsKeyDown(Keys.Up);

            // Move cursor
            if (RIGHT) {
                m_selector.translate(Constants.SIZE_X_TILE, 0);
            }

            if (DOWN) {
                m_selector.translate(0, Constants.SIZE_Y_TILE);
            }

            if (LEFT) {
                m_selector.translate(-Constants.SIZE_X_TILE, 0);
            }

            if (UP) {
                m_selector.translate(0, -Constants.SIZE_Y_TILE);
            }

            m_selector.Update(dt);

        }

        public override void Draw(SpriteBatch spritebatch, int scale) {
            m_battlefield.getTilemap().Draw(spritebatch, scale);
            m_selector.Draw(spritebatch, scale);
        }
    }

}
