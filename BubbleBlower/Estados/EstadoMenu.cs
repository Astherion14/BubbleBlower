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
            var btnTextura = contenido.Load<Texture2D>("Controles/boton");
            var btnFuente = contenido.Load<SpriteFont>("Fuentes/fuente");

            var btnNuevo = new Boton(btnTextura, btnFuente)
            {
                Posicion = new Vector2(10, 380),
                Texto = "A JUGAR",
            };

            btnNuevo.Click += btnNuevoClick;

            var btnOpciones = new Boton(btnTextura, btnFuente)
            {
                Posicion = new Vector2(210, 380),
                Texto = "Opciones",
            };

            btnOpciones.Click += btnOpcionesClick;

            var btnCreditos = new Boton(btnTextura, btnFuente)
            {
                Posicion = new Vector2(410, 380),
                Texto = "Creditos",

            };

            btnCreditos.Click += btnCreditosClick;


            var btnSalir = new Boton(btnTextura, btnFuente)
            {
                Posicion = new Vector2(610, 380),
                Texto = "Salir",
            };

            btnSalir.Click += btnSalirClick;

            componentes = new List<Componente>()
      {
        btnNuevo,
        btnOpciones,
        btnCreditos,
        btnSalir,
      };
        }

        public override void Dibujar(GameTime tiempo, SpriteBatch spriteBatch)
        {
            spriteBatch.Begin();

            foreach (var componente in componentes)
                componente.Dibujar(tiempo, spriteBatch);

            spriteBatch.End();
        }

        private void btnSalirClick(object sender, EventArgs e)
        {
            juego.Exit();
        }

        private void btnOpcionesClick(object sender, EventArgs e)
        {
            Console.WriteLine("Prueba: Se ha pulsado el botón \"opciones\"");
        }

        private void btnCreditosClick(object sender, EventArgs e)
        {
            Console.WriteLine("Prueba: Se ha pulsado el botón \"creditos\"");
        }


        private void btnNuevoClick(object sender, EventArgs e)
        {
            juego.cambiarEstado(new EstadoJuego(juego, graficos, contenido));
        }

        public override void PosActualizado(GameTime gameTime)
        {
            // Borrado de sprites no necesitados
        }

        public override void Actualizar(GameTime tiempo)
        {
            foreach (var componente in componentes)
                componente.Actualizar(tiempo);
        }

    }
}
