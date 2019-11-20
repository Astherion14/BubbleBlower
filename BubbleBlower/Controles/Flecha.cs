using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace BubbleBlower.Controles
{
    class Flecha : Componente
    {
        private Texture2D textura;

        private float rotacion;

        public Vector2 posicion;


        public Vector2 origen;

        public float vAngular = 3f;


        public Flecha(Texture2D texture)
        {
            textura = texture;
        }


        public double getRotacion()
        {
            double rot = this.rotacion;
            return rot;
        }
        public override void Actualizar(GameTime tiempo)
        {

            if (Keyboard.GetState().IsKeyDown(Keys.A))
            {
                if (rotacion>= -1.55f)
                {
                    rotacion -= MathHelper.ToRadians(vAngular);
                }
                if (rotacion <= -1.55f)
                {
                    rotacion = -1.55f;
                }
            }

            else if (Keyboard.GetState().IsKeyDown(Keys.D))
            {
                if (rotacion <= 1.55f)
                {
                    rotacion += MathHelper.ToRadians(vAngular);
                }
                if (rotacion>= 1.55f)
                {
                    rotacion = 1.55f;
                }
            }

            var direccion = new Vector2((float)Math.Cos(MathHelper.ToRadians(90) - rotacion), -(float)Math.Sin(MathHelper.ToRadians(90) - rotacion));

 
        }

        public override void Dibujar(GameTime tiempo, SpriteBatch sprite)
        {
            sprite.Draw(textura, posicion, null, Color.White, rotacion, origen, 1, SpriteEffects.None, 0f);
        }
    }
}
