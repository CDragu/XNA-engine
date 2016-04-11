using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace SkiingGame
{
    class Sprite
    {
        public struct Info
        {
            public Vector2 position;
            public float scale;
            public float rotation;
            public Texture2D texture;
            public List<Sprite> children;
        }
        public Vector2 position;
        public float scale;
        public float rotation;
        public float transparency;
        public Texture2D texture;
        public List<Sprite> children;
        
        public Sprite(Vector2 position, float scale, Texture2D texture, float rotation, float transparency)
        {            
            this.position = position;
            this.scale = scale;
            this.rotation = rotation;
            this.texture = texture;
            this.transparency = transparency;
            children = new List<Sprite>();
            
        }
        public Sprite(Vector2 position, float scale, Texture2D texture,float rotation)
            : this(position, scale, texture, rotation,1f)
        {
        }
        public Sprite(Vector2 position, float scale, Texture2D texture)
            :this(position,scale,texture,0f,1f)
        {
        }
        public Sprite(Vector2 position, Texture2D texture)
            : this(position, 1f, texture, 0f, 1f)
        {
        }
        public Sprite( Texture2D texture)
            : this(Vector2.Zero, 1f, texture, 0f, 1f)
        {
        }


        public virtual void Draw(SpriteBatch spriteBatch) {
          
            spriteBatch.Draw(texture, position, null, Color.White * transparency, rotation, Vector2.Zero, scale, SpriteEffects.None, 0f);
            foreach (Sprite Children in this.children)
            {
                Vector2 ChildPosition = new Vector2(this.position.X + Children.position.X, this.position.Y + Children.position.Y);
                spriteBatch.Draw(Children.texture, ChildPosition,null, Color.White * Children.transparency, Children.rotation,Vector2.Zero,Children.scale,SpriteEffects.None,0f);
            }            
        }

        public virtual void Reset(RunSequence game) { }

        public virtual void Update()
        {
            
        }

        public Info Save()
        {
            Info info = new Info();
            info.position = this.position;
            info.scale = this.scale;
            info.rotation = this.scale;
            info.texture = this.texture;
            info.children = this.children;
            return info;
        }
    }
}
