using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BubbleBlower.Estados
{
    public abstract class Estado
    {
        #region Atributos
        protected ContentManager contenido;

        protected GraphicsDevice graficos;

        protected Game1 juego;

        #endregion

        #region Metodos

        public abstract void Dibujar(GameTime tiempo, SpriteBatch spriteBatch);

        public abstract void PosActualizado(GameTime tiempo);

        public Estado(Game1 juego, GraphicsDevice graficos, ContentManager contenido)
        {
            this.juego = juego;

            this.graficos = graficos;

            this.contenido = contenido;
        }

        public abstract void Actualizar(GameTime tiempo);

        #endregion
    }
}
