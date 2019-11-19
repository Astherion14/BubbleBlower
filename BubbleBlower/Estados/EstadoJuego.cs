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
    public class EstadoJuego : Estado
    {
        private List<Componente> componentes = new List<Componente>();

        public EstadoJuego(Game1 juego, GraphicsDevice graficos, ContentManager contenido)
        : base(juego, graficos, contenido)
        {
            int ancho = this.graficos.Viewport.Width;
            int alto = this.graficos.Viewport.Height;
            var btnTexturaVolver = contenido.Load<Texture2D>("Controles/menuPrincipal");
            var esfRoja = contenido.Load<Texture2D>("Objetos/esferaRoja");
            var esfVerde = contenido.Load<Texture2D>("Objetos/esferaVerde");
            var esfVioleta = contenido.Load<Texture2D>("Objetos/esferaVioleta");
            var esfAzul = contenido.Load<Texture2D>("Objetos/esferaAzul");
            var btnFuente2 = contenido.Load<SpriteFont>("Fuentes/fuente2");
            var btnFuente = contenido.Load<SpriteFont>("Fuentes/fuente");
            Random random = new Random();
            int randomNumber = random.Next(1, 5);
            var esfRandom = esfVerde;

            for (int i=0; i<=7; i++)
            {
                if (i % 2 == 0)
                {
                    for (int j=0; j<=19; j++)
                    {
                        randomNumber = random.Next(1, 5);
                        switch(randomNumber){
                            case 1:esfRandom = esfAzul;
                                break;
                            case 2:esfRandom = esfRoja;
                                break;
                            case 3:esfRandom = esfVerde;
                                break;
                            case 4:esfRandom = esfVioleta;
                                break;
                            default:esfRandom=esfAzul;
                                break;
                        }
                        var burb = new Burbuja(ancho / 40, esfRandom, new Vector2(j*ancho/20, i*alto / 13), ancho, alto)
                        {
                            velocidadX = 0f,
                            velocidadY = 0f,

                        };
                        componentes.Add(burb);


                    }
                }
                else
                {
                    for (int g=0; g<19; g++)
                    {
                        randomNumber = random.Next(1, 5);
                        switch (randomNumber)
                        {
                            case 1:
                                esfRandom = esfAzul;
                                break;
                            case 2:
                                esfRandom = esfRoja;
                                break;
                            case 3:
                                esfRandom = esfVerde;
                                break;
                            case 4:
                                esfRandom = esfVioleta;
                                break;
                            default:
                                esfRandom = esfAzul;
                                break;
                        }
                        var burb = new Burbuja(ancho / 40, esfRandom, new Vector2(g * ancho / 20+(ancho/40), i * alto / 13), ancho, alto)
                        {
                            velocidadX = 0f,
                            velocidadY = 0f,

                        };
                        componentes.Add(burb);

                    }
                }

            }
 


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
