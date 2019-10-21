using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BubbleBlower
{
    public abstract class Componente
    {
        public abstract void Dibujar(GameTime tiempo, SpriteBatch sprite);

        public abstract void Actualizar(GameTime tiempo);
    }
}
