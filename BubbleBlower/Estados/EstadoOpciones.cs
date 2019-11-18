using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using BubbleBlower.Controles;

namespace BubbleBlower.Estados
{
    public class EstadoOpciones : Estado
    {
        private List<Componente> componentes;

        public EstadoOpciones(Game1 juego, GraphicsDevice graficos, ContentManager contenido)
        : base(juego, graficos, contenido)
        {
            int ancho = this.graficos.Viewport.Width;
            int alto = this.graficos.Viewport.Height;
            var btnTextura = contenido.Load<Texture2D>("Controles/cajaMarcada");
            var btnTextura2 = contenido.Load<Texture2D>("Controles/cajaDesmarcada");
            var btnTexturaVolver = contenido.Load<Texture2D>("Controles/menuPrincipal");
            var btnFuente = contenido.Load<SpriteFont>("Fuentes/fuente");

            var btnMusicaMarcado = new Boton(btnTextura, btnFuente)
            {
                Posicion = new Vector2(ancho / 20, 9 * alto / 10),
                Texto = "",
            };

            btnMusicaMarcado.Click += btnMusicaMarcadoClick;


            var btnMusicaDesmarcado = new Boton(btnTextura2, btnFuente)
            {
                Posicion = new Vector2(ancho / 20, 9 * alto / 10),
                Texto = "",
            };
            btnMusicaDesmarcado.Click += btnMusicaDesmarcadoClick;

            var btnEffectosSonidoMarcado = new Boton(btnTextura, btnFuente)
            {
                Posicion = new Vector2(ancho / 20, 9 * alto / 10),
                Texto = "",

            };
            btnEffectosSonidoMarcado.Click += btnEffectosSonidoMarcadoClick;

            var btnEffectosSonidoDesmarcado = new Boton(btnTextura2, btnFuente)
            {
                Posicion = new Vector2(ancho / 20, 9 * alto / 10),
                Texto = "",

            };
            btnEffectosSonidoDesmarcado.Click += btnEffectosSonidoDesmarcadoClick;


            if (juego.getMusica())
            {
                componentes.Add(btnMusicaMarcado);
            }
            else
            {
                componentes.Add(btnMusicaDesmarcado);
            }
            if (juego.getEffectosSonido())
            {
                componentes.Add(btnEffectosSonidoMarcado);
            }
            else
            {
                componentes.Add(btnEffectosSonidoDesmarcado);
            }


        }

        private void btnMusicaMarcadoClick(object sender, EventArgs e)
        {
            juego.cambiarEstado(new EstadoJuego(juego, graficos, contenido));
            
        }
        private void btnMusicaDesmarcadoClick(object sender, EventArgs e)
        {
            juego.cambiarEstado(new EstadoJuego(juego, graficos, contenido));

        }

        private void btnEffectosSonidoMarcadoClick(object sender, EventArgs e)
        {
            juego.cambiarEstado(new EstadoJuego(juego, graficos, contenido));

        }
        private void btnEffectosSonidoDesmarcadoClick(object sender, EventArgs e)
        {
            juego.cambiarEstado(new EstadoJuego(juego, graficos, contenido));

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