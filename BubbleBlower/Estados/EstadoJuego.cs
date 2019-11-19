using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BubbleBlower.Controles;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace BubbleBlower.Estados
{
    public class EstadoJuego : Estado
    {
        private List<Componente> componentes = new List<Componente>();
        private List<Componente> componenteInfo = new List<Componente>();

        public bool fin = false;
        public bool kDown = false;
        public Texture2D esfSiguiente;
        public Texture2D esfActual;
        public EstadoJuego(Game1 juego, GraphicsDevice graficos, ContentManager contenido)
        : base(juego, graficos, contenido)
        {
            int ancho = this.graficos.Viewport.Width;
            int alto = this.graficos.Viewport.Height;
            var btnTexturaVolver = contenido.Load<Texture2D>("Controles/menuPrincipal");
            var apuntar = contenido.Load<Texture2D>("Objetos/flecha");
            var esfRoja = contenido.Load<Texture2D>("Objetos/esferaRoja");
            var esfVerde = contenido.Load<Texture2D>("Objetos/esferaVerde");
            var esfVioleta = contenido.Load<Texture2D>("Objetos/esferaVioleta");
            var esfAzul = contenido.Load<Texture2D>("Objetos/esferaAzul");
            var btnFuente2 = contenido.Load<SpriteFont>("Fuentes/fuente2");
            var btnFuente = contenido.Load<SpriteFont>("Fuentes/fuente");
            Random random = new Random();
            int randomNumber = random.Next(1, 5);
            var esfRandom = esfVerde;
            esfSiguiente = esfRoja; 
            var flecha = new Flecha(apuntar)
            {
                posicion = new Vector2(ancho / 2, alto),
                origen = new Vector2(apuntar.Width / 2, apuntar.Height),
            };
            
            componentes.Add(flecha);
                

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
            int ancho = this.graficos.Viewport.Width;
            int alto = this.graficos.Viewport.Height;
            var btnTexturaVolver = contenido.Load<Texture2D>("Controles/menuPrincipal");
            var apuntar = contenido.Load<Texture2D>("Objetos/flecha");
            var esfRoja = contenido.Load<Texture2D>("Objetos/esferaRoja");
            var esfVerde = contenido.Load<Texture2D>("Objetos/esferaVerde");
            var esfVioleta = contenido.Load<Texture2D>("Objetos/esferaVioleta");
            var esfAzul = contenido.Load<Texture2D>("Objetos/esferaAzul");
            var btnFuente2 = contenido.Load<SpriteFont>("Fuentes/fuente2");
            var btnFuente = contenido.Load<SpriteFont>("Fuentes/fuente");
            Random random = new Random();
            int randomNumber = random.Next(1, 5);
            var esfRandom = esfVerde;

            if(!fin){

            
            

            
                if (Keyboard.GetState().IsKeyDown(Keys.Space) && !kDown)
                {
                    kDown = true;
                    Flecha fl = (Flecha)componentes[0];
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
                    var burbujaActual = new Burbuja(ancho / 40, esfRandom, new Vector2(4 * ancho / 5, 92 * alto / 100), ancho, alto)
                    {
                        velocidadX = 0,
                        velocidadY = 0,

                    };

                    esfActual = esfSiguiente;
                    esfSiguiente = esfRandom;
                    componentes.Add(burbujaActual);

                    var burb = new Burbuja(ancho / 40, esfActual, new Vector2(95*ancho / 200, 95*alto / 100), ancho, alto)
                    {
                        velocidadX = 10f*(float)Math.Sin(fl.getRotacion()),
                        velocidadY = 10f*-(float)Math.Cos(fl.getRotacion()),

                    };


                    componentes.Add(burb);
                    kDown=true;
                }

                /*            if (kDown)
                            {
                                foreach (var componente in componentes)
                                {
                                    if (componente != componentes[0])
                                    {
                                        int comp = componentes.Count;
                                        comp -= 1;
                                        Burbuja b = (Burbuja)componente;
                                        Burbuja lanzada = (Burbuja)componentes[comp];
                                        lanzada.colisionBurbuja(b);

                                    }
                                }
                                kDown = false;
                            }
                */

                //dejo esto para que se pueda ver la funcionalidad
                if (Keyboard.GetState().IsKeyUp(Keys.Space))
                {
                    kDown = false;
                }

                foreach (var componente in componentes)
                    componente.Actualizar(tiempo);
                foreach (var componente in componenteInfo)
                    componente.Actualizar(tiempo);
            }
            else
            {
                String renglon;
                String records="";
                try
                {
                    StreamReader sr = new StreamReader("C:\\records.txt");

                    renglon = sr.ReadLine();

                    while (renglon != null)
                    {
                        records += renglon;
                        renglon = sr.ReadLine();
                    }
                    records += renglon;

                    sr.Close();
                }
                catch (Exception error)
                {
                    Console.WriteLine("Error: " + error.Message);
                }
                componentes.Clear();
                //Aqui se romperian los renglones usando ":" como caracter split para coger las 10 puntuaciones mejores
                //compararlas con la obtenida y se crearia un array que luego se reinsertaria sobreescribiendo el archivo.
            }
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
