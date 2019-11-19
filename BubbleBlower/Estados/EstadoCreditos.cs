using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BubbleBlower.Controles;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace BubbleBlower.Estados
{
    public class EstadoCreditos : Estado
    {
        private List<Componente> componentes = new List<Componente>();

        public EstadoCreditos(Game1 juego, GraphicsDevice graficos, ContentManager contenido)
        : base(juego, graficos, contenido)
        {
            int ancho = this.graficos.Viewport.Width;
            int alto = this.graficos.Viewport.Height;
            var btnTexturaVolver = contenido.Load<Texture2D>("Controles/menuPrincipal");
            var btnFuente = contenido.Load<SpriteFont>("Fuentes/fuente");
            var btnFuente2 = contenido.Load<Texture2D>("Objetos/esferaAzul");

            var btnMenuPrincipal = new Boton(btnTexturaVolver, btnFuente)
            {
                Posicion = new Vector2(4 * ancho / 5, alto / 10),
                Texto = "",
            };

            btnMenuPrincipal.Click += btnMenuPrincipalClick;

            var burb = new Burbuja(ancho / 40, btnFuente2, new Vector2(ancho / 2, alto / 2), ancho, alto)
            {
                velocidadX = 5f,
                velocidadY = -1f,
                
            };
            componentes.Add(burb);
            componentes.Add(btnMenuPrincipal);


        }

        private void btnMenuPrincipalClick(object sender, EventArgs e)
        {
            juego.cambiarEstado(new EstadoMenu(juego, graficos, contenido));
        }

        public override void Actualizar(GameTime tiempo)
        {
            foreach (var componente in componentes)
                componente.Actualizar(tiempo);
        }

        public override void Dibujar(GameTime tiempo, SpriteBatch spriteBatch)
        {
            spriteBatch.Begin();

            foreach (var componente in componentes)
                componente.Dibujar(tiempo, spriteBatch);

            spriteBatch.End();
        }

        public override void PosActualizado(GameTime tiempo)
        {
        }
    }
}
