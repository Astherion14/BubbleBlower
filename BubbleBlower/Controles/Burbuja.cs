using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace BubbleBlower.Controles
{
    public class Burbuja : Componente
    {
        #region Atributos

        private Vector2 posicion;

        private bool colisionParedBol;
        private bool colisionPompa;
        //private int mismoColor;
        //private Vector2 centro;
        private int alto;
        private int ancho;
        private float escala;
        private Rectangle rectangulo;
        private int rWidth;
        private int rHeight;


        #endregion

        #region Propiedades
        public float radio { get; set; }
        public Texture2D color { get; set; }
        public float velocidadX { get; set; }
        public float velocidadY { get; set; }
        #endregion

        #region Metodos     

        public Burbuja(float rad, Texture2D textura, Vector2 posicion, int ancho, int alto)
        {
            this.escala = (2*rad/textura.Height);
            this.colisionParedBol = false;
            this.ancho = ancho;
            this.alto = alto;

            this.posicion = posicion;
            this.radio = rad;
            this.color = textura;
            this.velocidadX = 0f;
            this.velocidadY = 0f;
            //this.mismoColor = 0;
            this.colisionPompa = false;
            this.rWidth = (int)escala * textura.Width;
            this.rHeight = (int)escala * textura.Height;
            this.rectangulo = new Rectangle((int)posicion.X,(int)posicion.Y,rWidth,rHeight);
        }
        public Vector2 getPosicion()
        {
            return this.posicion;
        }

        public void setPosicion(Vector2 pos)
        {
            this.posicion = pos;
        }

        public Texture2D getTextura()
        {
            return this.color;
        }

        public void colisionPared( int ancho, int alto)
        {
            if (this.posicion.X > (ancho - 2*radio))
            {
                while (this.posicion.X + 2*radio > ancho)
                {
                    this.posicion.X -= 1;
                }
                this.rectangulo = new Rectangle((int)posicion.X, (int)posicion.Y, rWidth, rHeight);

                velocidadX = velocidadX * -1;

            }

            if (this.posicion.X<0)
            {
                while (this.posicion.X < 0)
                {
                    this.posicion.X += 1;
                }
                this.rectangulo = new Rectangle((int)posicion.X, (int)posicion.Y, rWidth, rHeight);

                velocidadX = velocidadX * -1;

            }

            if (this.posicion.Y<0)
            {
                while (this.posicion.Y< 0)
                {
                    this.posicion.Y += 1;
                }
                this.rectangulo = new Rectangle((int)posicion.X, (int)posicion.Y, rWidth, rHeight);
                velocidadY = 0;
                velocidadX = 0f; 
                colisionParedBol = true;
            }

        }

        public int colisionBurbuja(Burbuja burbuja)
        {
            int caso = 0;
            if (this.rectangulo.Intersects(burbuja.rectangulo))
            {
                this.velocidadX = 0;
                this.velocidadY = 0;
                int dX = (int)Math.Abs(this.posicion.X-burbuja.posicion.X);
                int dY = (int)Math.Abs(this.posicion.Y - burbuja.posicion.Y);

                if (this.posicion.X<= burbuja.posicion.X)
                {
                    if (this.posicion.Y<= burbuja.posicion.Y)
                    {
                        if (dX == dY || (dX < dY && dX >= dY / 2) || (dY < dX && dY >= dX / 2))
                        {
                            caso = 1;
                            this.posicion = new Vector2(burbuja.posicion.X-radio,burbuja.posicion.Y-2*radio);
                            this.rectangulo = new Rectangle((int)posicion.X, (int)posicion.Y, rWidth, rHeight);

                        }
                        else if (dX>dY)
                        {
                            caso = 3;
                            this.posicion = new Vector2(burbuja.posicion.X-2*radio, burbuja.posicion.Y);
                            this.rectangulo = new Rectangle((int)posicion.X, (int)posicion.Y, rWidth, rHeight);

                        }
                        else
                        {
                            caso = 1;
                            this.posicion = new Vector2(burbuja.posicion.X - radio, burbuja.posicion.Y - 2 * radio);
                            this.rectangulo = new Rectangle((int)posicion.X, (int)posicion.Y, rWidth, rHeight);
                        }

                    }
                    else
                    {
                        if (dX == dY || (dX < dY && dX >= dY / 2) || (dY < dX && dY >= dX / 2))
                        {
                            caso = 5;
                            this.posicion = new Vector2(burbuja.posicion.X-radio, burbuja.posicion.Y+2*radio);
                            this.rectangulo = new Rectangle((int)posicion.X, (int)posicion.Y, rWidth, rHeight);
                        }
                        else if (dX > dY)
                        {
                            caso = 3;
                            this.posicion = new Vector2(burbuja.posicion.X - 2 * radio, burbuja.posicion.Y);
                            this.rectangulo = new Rectangle((int)posicion.X, (int)posicion.Y, rWidth, rHeight);
                        }
                        else
                        {
                            caso = 5;
                            this.posicion = new Vector2(burbuja.posicion.X - radio, burbuja.posicion.Y + 2 * radio);
                            this.rectangulo = new Rectangle((int)posicion.X, (int)posicion.Y, rWidth, rHeight);
                        }

                    }

                }

                else
                {
                    if (this.posicion.Y <= burbuja.posicion.Y)
                    {
                        if (dX == dY || (dX < dY && dX >= dY / 2) || (dY < dX && dY >= dX / 2))
                        {
                            caso = 2;
                            this.posicion = new Vector2(burbuja.posicion.X+radio, burbuja.posicion.Y-2*radio);
                            this.rectangulo = new Rectangle((int)posicion.X, (int)posicion.Y, rWidth, rHeight);
                        }
                        else if (dX > dY)
                        {
                            caso = 4;
                            this.posicion = new Vector2(burbuja.posicion.X+2*radio, burbuja.posicion.Y);
                            this.rectangulo = new Rectangle((int)posicion.X, (int)posicion.Y, rWidth, rHeight);
                        }
                        else
                        {
                            caso = 2;
                            this.posicion = new Vector2(burbuja.posicion.X + radio, burbuja.posicion.Y - 2 * radio);
                            this.rectangulo = new Rectangle((int)posicion.X, (int)posicion.Y, rWidth, rHeight);
                        }

                    }
                    else
                    {
                        if (dX == dY || (dX < dY && dX >= dY / 2) || (dY < dX && dY >= dX / 2))
                        {
                            caso = 6;
                            this.posicion = new Vector2(burbuja.posicion.X+radio, burbuja.posicion.Y+2*radio);
                            this.rectangulo = new Rectangle((int)posicion.X, (int)posicion.Y, rWidth, rHeight);
                        }
                        else if (dX > dY)
                        {
                            caso = 4;
                            this.posicion = new Vector2(burbuja.posicion.X + 2 * radio, burbuja.posicion.Y);
                            this.rectangulo = new Rectangle((int)posicion.X, (int)posicion.Y, rWidth, rHeight);
                        }
                        else
                        {
                            caso = 6;
                            this.posicion = new Vector2(burbuja.posicion.X + radio, burbuja.posicion.Y + 2 * radio);
                            this.rectangulo = new Rectangle((int)posicion.X, (int)posicion.Y, rWidth, rHeight);
                        }

                    }

                }

            }
            
            /*
            if ((Math.Pow(((double) this.centro.X - (double)burbuja.centro.X), 2)+ Math.Pow(((double)this.centro.Y - (double)burbuja.centro.Y), 2))<(this.radio+burbuja.radio))
            {
                
                this.velocidadX = 0;
                this.velocidadY = 0;
                if (this.color==burbuja.color)
                {
                    burbuja.mismoColor += 1;
                    this.mismoColor += 1;
                }
                double distX=Math.Abs(this.centro.X-burbuja.centro.X);
                double distY=Math.Abs(this.centro.Y-burbuja.centro.Y);
                
                if (this.centro.X<burbuja.centro.X)
                {
                    if (this.centro.Y >= burbuja.centro.Y)
                    {
                        if (distX==distY || (distX<distY && distX>=distY/2) || (distY < distX && distY >= distX / 2))
                        {
                            caso = 1;
                            this.posicion.X = burbuja.posicion.X - radio;
                            this.posicion.Y = burbuja.posicion.Y - radio;
                            this.centro.X = burbuja.centro.X - radio;
                            this.centro.Y = burbuja.centro.Y - radio;

                        }
                        else if (distX>distY)
                        {
                            this.posicion.X = burbuja.posicion.X - radio;
                            this.posicion.Y = burbuja.posicion.Y;
                            this.centro.X = burbuja.centro.X - radio;
                            this.centro.Y = burbuja.centro.Y;
                            caso = 4;
                        }
                        else
                        {
                            this.posicion.X = burbuja.posicion.X;
                            this.posicion.Y = burbuja.posicion.Y - radio;
                            this.centro.X = burbuja.centro.X;
                            this.centro.Y = burbuja.centro.Y - radio;
                            caso = 2;
                        }
                    }
                    else if (this.posicion.Y<burbuja.posicion.Y)
                    {
                        if (distX == distY || (distX < distY && distX >= distY / 2) || (distY < distX && distY >= distX / 2))
                        {
                            this.posicion.X = burbuja.posicion.X - radio;
                            this.posicion.Y = burbuja.posicion.Y + radio;
                            this.centro.X = burbuja.centro.X - radio;
                            this.centro.Y = burbuja.centro.Y + radio;
                            caso = 6;
                        }
                        else if (distX>distY)
                        {
                            this.posicion.X = burbuja.posicion.X - radio;
                            this.posicion.Y = burbuja.posicion.Y;
                            this.centro.X = burbuja.centro.X - radio;
                            this.centro.Y = burbuja.centro.Y;
                            caso = 4;
                        }
                        else
                        {
                            this.posicion.X = burbuja.posicion.X;
                            this.posicion.Y = burbuja.posicion.Y+radio;
                            this.centro.X = burbuja.centro.X;
                            this.centro.Y = burbuja.centro.Y + radio;
                            caso = 7;
                        }

                    }
                    
                }
                else
                {
                    if (this.posicion.Y >= burbuja.posicion.Y)
                    {
                        if (distX == distY || (distX < distY && distX >= distY / 2) || (distY < distX && distY >= distX / 2))
                        {
                            this.posicion.X = burbuja.posicion.X + radio;
                            this.posicion.Y = burbuja.posicion.Y - radio;
                            this.centro.X = burbuja.centro.X + radio;
                            this.centro.Y = burbuja.centro.Y - radio;
                            caso = 3;
                        }
                        else if (distX > distY)
                        {
                            this.posicion.X = burbuja.posicion.X + radio;
                            this.posicion.Y = burbuja.posicion.Y;
                            this.centro.X = burbuja.centro.X + radio;
                            this.centro.Y = burbuja.centro.Y;
                            caso = 5;
                        }
                        else
                        {
                            this.posicion.X = burbuja.posicion.X;
                            this.posicion.Y = burbuja.posicion.Y - radio;
                            this.centro.X = burbuja.centro.X;
                            this.centro.Y = burbuja.centro.Y - radio;
                            caso = 2;
                        }
                    }
                    else if (this.posicion.Y < burbuja.posicion.Y)
                    {
                        if (distX == distY || (distX < distY && distX >= distY / 2) || (distY < distX && distY >= distX / 2))
                        {
                            this.posicion.X = burbuja.posicion.X + radio;
                            this.posicion.Y = burbuja.posicion.Y + radio;
                            this.centro.X = burbuja.centro.X + radio;
                            this.centro.Y = burbuja.centro.Y + radio;
                            caso = 8;
                        }
                        else if (distX > distY)
                        {
                            this.posicion.X = burbuja.posicion.X + radio;
                            this.posicion.Y = burbuja.posicion.Y;
                            this.centro.X = burbuja.centro.X + radio;
                            this.centro.Y = burbuja.centro.Y;
                            caso = 5;
                        }
                        else
                        {
                            this.posicion.X = burbuja.posicion.X;
                            this.posicion.Y = burbuja.posicion.Y + radio;
                            this.centro.X = burbuja.centro.X;
                            this.centro.Y = burbuja.centro.Y + radio;
                            caso = 7;
                        }

                    }

                }
                

        }*/
            return caso;

        }


        public override void Actualizar(GameTime tiempo)
        {

                posicion.X += velocidadX;
                posicion.Y += velocidadY;
                //centro.X = posicion.X + radio;
                //centro.Y = posicion.Y + radio;
                this.rectangulo = new Rectangle((int)posicion.X, (int)posicion.Y, rWidth, rHeight);
                colisionPared(ancho, alto);

        }

        public override void Dibujar(GameTime tiempo, SpriteBatch spriteBatch)
        {
            var colour = Color.White;
            spriteBatch.Draw(color,posicion,null,Color.White, 0f,Vector2.Zero, escala, SpriteEffects.None, 0f);
            //spriteBatch.Draw(color, posicion,null,null,posicion,0,escala,colour);
        }
        #endregion
    }
}
