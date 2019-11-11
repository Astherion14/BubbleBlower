using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace BubbleBlower.Estados
{
    public class EstadoRecords : Estado
    {
        public EstadoRecords(Game1 juego, GraphicsDevice graficos, ContentManager contenido)
        : base(juego, graficos, contenido)
        {

        }
        public override void Actualizar(GameTime tiempo)
        {
        }

        public override void Dibujar(GameTime tiempo, SpriteBatch spriteBatch)
        {
        }

        public override void PosActualizado(GameTime tiempo)
        {
        }
    }
}