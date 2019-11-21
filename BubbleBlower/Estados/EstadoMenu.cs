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
    public class EstadoMenu : Estado
    {
        private List<Componente> componentes;

        public EstadoMenu(Game1 juego, GraphicsDevice graficos, ContentManager contenido)
          : base(juego, graficos, contenido)
        {
            int ancho = this.graficos.Viewport.Width;
            int alto = this.graficos.Viewport.Height;
            var btnTextura = contenido.Load<Texture2D>("Controles/boton");
            var btnFuente = contenido.Load<SpriteFont>("Fuentes/fuente");


            var btnNuevo = new Boton(btnTextura, btnFuente)
            {
                Posicion = new Vector2(ancho/20, 9*alto/10),
                Texto = "A JUGAR",
            };
            
            btnNuevo.Click += btnNuevoClick;

            var btnOpciones = new Boton(btnTextura, btnFuente)
            {
                Posicion = new Vector2(6*ancho/20, 9*alto/10),
                Texto = "Opciones",
            };

            btnOpciones.Click += btnOpcionesClick;

            var btnCreditos = new Boton(btnTextura, btnFuente)
            {
                Posicion = new Vector2(11*ancho/20, 9*alto / 10),
                Texto = "Creditos",

            };

            btnCreditos.Click += btnCreditosClick;


            var btnRecords = new Boton(btnTextura, btnFuente)
            {
                Posicion = new Vector2(16 * ancho / 20, 9*alto / 10),
                Texto = "Salir",
            };

            btnRecords.Click += btnRecordsClick;

            componentes = new List<Componente>()
            {
                btnNuevo,
                btnOpciones,
                btnCreditos,
                btnRecords,
            };
        }

        public override void Dibujar(GameTime tiempo, SpriteBatch spriteBatch)
        {

            spriteBatch.Begin();

            foreach (var componente in componentes)
                componente.Dibujar(tiempo, spriteBatch);

            spriteBatch.End();
        }

        private void btnRecordsClick(object sender, EventArgs e)
        {
            juego.Exit();
        }

        private void btnOpcionesClick(object sender, EventArgs e)
        {
            juego.reproducirEfecto(0);
            juego.cambiarEstado(new EstadoOpciones(juego, graficos, contenido));
        }

        private void btnCreditosClick(object sender, EventArgs e)
        {
            juego.reproducirEfecto(0);
            juego.cambiarEstado(new EstadoCreditos(juego, graficos, contenido));
        }


        private void btnNuevoClick(object sender, EventArgs e)
        {
            juego.reproducirEfecto(0);
            juego.cambiarEstado(new EstadoJuego(juego, graficos, contenido));

        }

        public override void PosActualizado(GameTime gameTime)
        {
        }

        public override void Actualizar(GameTime tiempo)
        {
            
            foreach (var componente in componentes)
                componente.Actualizar(tiempo);
              
        }

    }
}
