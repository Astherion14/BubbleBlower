//Agradecimientos hasta la fecha: 

//nightWalk by airtone (c) copyright 2017 Licensed under a Creative Commons Attribution (3.0) license. http://dig.ccmixter.org/files/airtone/56520 



using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Audio;
using BubbleBlower.Estados;
using Microsoft.Xna.Framework.Media;
using System.Collections.Generic;


namespace BubbleBlower
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        List<SoundEffect> soundEffects;
        GraphicsDeviceManager graficos;
        SpriteBatch spriteBatch;
        private Texture2D background;
        private bool effectosSonido;
        private bool musica;
        private float vol;
        private bool limpiar;
        private bool cambioMusic;
        private Song musicaBackground;
        private int puntuacion;


        private Estado estadoActual;
        private Estado estadoSiguiente;


        public void setPuntuacion(int puntuacion)
        {
            this.puntuacion = puntuacion;
        }
        public int getPuntuacion()
        {
            return this.puntuacion;
        }
        public void setCambioMusic(bool cambio)
        {
            this.cambioMusic = cambio;
        }
        public bool getCambioMusic()
        {
            return cambioMusic;
        }
        public void setLimpiar(bool limp)
        {
            this.limpiar = limp;
        }
        public bool getLimpiar()
        {
            return this.limpiar;
        }
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

        public float getVol()
        {
            return this.vol;
        }

        public void setVol(float volumen)
        {
            if (volumen < 0)
            {
                this.vol = 0;
            }
            else if (volumen > 100)
            {
                this.vol = 100;
            }
            else
            {
                this.vol = volumen;
            }
        }


        public void reproducirEfecto(int efecto){ 
            if(effectosSonido){
                soundEffects[efecto].Play();
            }
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
            setLimpiar(false);
            setCambioMusic(true);
            graficos.PreferredBackBufferWidth = 3 * GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Width / 4;  // set this value to the desired width of your window
            graficos.PreferredBackBufferHeight = 3 * GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Height / 4;   // set this value to the desired height of your window
            graficos.ApplyChanges();
            Content.RootDirectory = "Content";
            soundEffects = new List<SoundEffect>();
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
            soundEffects.Add(Content.Load<SoundEffect>("Sonidos/colision"));
            soundEffects.Add(Content.Load<SoundEffect>("Sonidos/plop"));
            background = Content.Load<Texture2D>("Controles/background");
            musicaBackground = Content.Load<Song>("Sonidos/fondo");
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);
            estadoActual = new EstadoMenu(this, graficos.GraphicsDevice, Content);
            MediaPlayer.Play(musicaBackground);
            MediaPlayer.IsRepeating = true;
            MediaPlayer.Volume = vol/100;
            cambioMusic = false;
            
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
            if (estadoSiguiente != null)
            {
                estadoActual = estadoSiguiente;
                estadoSiguiente = null;
            }

            if (cambioMusic)
            {
                if (!musica)
                {
                    MediaPlayer.IsMuted = true;
                }
                if (musica)
                {
                    MediaPlayer.IsMuted = false;
                }
                SoundEffect.MasterVolume=vol/100;
                MediaPlayer.Volume = vol / 100;
                cambioMusic=false;
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

            spriteBatch.Draw(background, new Rectangle(0, 0, 2 * GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Height, 2 * GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Width), Color.White);

            spriteBatch.End();
            estadoActual.Dibujar(tiempo, spriteBatch);

            base.Draw(tiempo);
        }
    }
}
