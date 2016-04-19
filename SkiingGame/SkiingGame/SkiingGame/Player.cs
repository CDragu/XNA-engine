using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SkiingGame
{
    class Player : Sprite
    {
        public Player(Vector2 position, float scale, Texture2D texture, float rotation, float transparency, PlayField field) : base(position,scale,texture,rotation,transparency,field)
        {
            this.position = position;
            this.scale = scale;
            this.rotation = rotation;
            this.texture = texture;
            this.transparency = transparency;
            children = new List<Sprite>();
            field.Addtoplayfield(this);
            
        }


        public override void Reset(RunSequence game) { }

        public override void Update()
        {
            SetSourceRect();
            RunAnimation(10,0);
        }
    }
}
