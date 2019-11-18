using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace BubbleBlower.Controles
{
    class Burbuja : Componente
    {
        #region Atributos

        private Vector2 posicion;

        private bool colisionPompa;
        private bool colisionPared;
        private int mismoColor;
        private Vector2 centro;


        #endregion

        #region Propiedades
        public float radio { get; set; }
        public Texture2D color { get; set; }
        public float velocidadX { get; set; }
        public float velocidadY { get; set; }

        #endregion

        #region Metodos     

        public Burbuja(float rad, Texture2D textura, Vector2 posicion)
        {

            this.posicion = posicion;

            this.color = textura;
            this.velocidadX = 0f;
            this.velocidadY = 0f;
            this.mismoColor = 0;
            this.colisionPared = false;
            this.colisionPompa = false;
            
        }

        public override void Actualizar(GameTime tiempo)
        {
            posicion.X += velocidadX;
            posicion.Y += velocidadY;
            centro.X=posicion.X + radio;
            centro.Y = posicion.Y + radio;

        }

        public override void Dibujar(GameTime tiempo, SpriteBatch spriteBatch)
        {
            var colour = Color.White;
            spriteBatch.Draw(color, posicion, colour);
        }
        #endregion
    }
}
