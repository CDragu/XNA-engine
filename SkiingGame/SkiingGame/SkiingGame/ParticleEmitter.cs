using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace SkiingGame
{
    class ParticleEmitter
    {
        private int maxParticleNumber;
        private Particle[] ParticleList;
        private Vector2 position;
        private float emmitingDirection;

        private Texture2D pTexture;
        private Vector2 pinitialVelocity;
        private float pinitialVelocityTime;
        private float pLifeTime;

        Particle parti;

        


        public int MaxParticleNumber
        {
            get { return maxParticleNumber; }
            set { maxParticleNumber = value; }
        }

        public Vector2 Position
        {
            get { return position; }
            set { position = value; }
        }

        public float EmmitingDirection
        {
            get { return emmitingDirection; }
            set { emmitingDirection = value; }
        }

        public Vector2 InitialVelocity
        {
            get { return pinitialVelocity; }
            set { pinitialVelocity = value; }
        }

        public float InitialVelocityTime
        {
            get { return pinitialVelocityTime; }
            set { pinitialVelocityTime = value; }
        }

        public float ParticleLifeTime
        {
            get { return pLifeTime; }
            set { pLifeTime = value; }
        }

        public Texture2D PTexture
        {
            get { return pTexture; }
            set { pTexture = value; }
        }

        public ParticleEmitter(int maxParticleNumber, Vector2 position, float emmitingDirection, Vector2 initialVelocity, float initialVelocityTime , float particleLifeTime, Texture2D texture)
        {
            this.MaxParticleNumber = maxParticleNumber;
            this.Position = position;
            this.EmmitingDirection = emmitingDirection;
            this.InitialVelocity = initialVelocity;
            this.InitialVelocityTime = initialVelocityTime;
            this.ParticleLifeTime = particleLifeTime;
            this.ParticleList = new Particle[maxParticleNumber];
            this.PTexture = texture;
        }

        public virtual void Update()
        {
            for(int i = 0; i < maxParticleNumber; i++)
            {
                if(ParticleList[i] == null)
                {
                    ParticleList[i] = new Particle(this.maxParticleNumber, this.position, this.emmitingDirection, this.InitialVelocity, this.pinitialVelocityTime, this.pLifeTime,this.PTexture);
                }
                ParticleList[i].Update();
                if(ParticleList[i] != null && ParticleList[i].ParticleLifeTime < 0)
                {
                    ParticleList[i] = null;
                }
                
               
            }
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            for (int i = 0; i < maxParticleNumber; i++)
            {
                if (ParticleList[i] != null)
                {
                    ParticleList[i].Draw(spriteBatch);
                }
            }
               
        }
    }
}
