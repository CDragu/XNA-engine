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

namespace SkiingGame
{
   
    public class RunSequence : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        Texture2D flagRighttexture;
        Texture2D flagLefttexture;
        Texture2D skyMantexture;
        Texture2D knighttexture;
        
        Stream soundfile;
        SoundEffect soundEffect;
        SoundEffectInstance soundEffectInstance;

        Sprite skyMan;
        Sprite SoundGhost;
        Player knight;
        PhysicsObject Obj1, Obj2;

        public PlayField field;

        public RunSequence()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

       
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            base.Initialize();
        }

       
        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);

            field = new PlayField();

            flagRighttexture = Content.Load<Texture2D>("LeftBlueflag");
            flagLefttexture = Content.Load<Texture2D>("leftRedFlag");
            skyMantexture = Content.Load<Texture2D>("Skier");
            knighttexture = Content.Load<Texture2D>("knightspritesheet");


            System.IO.FileStream fs = new System.IO.FileStream(@"C:\Users\cosminddragu\Source\Repos\SkiingGame\SkiingGame\SkiingGame\SkiingGameContent\buzz.wav", System.IO.FileMode.Open); //needs to be reworked, was not working with simple load content
            SoundEffect mysound = SoundEffect.FromStream(fs);
            fs.Dispose();


            //soundfile = TitleContainer.OpenStream(@"Content\buzz.wav");
            //soundEffect = SoundEffect.FromStream(soundfile);
            soundEffectInstance = mysound.CreateInstance();

            skyMan = new Sprite(Vector2.Zero , 0.5f, flagRighttexture,-0.2f,0.2f,field);
            skyMan.children.Add(new Sprite(new Vector2(400f,0f), 0.2f, flagLefttexture,-0.1f,field));
            knight = new Player(new Vector2(200f,200f), 1, knighttexture, 0, 1f, field);
            Obj1 = new PhysicsObject(new Vector2(250f, 250f), 0.1f, flagRighttexture, 0, 1f, field);
            Obj2 = new PhysicsObject(new Vector2(250f, 280f), 0.1f, flagLefttexture, 0, 1f, field);
            SoundGhost = new Sprite(new Vector2(100f, 100f), 0.5f, flagRighttexture, soundEffectInstance, -0.2f, 0.2f, field);
        }

       
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

       
        protected override void Update(GameTime gameTime)
        {
            // Allows the game to exit
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                this.Exit();
            KeyboardState keyboard = Keyboard.GetState();
            skyMan.Update();
            knight.Update();
            Obj1.Update();
            
            Obj2.Update();
            Obj1.PhysicsUpdate(Obj1, Obj2);
            if (keyboard.IsKeyDown(Keys.J))
            {
                
                Obj1.Position = Obj1.Position + new Vector2(0, 1);
            }
            if (keyboard.IsKeyDown(Keys.U))
            {

                Obj1.Position = Obj1.Position + new Vector2(0, -1);
            }

            if (keyboard.IsKeyDown(Keys.S))
            {

                SaveLoad save = new SaveLoad(field,"SAVE");
            }
            if (keyboard.IsKeyDown(Keys.L))
            {

                SaveLoad load = new SaveLoad(field,"LOAD");
                field = load.AfterLoad();
                
            }
            SoundGhost.Update();

            base.Update(gameTime);
        }

       
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            spriteBatch.Begin();
            skyMan.Draw(spriteBatch);
            knight.DrawWithAnimation(spriteBatch);
            Obj1.Draw(spriteBatch);
            Obj2.Draw(spriteBatch);
            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
