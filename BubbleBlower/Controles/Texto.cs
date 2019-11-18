using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace BubbleBlower.Controles
{
    public class Texto : Componente
    {
        #region Atributos
        private SpriteFont fuente;
        private string contenido;
        #endregion

        #region Propiedades
        public Color ColorDibujado { get; set; }

        public Vector2 Posicion { get; set; }

        

        #endregion

        #region Metodos
        public Texto(SpriteFont font, string txt)
        {
            fuente = font;
            contenido = txt;
            ColorDibujado = Color.Aquamarine;
        }

        public override void Actualizar(GameTime tiempo)
        {
        }

        public override void Dibujar(GameTime tiempo, SpriteBatch sprite)
        {

            sprite.DrawString(fuente, contenido, Posicion, ColorDibujado);

        }
        #endregion
    }
}
