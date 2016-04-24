using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using Microsoft.Xna.Framework.Storage;
using System.IO;

namespace XnaEngine
{
   
    public class RunSequence : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        public PlayField field;

        public RunSequence()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

       
        protected override void Initialize()
        {
            base.Initialize();
        }

       
        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);

            field = new PlayField();                        
        }
       
        protected override void UnloadContent()
        {           
        }
       
        protected override void Update(GameTime gameTime)
        {            
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                this.Exit();

            base.Update(gameTime);
        }

       
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Green);

            spriteBatch.Begin();            
            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
