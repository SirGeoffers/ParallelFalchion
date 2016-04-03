
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FireEmblem.Engine.GameStates {

    public class GameStateManager {

        private Stack<GameState> m_states;

        public GameStateManager() {
            m_states = new Stack<GameState>();
        }

        public void pushState(GameState state) {
            m_states.Push(state);
        }

        public void popState() {
            if (m_states.Count != 0) {
                m_states.Pop();
            }
        }

        public void changeState(GameState state) {
            popState();
            pushState(state);
        }

        public void Update(float dt, KeyboardState current_keyboard_state, KeyboardState previous_keyboard_state) {
            m_states.Peek().Update(dt, current_keyboard_state, previous_keyboard_state);
        }

        public void Draw(SpriteBatch spritebatch, int scale) {
            m_states.Peek().Draw(spritebatch, scale);
        }

    }

}
