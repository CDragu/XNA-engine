using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace SkiingGame
{
    class Particle : ParticleEmitter
    {
       

        public Particle(int maxParticleNumber, Vector2 position, float emmitingDirection, Vector2 initialVelocity, float initialVelocityTime, float particlelifetime) : base(maxParticleNumber,position,emmitingDirection,initialVelocity,initialVelocityTime,particlelifetime)
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
