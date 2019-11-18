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
        private List<Componente> componentes=new List<Componente>();

        public EstadoOpciones(Game1 juego, GraphicsDevice graficos, ContentManager contenido)
        : base(juego, graficos, contenido)
        {
            int ancho = this.graficos.Viewport.Width;
            int alto = this.graficos.Viewport.Height;
            var btnTextura = contenido.Load<Texture2D>("Controles/cajaMarcada");
            var btnTextura2 = contenido.Load<Texture2D>("Controles/cajaDesmarcada");
            var btnTextura3 = contenido.Load<Texture2D>("Controles/masVolumen");
            var btnTextura4 = contenido.Load<Texture2D>("Controles/menosVolumen");
            var btnTextura5 = contenido.Load<Texture2D>("Controles/boton");
            var btnTexturaVolver = contenido.Load<Texture2D>("Controles/menuPrincipal");
            var btnFuente = contenido.Load<SpriteFont>("Fuentes/fuente3");
            var btnFuente2 = contenido.Load<SpriteFont>("Fuentes/fuente2");

            var btnMenosVolumen = new Boton(btnTextura4, btnFuente)
            {
                Posicion = new Vector2(8 * ancho / 12, 3*alto / 5),
                Texto = "",
            };

            btnMenosVolumen.Click += btnMenosVolumenClick;

            var btnMasVolumen = new Boton(btnTextura3, btnFuente)
            {
                Posicion = new Vector2(10 * ancho / 12, 3*alto / 5),
                Texto = "",
            };

            btnMasVolumen.Click += btnMasVolumenClick;


            var btnMusicaMarcado = new Boton(btnTextura, btnFuente)
            {
                Posicion = new Vector2(2*ancho / 3,   alto / 5),
                Texto = "",
            };

            btnMusicaMarcado.Click += btnMusicaMarcadoClick;

            var btnMenuPrincipal = new Boton(btnTexturaVolver, btnFuente)
            {
                Posicion = new Vector2(4 * ancho / 5, alto / 10),
                Texto = "",
            };

            btnMenuPrincipal.Click += btnMenuPrincipalClick;


            var btnMusicaDesmarcado = new Boton(btnTextura2, btnFuente)
            {
                Posicion = new Vector2(2 * ancho / 3, alto / 5),
                Texto = "",
            };
            btnMusicaDesmarcado.Click += btnMusicaDesmarcadoClick;

            var btnEffectosSonidoMarcado = new Boton(btnTextura, btnFuente)
            {
                Posicion = new Vector2(2 * ancho / 3, 2*alto / 5),
                Texto = "",

            };
            btnEffectosSonidoMarcado.Click += btnEffectosSonidoMarcadoClick;

            var btnEffectosSonidoDesmarcado = new Boton(btnTextura2, btnFuente)
            {
                Posicion = new Vector2(2 * ancho / 3, 2*alto / 5),
                Texto = "",

            };
            btnEffectosSonidoDesmarcado.Click += btnEffectosSonidoDesmarcadoClick;

            var txtEffectosSonido = new Texto(btnFuente, "Desactivar efectos de sonido")
            {
                Posicion = new Vector2(ancho / 6, 17 * alto / 40)
            };

            var txtMusica = new Texto(btnFuente, "Desactivar musica de ambiente")
            {
                Posicion = new Vector2(ancho / 6, 9 * alto / 40)
            };
            var txtVol1 = new Texto(btnFuente, "Volumen actual del juego")
            {
                Posicion = new Vector2(ancho / 6, 25 * alto / 40)
            };
            var txtVol2 = new Texto(btnFuente2, ""+juego.getVol()+"%")
            {
                Posicion = new Vector2(9 * ancho / 12, 25 * alto / 40)
            };
            var txtRecords = new Texto(btnFuente, "Limpiar Records")
            {
                Posicion = new Vector2(ancho / 6, 34 * alto / 40)
            };

            var btnLimpiar = new Boton(btnTextura2, btnFuente)
            {
                Posicion = new Vector2(2 * ancho / 3, 34 * alto / 40),
                Texto = "",

            };
            btnLimpiar.Click += btnLimpiarClick;

            var txtConfirmacion = new Texto(btnFuente, "Esta seguro de querer limpiar los records?")
            {
                Posicion = new Vector2(ancho / 5, alto / 3)
            };

            var btnConfirmSi = new Boton(btnTextura5, btnFuente)
            {
                Posicion = new Vector2(ancho / 5, 3 * alto / 5),
                Texto = "Si",
                ColorDibujado = Color.Red,

            };
            btnConfirmSi.Click += btnConfirmSiClick;

            var btnConfirmNo = new Boton(btnTextura5, btnFuente)
            {
                Posicion = new Vector2(3 * ancho / 5, 3* alto / 5),
                Texto = "No",
                ColorDibujado = Color.Red,

    };
            btnConfirmNo.Click += btnConfirmNoClick;




            if (juego.getLimpiar())
            {
                componentes.Add(txtConfirmacion);
                componentes.Add(btnConfirmNo);
                componentes.Add(btnConfirmSi);
            }
            else
            {

            



                componentes.Add(btnLimpiar);
                componentes.Add(txtRecords);
                componentes.Add(txtVol2);
                componentes.Add(txtVol1);
                componentes.Add(txtEffectosSonido);
                componentes.Add(txtMusica);
                componentes.Add(btnMenuPrincipal);
                componentes.Add(btnMasVolumen);
                componentes.Add(btnMenosVolumen);
            

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
        }

        private void btnConfirmSiClick(object sender, EventArgs e)
        {
            //Aqui va el limpiado del archivo
            juego.setLimpiar(false);
            juego.cambiarEstado(new EstadoOpciones(juego, graficos, contenido));
            
        }
        private void btnConfirmNoClick(object sender, EventArgs e)
        {
            juego.setLimpiar(false);
            juego.cambiarEstado(new EstadoOpciones(juego, graficos, contenido));

        }
        private void btnMusicaMarcadoClick(object sender, EventArgs e)
        {
            juego.setMusica(false);
            juego.cambiarEstado(new EstadoOpciones(juego, graficos, contenido));

        }

        private void btnMusicaDesmarcadoClick(object sender, EventArgs e)
        {
            juego.setMusica(true);
            juego.cambiarEstado(new EstadoOpciones(juego, graficos, contenido));

        }

        private void btnEffectosSonidoMarcadoClick(object sender, EventArgs e)
        {
            juego.setEffectosSonido(false);
            juego.cambiarEstado(new EstadoOpciones(juego, graficos, contenido));

        }
        private void btnEffectosSonidoDesmarcadoClick(object sender, EventArgs e)
        {
            juego.setEffectosSonido(true);
            juego.cambiarEstado(new EstadoOpciones(juego, graficos, contenido));

        }

        private void btnMasVolumenClick(object sender, EventArgs e)
        {
            juego.setVol(juego.getVol() + 10);
            juego.cambiarEstado(new EstadoOpciones(juego, graficos, contenido));

        }
        private void btnMenosVolumenClick(object sender, EventArgs e)
        {
            juego.setVol(juego.getVol()-10);
            juego.cambiarEstado(new EstadoOpciones(juego, graficos, contenido));

        }

        private void btnLimpiarClick(object sender, EventArgs e)
        {
            juego.setLimpiar(true);
            juego.cambiarEstado(new EstadoOpciones(juego, graficos, contenido));

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