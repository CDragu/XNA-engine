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
        }

        
        private Vector2 position;
        private float scale;
        private float rotation;
        private float transparency;
        private Texture2D texture;
        public List<Sprite> children;

        public Vector2 Position
        {
            get { return position; }
            set { position = value; }
        }

        public float Scale
        {
            get { return scale; }
            set { scale = value; }
        }

        public float Rotation
        {
            get { return rotation; }
            set { rotation = value; }
        }

        public float Transparency
        {
            get { return transparency; }
            set { transparency = value; }
        }

        public Texture2D Texture
        {
            get { return texture; }
            set { texture = value; }
        }



        public Sprite(Vector2 position, float scale, Texture2D texture, float rotation, float transparency, PlayField field)
        {            
            this.position = position;
            this.scale = scale;
            this.rotation = rotation;
            this.texture = texture;
            this.transparency = transparency;
            children = new List<Sprite>();
            field.Addtoplayfield(this);
        }
        public Sprite(Vector2 position, float scale, Texture2D texture,float rotation, PlayField field)
            : this(position, scale, texture, rotation,1f, field)
        {
            
        }
        public Sprite(Vector2 position, float scale, Texture2D texture, PlayField field)
            :this(position,scale,texture,0f,1f, field)
        {
        }
        public Sprite(Vector2 position, Texture2D texture, PlayField field)
            : this(position, 1f, texture, 0f, 1f, field)
        {
        }
        public Sprite( Texture2D texture, PlayField field)
            : this(Vector2.Zero, 1f, texture, 0f, 1f, field)
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
            info.rotation = this.rotation;
            return info;
        }
        public void Load(Info info)
        {
            this.position = info.position;
            this.scale = info.scale;
            this.rotation = info.rotation;
        }
        //Animation Stuff
        
        private int currentFrame = 0;
        private int spriteWidth = 32;
        private int spriteHeight = 48;
        private float spriteSpeed = 0.2f;
        private double time = 0;
        private float frameduration = 0.16f;
        
        private Rectangle sourceRect;

        public void SetSourceRect()
        {
            sourceRect = new Rectangle(currentFrame * spriteWidth, 0, spriteWidth, spriteHeight);
        }

        public void InitializeAnimation(int spriteWidth, int spriteHeight, float spriteSpeed, float frameduration)
        {
            this.spriteWidth = spriteWidth;
            this.spriteHeight = spriteHeight;
            this.spriteSpeed = spriteSpeed;
            this.frameduration = frameduration;
        }
        /// <summary>
        /// Runs an animation that takes totalduration frames and starts form starting frame. frameduratin is for time
        /// </summary>
        /// <param name="startingframe"></param>
        /// <param name="totalduration"></param>
        /// <param name="frameduration"></param>
        public void RunAnimation(int startingframe ,int totalduration, float frameduration)
        {
            time = time + 0.16f;//to do: change to time till last update
            if(currentFrame < startingframe)
            {
                currentFrame = startingframe;
            }
            if(time > frameduration)
            {
                currentFrame++;
                SetSourceRect();
                time = 0;
            }
            if(currentFrame > totalduration)
            {
                currentFrame = startingframe;
                SetSourceRect();
            }

        }
        public void UpdateAnimation(int currentframe)
        {
            this.currentFrame = currentframe;
            SetSourceRect();
        }

        public virtual void DrawWithAnimation(SpriteBatch spriteBatch)
        {

            spriteBatch.Draw(texture, position, sourceRect, Color.White * transparency, rotation, Vector2.Zero, scale, SpriteEffects.None, 0f);
            foreach (Sprite Children in this.children)
            {
                Vector2 ChildPosition = new Vector2(this.position.X + Children.position.X, this.position.Y + Children.position.Y);
                spriteBatch.Draw(Children.texture, ChildPosition, Children.sourceRect, Color.White * Children.transparency, Children.rotation, Vector2.Zero, Children.scale, SpriteEffects.None, 0f);
            }
        }

        
    }
}
