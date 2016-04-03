
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FireEmblem.Engine {

    class Animation {
        
        private Spritesheet m_spritesheet;

        private int m_offset_x;
        private int m_offset_y;

        private float m_rate;
        private float m_timer;
        private int m_current_frame;

        private int m_position_x;
        private int m_position_y;
        private int m_width;
        private int m_height;

        public Animation(Spritesheet spritesheet, float framerate = 0, int offset_x = 0, int offset_y = 0) {
            
            m_spritesheet = spritesheet;

            setFramerate(framerate);
            m_timer = 0;
            m_current_frame = 0;

            m_position_x = 0;
            m_position_y = 0;
            m_width = 0;
            m_height = 0;

            m_offset_x = offset_x;
            m_offset_y = offset_y;

        }

        public void setFramerate(float framerate) {

            if (framerate == 0) {
                m_rate = 0;
            } else {
                m_rate = (1 / framerate) * 1000;
            }

        }

        public void setFrame(int frame) {
            m_current_frame = frame;
        }

        public void setPosition(int x, int y) {
            m_position_x = x;
            m_position_y = y;
        }

        public void translate(int dx, int dy) {
            m_position_x += dx;
            m_position_y += dy;
        }

        public void setSize(int width, int height) {
            m_width = width;
            m_height = height;
        }

        public void Update(float dt) {

            if (m_rate == 0) return;

            m_timer += dt;
            while (m_timer > m_rate) {
                m_timer -= m_rate;
                m_current_frame = (m_current_frame + 1) % m_spritesheet.getNumFrames();
            }

        }

        public void Draw(SpriteBatch spritebatch, int scale) {
            m_spritesheet.Draw(spritebatch, m_current_frame, m_position_x + m_offset_x, m_position_y  + m_offset_y, scale);
        }

    }

}
