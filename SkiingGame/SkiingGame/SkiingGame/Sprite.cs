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
        public Vector2 position;
        public float scale;
        public Texture2D texture;
        public List<Sprite> children;
        
        public Sprite(Vector2 position, float scale, Texture2D texture)
        {
            this.position = position;
            this.scale = scale;
            this.texture = texture;
            
            children = new List<Sprite>();
            
        }

        public virtual void Draw(SpriteBatch spriteBatch) {
          
            spriteBatch.Draw(texture, position, null, Color.White, 0f, Vector2.Zero, scale, SpriteEffects.None, 0f);
            foreach (Sprite Children in this.children)
            {
                Vector2 ChildPosition = new Vector2(this.position.X + Children.position.X, this.position.Y + Children.position.Y);
                spriteBatch.Draw(Children.texture, ChildPosition,null, Color.White,0f,Vector2.Zero,Children.scale,SpriteEffects.None,0f);
            }            
        }

        public virtual void Reset(RunSequence game) { }

        public virtual void Update(RunSequence game) { }
        public override string ToString()
        {
            string Temp = this.position.ToString() +" "+ "S:" + this.scale +" "+ "T:" + this.texture.Name;
            return Temp;
        }

        public void Save()
        {
            StreamWriter Save = new StreamWriter("...\\TEST.txt");
            Save.WriteLine(ToString());          
            Save.Close();
        }
        public void Load()
        {
            Vector2 position = Vector2.Zero;
            float scale = 0;
            string texture = "";

            StreamReader sr = new StreamReader("...\\TEST.txt");            
            string Raw = sr.ReadLine();
            bool fin = false;
            int i = 0;
            while (fin == true)
            {
                if (Raw[i] == 'X' && Raw[i + 1] == ':')
                {
                    string test = "";
                    while (Raw[i] != ' ')
                        test += Raw[i];
                    position.X = float.Parse(test);
                 }
                if (Raw[i] == 'Y' && Raw[i + 1] == ':')
                {
                    string test = "";
                    while (Raw[i] != '}')
                        test += Raw[i];
                    position.Y = float.Parse(test);
                }
                if (Raw[i] == 'S' && Raw[i + 1] == ':')
                {
                    string test = "";
                    while (Raw[i] != ' ')
                        test += Raw[i];
                    scale = float.Parse(test);
                }
                if (Raw[i] == 'T' && Raw[i + 1] == ':')
                {
                    string test = "";
                    while (Raw[i] != ' ')
                        test += Raw[i];
                    texture = test;
                }

                i++;
            }
            //new Sprite(position, scale, flagRighttexture, texture);

            ////Continue to read until you reach end of file
            //while (line != null)
            //{
            //    //write the lie to console window
            //    Console.WriteLine(line);
            //    //Read the next line
            //    line = sr.ReadLine();
            //}           
            sr.Close();
        }
    }
}
