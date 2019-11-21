using System;
using System.Collections.Generic;   
using System.IO;
using System.Linq;
using System.Reflection;
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
        private List<Componente> colisiones = new List<Componente>();
        public bool exp = false;
        public bool continuar = false;
        public bool record = false;
        public bool fin = false;
        public bool kDown = false;
        public bool esfMov = false;
        public int ascii1 = 65;
        public int ascii2 = 65;
        public int ascii3 = 65;
        public int car = 0;
        public Texture2D esfSiguiente;
        public Texture2D esfActual;
        public Texture2D esfAuxiliar;
        public int turnoAvanza;
        public int turnosAvanzados;


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
            esfActual = esfVerde;
            esfAuxiliar = esfVioleta;
            turnosAvanzados = 0;
            var flecha = new Flecha(apuntar)
            {
                posicion = new Vector2(ancho / 2, alto),
                origen = new Vector2(apuntar.Width / 2, apuntar.Height),
            };
            turnoAvanza = 0;
            componentes.Add(flecha);
                

            for (int i=0; i<=5; i++)
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
                        var burb = new Burbuja(ancho / 40, esfRandom, new Vector2(j*ancho/20, i*ancho / 20), ancho, alto)
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
                        var burb = new Burbuja(ancho / 40, esfRandom, new Vector2(g * ancho / 20+(ancho/40), i * ancho / 20), ancho, alto)
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
                    turnoAvanza += 1;

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
                    var burb2 = new Burbuja(ancho / 40, esfAuxiliar, new Vector2(3 * ancho / 5, 92 * alto / 100), ancho, alto)
                    {
                        velocidadX = 0,
                        velocidadY = 0,
                    };

                    esfActual = esfSiguiente;
                    esfSiguiente = esfAuxiliar;
                    esfAuxiliar = esfRandom;
                    componenteInfo.Clear();
                    componenteInfo.Add(burb2);
                    componenteInfo.Add(burbujaActual);

                    var burb = new Burbuja(ancho / 40, esfActual, new Vector2(95*ancho / 200, 95*alto / 100), ancho, alto)
                    {
                        velocidadX = 10f*(float)Math.Sin(fl.getRotacion()),
                        velocidadY = 10f*-(float)Math.Cos(fl.getRotacion()),

                    };


                    componentes.Add(burb);
                    kDown=true;
                    esfMov = true;
                }



                foreach (var componente in componentes)
                {
                    int comp = componentes.Count;
                    comp -= 1;
                    if (componente != componentes[0] && componente != componentes[comp])
                    {

                        Burbuja b = (Burbuja)componente;
                        Burbuja lanzada = (Burbuja)componentes[comp];
                        if (lanzada.colisionBurbuja(b) != 0)
                        {
                            kDown = false;
                            esfMov = false;
                            juego.reproducirEfecto(0);
                            burbujasExplotan(lanzada);
                        }
                    }

                }
                if (colisiones != null)
                {
                    if (colisiones.Count > 2)
                    {


                        foreach (var col in colisiones)
                        {
                            componentes.Remove(col);
                            juego.reproducirEfecto(1);
                            juego.setPuntuacion((juego.getPuntuacion() + 100));
                            
                        }
                        exp = true;
                    }
                    colisiones.Clear();
                }
                if (exp)
                {
                    foreach (var componente in componentes)
                    {
                        if (componentes[0]!=componente)
                        {
                            Burbuja burbujita = (Burbuja)componente;
                            if (!burbujasSolitarias(burbujita))
                            {
                                colisiones.Add(componente);
                                juego.reproducirEfecto(1);
                                juego.setPuntuacion((juego.getPuntuacion() + 100));
                            }
                        }
                    }
                    if (colisiones.Count>0)
                    {
                        foreach (var col in colisiones)
                        {
                            componentes.Remove(col);
                        }
                    }
                    exp = false;
                }



                //dejo esto para que se pueda ver la funcionalidad
                /* if (Keyboard.GetState().IsKeyUp(Keys.Space))
                 {
                     kDown = false;
                 }
                //*/
                if (turnoAvanza > 5 && ! esfMov)
                {
                    foreach (var componente in componentes)
                    {
                        if (componente != componentes[0] )
                        {
                            Burbuja burbMov = (Burbuja)componente;
                            burbMov.setPosicion(new Vector2(burbMov.getPosicion().X, burbMov.getPosicion().Y + ancho / 20));
                        }
                    }

                    if (turnosAvanzados % 2 != 0)
                    {
                        for (int g = 0; g < 19; g++)
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
                            var burb = new Burbuja(ancho / 40, esfRandom, new Vector2(g * ancho / 20 + (ancho / 40), 0), ancho, alto)
                            {
                                velocidadX = 0f,
                                velocidadY = 0f,

                            };
                            componentes.Add(burb);

                        }
                    }
                    else
                    {
                        for (int g = 0; g < 20; g++)
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
                            var burb = new Burbuja(ancho / 40, esfRandom, new Vector2(g * ancho / 20, 0), ancho, alto)
                            {
                                velocidadX = 0f,
                                velocidadY = 0f,

                            };
                            componentes.Add(burb);

                        }
                    }
                    turnosAvanzados++;
                    turnoAvanza = 0;

                }

                fin = finDeJuego();
                if (fin)
                {
                    kDown = true;
                }
                foreach (var componente in componentes)
                {
                    componente.Actualizar(tiempo);
                }
                foreach (var componente in componenteInfo)
                {
                    componente.Actualizar(tiempo);
                }
            }
            else
            {
                if(!continuar){

                
                    componentes.Clear();
                    var fnt = contenido.Load<SpriteFont>("Fuentes/fuente4");

                    var txtFin = new Texto(fnt, "Has acabado la partida con una puntuacion de: "+juego.getPuntuacion())
                    {
                        Posicion = new Vector2(ancho/5, 4 * alto / 10)
                    };
                    var txtFin2 = new Texto(fnt, "Pulsa espacio para continuar")
                    {
                        Posicion = new Vector2(ancho / 5, 6 * alto / 10)
                    };

                    componentes.Add(txtFin);
                    componentes.Add(txtFin2);


                    String renglon;
                    String records="";
                    try
                    {

                        StreamReader sr = new StreamReader(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location));

                        renglon = sr.ReadLine();
                        if (renglon == null)
                        {
                            record = true;
                        }
                        while (renglon != null)
                        {
                            if (Int32.Parse(renglon.Split(':')[1])<juego.getPuntuacion())
                            {
                                record = true;
                            }
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
                    componenteInfo.Clear();
                    if (Keyboard.GetState().IsKeyUp(Keys.Space) )
                    {
                        kDown = false;
                    }
                    if (Keyboard.GetState().IsKeyDown(Keys.Space) && !kDown)
                    {
                        componentes.Clear();
                        continuar = true;
                    }

                        //Aqui se romperian los renglones usando ":" como caracter split para coger las 10 puntuaciones mejores
                        //compararlas con la obtenida y se crearia un array que luego se reinsertaria sobreescribiendo el archivo.

                }
                else
                {
                    if (record)
                    {
                        var fnt = contenido.Load<SpriteFont>("Fuentes/fuente4");

                        var txtRecord = new Texto(fnt, "Pulsa 'D' o 'A' para cambiar el carácter, intro para pasar al siguiente carácter:")
                        {
                            Posicion = new Vector2(ancho / 5, 4 * alto / 10)
                        };



                        componentes.Add(txtRecord);

                        if (Keyboard.GetState().IsKeyDown(Keys.D) && !kDown)
                        {
                            kDown = true;
                            switch (car)
                            {
                                case 0:
                                    if (ascii1==90)
                                    {
                                        ascii1 = 65;
                                    }
                                    else
                                    {
                                        ascii1 += 1;
                                    }
                                    break;
                                case 1:
                                    if (ascii2 == 90)
                                    {
                                        ascii2 = 65;
                                    }
                                    else
                                    {
                                        ascii2 += 1;
                                    }

                                    break;
                                case 2:
                                    if (ascii3 == 90)
                                    {
                                        ascii3 = 65;
                                    }
                                    else
                                    {
                                        ascii3 += 1;
                                    }

                                    break;
                            }
                        }

                        if (Keyboard.GetState().IsKeyDown(Keys.A) && !kDown)
                        {
                            kDown = true;
                            switch (car)
                            {
                                case 0:
                                    if (ascii1 == 65)
                                    {
                                        ascii1 = 90;
                                    }
                                    else
                                    {
                                        ascii1 -= 1;
                                    }
                                    break;
                                case 1:
                                    if (ascii2 == 65)
                                    {
                                        ascii2 = 90;
                                    }
                                    else
                                    {
                                        ascii2 -= 1;
                                    }

                                    break;
                                case 2:
                                    if (ascii3 == 65)
                                    {
                                        ascii3 = 90;
                                    }
                                    else
                                    {
                                        ascii3 -= 1;
                                    }

                                    break;
                            }

                        }

                        if (Keyboard.GetState().IsKeyDown(Keys.Insert) && !kDown)
                        {
                            kDown = true;
                            car += 1;
                            if (car==3)
                            {

                            }

                        }

                        if (Keyboard.GetState().IsKeyUp(Keys.Insert))
                        {
                            kDown = false;
                        }
                        if (Keyboard.GetState().IsKeyUp(Keys.A))
                        {
                            kDown = false;
                        }
                        if (Keyboard.GetState().IsKeyUp(Keys.D))
                        {
                            kDown = false;
                        }
                        if (componentes.Count>1)
                        {
                            componentes.RemoveAt(1);
                        }
                        var txtRecord2 = new Texto(fnt, "" + (char)ascii1 + "-" + (char)ascii2 + "-" + (char)ascii3)
                        {
                            Posicion = new Vector2(ancho / 5, 6 * alto / 10)
                        };
                        componentes.Add(txtRecord2);


                    }
                    else
                    {
                        juego.cambiarEstado(new EstadoMenu(juego, graficos, contenido));
                    }
                }
                foreach (var componente in componentes)
                {
                    componente.Actualizar(tiempo);
                }
                foreach (var componente in componenteInfo)
                {
                    componente.Actualizar(tiempo);
                }
            }
                
                
            }

        public override void Dibujar(GameTime tiempo, SpriteBatch spriteBatch)
        {
            spriteBatch.Begin();

            foreach (var componente in componentes)
                componente.Dibujar(tiempo, spriteBatch);
            foreach (var componente in componenteInfo)
                componente.Dibujar(tiempo, spriteBatch);

            spriteBatch.End();
        }

        public override void PosActualizado(GameTime tiempo)
        {
        }

        public bool finDeJuego()
        {
            foreach (var componente in componentes)
            {
                if (componente!=componentes[0] && componente!=componentes[(componentes.Count-1)])
                {
                    Burbuja B = (Burbuja)componente;
                    if (B.getPosicion().Y>=B.radio*20 && B.velocidadX==0 && B.velocidadY==0)
                    {
                        if (kDown)
                        {
                            return false;
                        }
                        else
                        {
                            return true;

                        }
                    }

                }
            }
                return false;
        }



        public void burbujasExplotan(Burbuja comprobada)
        {
           List<Vector2> posiciones = new List<Vector2>();
            Vector2 posicion = new Vector2();
            for (int i = 0; i <= 5; i++){
                switch (i)
                {
                    case 0:

                        foreach (var componente in componentes)
                        {
                            if (componente != componentes[0])
                            {
                                Burbuja brb = (Burbuja)componente;
                                if (Math.Abs(brb.getPosicion().X-(comprobada.getPosicion().X-comprobada.radio))<=15 && Math.Abs(brb.getPosicion().Y-(comprobada.getPosicion().Y-2*comprobada.radio))<= 15)
                                {
                                    if (brb.color == comprobada.color)
                                    {
                                        bool comp = false;
                                        foreach (var colision in colisiones)
                                        {
                                            
                                            if (colision==brb)
                                            {
                                                comp = true;

                                            }
                                        }
                                        if (!comp)
                                        {
                                            colisiones.Add(brb);
                                            burbujasExplotan(brb);
                                        }
                                    }
                                }

                            }
                        }
                        break;

                    case 1:
                        foreach (var componente in componentes)
                        {
                            if (componente != componentes[0])
                            {
                                Burbuja brb = (Burbuja)componente;
                                if (Math.Abs(brb.getPosicion().X - (comprobada.getPosicion().X + comprobada.radio)) <= 15 && Math.Abs(brb.getPosicion().Y - (comprobada.getPosicion().Y - 2*comprobada.radio)) <= 15)
                                {
                                    if (brb.color == comprobada.color)
                                    {
                                        bool comp = false;
                                        foreach (var colision in colisiones)
                                        {

                                            if (colision == brb)
                                            {
                                                comp = true;

                                            }
                                        }
                                        if (!comp)
                                        {
                                            colisiones.Add(brb);
                                            burbujasExplotan(brb);
                                        }
                                    }
                                }

                            }
                        }
                        break;
                    case 2:
                        foreach (var componente in componentes)
                        {
                            if (componente != componentes[0])
                            {
                                Burbuja brb = (Burbuja)componente;
                                if (Math.Abs(brb.getPosicion().X - (comprobada.getPosicion().X - 2*comprobada.radio)) <= 15 && Math.Abs(brb.getPosicion().Y - (comprobada.getPosicion().Y)) <= 15)
                                {
                                    if (brb.color == comprobada.color)
                                    {
                                        bool comp = false;
                                        foreach (var colision in colisiones)
                                        {

                                            if (colision == brb)
                                            {
                                                comp = true;

                                            }
                                        }
                                        if (!comp)
                                        {
                                            colisiones.Add(brb);
                                            burbujasExplotan(brb);
                                        }
                                    }
                                }

                            }
                        }
                        break;
                    case 3:
                        foreach (var componente in componentes)
                        {
                            if (componente != componentes[0])
                            {
                                Burbuja brb = (Burbuja)componente;
                                if (Math.Abs(brb.getPosicion().X - (comprobada.getPosicion().X + 2*comprobada.radio)) <= 15 && Math.Abs(brb.getPosicion().Y - (comprobada.getPosicion().Y)) <= 15)
                                {
                                    if (brb.color == comprobada.color)
                                    {
                                        bool comp = false;
                                        foreach (var colision in colisiones)
                                        {

                                            if (colision == brb)
                                            {
                                                comp = true;

                                            }
                                        }
                                        if (!comp)
                                        {
                                            colisiones.Add(brb);
                                            burbujasExplotan(brb);
                                        }
                                    }
                                }

                            }
                        }
                        break;
                    case 4:
                        foreach (var componente in componentes)
                        {
                            if (componente != componentes[0])
                            {
                                Burbuja brb = (Burbuja)componente;
                                if (Math.Abs(brb.getPosicion().X - (comprobada.getPosicion().X - comprobada.radio)) <= 15 && Math.Abs(brb.getPosicion().Y - (comprobada.getPosicion().Y + 2*comprobada.radio)) <= 15)
                                {
                                    if (brb.color == comprobada.color)
                                    {
                                        bool comp = false;
                                        foreach (var colision in colisiones)
                                        {

                                            if (colision == brb)
                                            {
                                                comp = true;

                                            }
                                        }
                                        if (!comp)
                                        {
                                            colisiones.Add(brb);
                                            burbujasExplotan(brb);
                                        }
                                    }
                                }

                            }
                        }
                        break;
                    case 5:
                        foreach (var componente in componentes)
                        {
                            if (componente != componentes[0])
                            {
                                Burbuja brb = (Burbuja)componente;
                                if (Math.Abs(brb.getPosicion().X - (comprobada.getPosicion().X + comprobada.radio)) <= 15 && Math.Abs(brb.getPosicion().Y - (comprobada.getPosicion().Y + 2*comprobada.radio)) <= 15)
                                {
                                    if (brb.color == comprobada.color)
                                    {
                                        bool comp = false;
                                        foreach (var colision in colisiones)
                                        {

                                            if (colision == brb)
                                            {
                                                comp = true;

                                            }
                                        }
                                        if (!comp)
                                        {
                                            colisiones.Add(brb);
                                            burbujasExplotan(brb);
                                        }
                                    }
                                }

                            }
                        }
                        break;

                }
            }

        }
        public bool burbujasSolitarias(Burbuja comprobada)
        {
            List<Vector2> posiciones = new List<Vector2>();
            for (int i = 0; i <= 5; i++)
            {
                switch (i)
                {
                    case 0:

                        foreach (var componente in componentes)
                        {
                            if (componente != componentes[0])
                            {
                                Burbuja brb = (Burbuja)componente;
                                if (Math.Abs(brb.getPosicion().X - (comprobada.getPosicion().X - comprobada.radio)) <= 15 && Math.Abs(brb.getPosicion().Y - (comprobada.getPosicion().Y - 2 * comprobada.radio)) <= 15)
                                {
                                    return true;
                                }

                            }
                        }
                        break;

                    case 1:
                        foreach (var componente in componentes)
                        {
                            if (componente != componentes[0])
                            {
                                Burbuja brb = (Burbuja)componente;
                                if (Math.Abs(brb.getPosicion().X - (comprobada.getPosicion().X + comprobada.radio)) <= 15 && Math.Abs(brb.getPosicion().Y - (comprobada.getPosicion().Y - 2 * comprobada.radio)) <= 15)
                                {
                                    return true;
                                }

                            }
                        }
                        break;
                    case 2:
                        foreach (var componente in componentes)
                        {
                            if (componente != componentes[0])
                            {
                                Burbuja brb = (Burbuja)componente;
                                if (Math.Abs(brb.getPosicion().X - (comprobada.getPosicion().X - 2 * comprobada.radio)) <= 15 && Math.Abs(brb.getPosicion().Y - (comprobada.getPosicion().Y)) <= 15)
                                {
                                    return true;
                                }

                            }
                        }
                        break;
                    case 3:
                        foreach (var componente in componentes)
                        {
                            if (componente != componentes[0])
                            {
                                Burbuja brb = (Burbuja)componente;
                                if (Math.Abs(brb.getPosicion().X - (comprobada.getPosicion().X + 2 * comprobada.radio)) <= 15 && Math.Abs(brb.getPosicion().Y - (comprobada.getPosicion().Y)) <= 15)
                                {
                                    return true;
                                }

                            }
                        }
                        break;
                    case 4:
                        foreach (var componente in componentes)
                        {
                            if (componente != componentes[0])
                            {
                                Burbuja brb = (Burbuja)componente;
                                if (Math.Abs(brb.getPosicion().X - (comprobada.getPosicion().X - comprobada.radio)) <= 15 && Math.Abs(brb.getPosicion().Y - (comprobada.getPosicion().Y + 2 * comprobada.radio)) <= 15)
                                {
                                    return true;
                                }

                            }
                        }
                        break;
                    case 5:
                        foreach (var componente in componentes)
                        {
                            if (componente != componentes[0])
                            {
                                Burbuja brb = (Burbuja)componente;
                                if (Math.Abs(brb.getPosicion().X - (comprobada.getPosicion().X + comprobada.radio)) <= 15 && Math.Abs(brb.getPosicion().Y - (comprobada.getPosicion().Y + 2 * comprobada.radio)) <= 15)
                                {
                                    return true;
                                }

                            }
                        }
                        break;

                }
            }
            return false;

        }
    }
}
