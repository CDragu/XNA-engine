using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace SkiingGame
{
    class Particle : ParticleEmitter
    {
        private float pscale;
        private float protation;
        private Color pcolor;
        private float palpha;
        private Vector2 pVelocity;
        private Vector2 pPosition;

        public float Pscale
        {
            get { return pscale; }
            set { pscale = value; }
        }

        public float Protation
        {
            get { return protation; }
            set { protation = value; }
        }

        public float Palpha
        {
            get { return palpha; }
            set { palpha = value; }
        }

        public Color Pcolor
        {
            get { return pcolor; }
            set { pcolor = value; }
        }

        public Vector2 PVelocity
        {
            get { return pVelocity; }
            set { pVelocity = value; }
        }

        public Vector2 PPosition
        {
            get { return pPosition; }
            set { pPosition = value; }
        }

        public Particle(int maxParticleNumber, Vector2 position, float emmitingDirection, Vector2 initialVelocity, float initialVelocityTime, float particlelifetime, Texture2D texture) : base(maxParticleNumber,position,emmitingDirection,initialVelocity,initialVelocityTime,particlelifetime,texture)
        {

        }

        public override void Update()
        {

        }
        public void Draw()
        {

        }
    }
}
