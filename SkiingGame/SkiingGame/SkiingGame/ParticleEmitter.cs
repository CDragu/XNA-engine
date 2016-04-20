using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace SkiingGame
{
    class ParticleEmitter
    {
        private int maxParticleNumber;
        private Particle[] ParticleList;
        private Vector2 position;
        private float emmitingDirection;
        private Vector2 initialVelocity;
        private float initialVelocityTime;
        private float particleLifeTime;

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
            get { return initialVelocity; }
            set { initialVelocity = value; }
        }

        public float InitialVelocityTime
        {
            get { return initialVelocityTime; }
            set { initialVelocityTime = value; }
        }

        public float ParticleLifeTime
        {
            get { return particleLifeTime; }
            set { particleLifeTime = value; }
        }

        public ParticleEmitter(int maxParticleNumber, Vector2 position, float emmitingDirection, Vector2 initialVelocity, float initialVelocityTime , float particleLifeTime)
        {
            this.MaxParticleNumber = maxParticleNumber;
            this.Position = position;
            this.EmmitingDirection = emmitingDirection;
            this.InitialVelocity = initialVelocity;
            this.InitialVelocityTime = initialVelocityTime;
            this.ParticleLifeTime = particleLifeTime;
            this.ParticleList = new Particle[maxParticleNumber];
        }

        public virtual void Update()
        {
            for(int i = 0; i < maxParticleNumber; i++)
            {
                if(ParticleList[i] == null)
                {
                    Particle parti = new Particle(this.maxParticleNumber, this.position, this.emmitingDirection, this.InitialVelocity, this.initialVelocityTime, this.particleLifeTime);
                }
                if(ParticleList[i] != null && ParticleList[i].ParticleLifeTime < 0)
                {
                    ParticleList[i] = null;
                }
                ParticleList[i].Update();
                ParticleList[i].Draw();
            }
        }
    }
}
