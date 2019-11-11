//*Agradecimientos hasta la fecha: Chlorinar Font: Caffen Fonts
// <a href = "https://www.freepik.com/free-photos-vectors/frame" > Frame vector created by starline - www.freepik.com</a>
// Photo by Josephine Bredehoft on Unsplash 



using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using BubbleBlower.Estados;

namespace BubbleBlower
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        GraphicsDeviceManager graficos;
        SpriteBatch spriteBatch;
        private Texture2D background;
        private bool effectosSonido;
        private bool musica;
        private int vol;



        private Estado estadoActual;
        private Estado estadoSiguiente;

        public void setEffectosSonido(bool efectosSonido)
        {
            this.effectosSonido = efectosSonido;
        }
        public bool getEffectosSonido()
        {
            return this.effectosSonido;
        }

        public void setMusica(bool music)
        {
            this.musica = music;
        }
        public bool getMusica()
        {
            return this.musica;
        }
        
        public int getVol()
        {
            return this.vol;
        }

        public void setVol(int volumen)
        {
            this.vol = volumen;
        }




        public void cambiarEstado(Estado estado)
        {
            estadoSiguiente = estado;
        }
        
        public Game1()
        {
            graficos = new GraphicsDeviceManager(this);
            setMusica(true);
            setEffectosSonido(true);
            setVol(100);
            graficos.PreferredBackBufferWidth = 3 * GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Width / 4;  // set this value to the desired width of your window
            graficos.PreferredBackBufferHeight = 3 * GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Height / 4;   // set this value to the desired height of your window
            graficos.ApplyChanges();
            Content.RootDirectory = "Content";
        } 

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            IsMouseVisible = true;
            base.Initialize();

        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            background = Content.Load<Texture2D>("Controles/background");
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);
            estadoActual = new EstadoMenu(this, graficos.GraphicsDevice, Content);
            // TODO: use this.Content to load your game content here
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime tiempo)
        {
            if (estadoSiguiente!=null)
            {
                estadoActual = estadoSiguiente;
                estadoSiguiente = null;
            }
            estadoActual.Actualizar(tiempo);
            estadoActual.PosActualizado(tiempo);
            base.Update(tiempo);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime tiempo)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            spriteBatch.Begin();

            spriteBatch.Draw(background, new Rectangle(0, 0,2*GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Height,2*GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Width), Color.White);

            spriteBatch.End();
            estadoActual.Dibujar(tiempo, spriteBatch);

            base.Draw(tiempo);
        }
    }
}
