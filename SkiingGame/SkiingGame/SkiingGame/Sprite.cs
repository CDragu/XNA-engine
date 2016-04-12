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
    public class Sprite
    {
        [Serializable]
        public struct Info
        {
            public Vector2 position;
            public float scale;
            public float rotation;
            public Texture2D texture;
            public Sprite[] childlist;
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
            this.position.X += 1;
            foreach (Sprite Children in this.children)
            {
                Children.position.Y += 1;
            }
        }

        public Info Save()
        {
            Info info = new Info();
            info.position = this.position;
            info.scale = this.scale;
            info.rotation = this.scale;
            info.childlist = new Sprite[children.Count];
            for(int i=0; i< children.Count; i++)
            {
                info.childlist[i] = 
            }
            //foreach (Sprite Children in this.children)
            //{
            //    info.children.Add(Children);
            //}
            //info.texture = this.texture;
            //info.children = this.children;
            return info;
        }
        public void Load(Info info)
        {
            this.position = info.position;
            this.scale = info.scale;
            this.rotation = info.scale;
            //foreach (Sprite Children in info.children)
            //{
            //    this.children.Add(Children);
            //}
            //this.texture = info.texture;
            //this.children = info.children;
        }
    }
}
