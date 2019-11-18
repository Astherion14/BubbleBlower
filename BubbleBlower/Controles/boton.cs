using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BubbleBlower.Controles
{
    public class Boton : Componente
    {
        #region Atributos

        private MouseState raton;

        private SpriteFont fuente;

        private bool flotando;

        private MouseState estadoRatonPrevio;

        private Texture2D textura;

        #endregion

        #region Propiedades

        public event EventHandler Click;

        public bool Pinchado { get; private set; }

        public Color ColorDibujado { get; set; }

        public Vector2 Posicion { get; set; }

        public Rectangle Rectangulo
        {
            get
            {
                return new Rectangle((int)Posicion.X, (int)Posicion.Y, textura.Width, textura.Height);
            }
        }

        public string Texto { get; set; }

        #endregion

        #region Metodos

        public Boton(Texture2D texture, SpriteFont font)
        {
            textura = texture;

            fuente = font;

            ColorDibujado = Color.Black;
        }

        public override void Dibujar(GameTime gameTime, SpriteBatch spriteBatch)
        {
            var colour = Color.White;

            if (flotando)
                colour = Color.Gray;

            spriteBatch.Draw(textura, Rectangulo, colour);

            if (!string.IsNullOrEmpty(Texto))
            {
                var x = (Rectangulo.X + (Rectangulo.Width / 2)) - (fuente.MeasureString(Texto).X / 2);
                var y = (Rectangulo.Y + (Rectangulo.Height / 2)) - (fuente.MeasureString(Texto).Y / 2);

                spriteBatch.DrawString(fuente, Texto, new Vector2(x, y), ColorDibujado);
            }
        }

        public override void Actualizar(GameTime gameTime)
        {
            estadoRatonPrevio = raton;
            raton = Mouse.GetState();

            var rectanguloRaton = new Rectangle(raton.X, raton.Y, 1, 1);

            flotando = false;

            if (rectanguloRaton.Intersects(Rectangulo))
            {
                flotando = true;

                if (raton.LeftButton == ButtonState.Released && estadoRatonPrevio.LeftButton == ButtonState.Pressed)
                {
                    Click?.Invoke(this, new EventArgs());
                }
            }
        }

        #endregion
    }
}