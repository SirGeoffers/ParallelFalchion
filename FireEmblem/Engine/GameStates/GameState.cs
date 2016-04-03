
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FireEmblem.Engine.GameStates {

    public abstract class GameState {

        public abstract void Update(float dt, KeyboardState current_keyboard_state, KeyboardState previous_keyboard_state);
        public abstract void Draw(SpriteBatch spritebatch, int scale);

    }

}
