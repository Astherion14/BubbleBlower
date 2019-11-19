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
            var btnFuente = contenido.Load<SpriteFont>("Fuentes/fuente3");
            var btnFuente2 = contenido.Load<SpriteFont>("Fuentes/fuente");


            var btnMenuPrincipal = new Boton(btnTexturaVolver, btnFuente)
            {
                Posicion = new Vector2(4 * ancho / 5, alto / 10),
                Texto = "",
            };

            btnMenuPrincipal.Click += btnMenuPrincipalClick;

            var agrTxt1 = new Texto(btnFuente, "Agradecimientos")
            {
                Posicion = new Vector2(ancho / 4, alto / 10)
            };

            componentes.Add(agrTxt1);

            var agrTxt2 = new Texto(btnFuente2, "Fuente Chlorinar: Caffen Fonts")
            {
                Posicion = new Vector2(ancho / 4, 2*alto / 10)
            };

            componentes.Add(agrTxt2);

            var agrTxt3 = new Texto(btnFuente2, "Fondo de aplicacion: Foto de Josephine Bredehoft en Unsplash")
            {
                Posicion = new Vector2(ancho / 8, 3 * alto / 10)
            };

            componentes.Add(agrTxt3);


            var agrTxt4 = new Texto(btnFuente2, "Tema de fondo:nightWalk por airtone (c) copyright Licencia bajo Creative Commons Attribution license.")
            {
                Posicion = new Vector2(0, 4 * alto / 10)
            };

            componentes.Add(agrTxt4);



            componentes.Add(btnMenuPrincipal);


        }

        private void btnMenuPrincipalClick(object sender, EventArgs e)
        {
            juego.reproducirEfecto(0);
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
