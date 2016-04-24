﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace XnaEngine
{
    class PhysicsObject : Sprite
    {
        private bool ground;
        private Rectangle hitbox;
        public bool Ground
        {
            get { return ground; }
            set { ground = value; }
        }

        public PhysicsObject(Vector2 position, float scale, Texture2D texture, float rotation, float transparency, PlayField field) : base(position, scale, texture, rotation, transparency, field)
        {
            this.Position = position;
            this.Scale = scale;
            this.Rotation = rotation;
            this.Texture = texture;
            this.Transparency = transparency;
            this.Ground = ground;
            children = new List<Sprite>();
            field.Addtoplayfield(this);
            hitbox = new Rectangle((int)position.X, (int)position.Y, (int)Math.Ceiling(texture.Width*scale), (int)Math.Ceiling(texture.Height*scale));
        }
        public override void Update()
        {
            hitbox = new Rectangle((int)Position.X, (int)Position.Y, (int)Math.Ceiling(Texture.Width * Scale), (int)Math.Ceiling(Texture.Height * Scale));
        }
        public void PhysicsUpdate(PhysicsObject obj1, PhysicsObject obj2)
        {
                if (obj1.hitbox.Intersects(obj2.hitbox))
                {
                Collision(obj1,obj2);
                }            
        }
        public void Collision(PhysicsObject Obj1, PhysicsObject Obj2)//override this
        {
            Obj1.Position += new Vector2(0, -2);
        }
    }
}

