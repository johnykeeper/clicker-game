using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace clicker_game
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        Rectangle window;

        Texture2D buttonTexture;
        Rectangle buttonRect;
        MouseState mouseState;
        MouseState prevmouseState;
        SpriteFont pointsfont;
        float points;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;


        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            base.Initialize();

            window = new Rectangle(0, 0, 800, 600);
            buttonRect = new Rectangle(0, 0, 350, 350);


            _graphics.PreferredBackBufferWidth = 800;
            _graphics.PreferredBackBufferHeight = 600;
            _graphics.ApplyChanges();
            points = 0;
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here

            buttonTexture = Content.Load<Texture2D>("button");
            pointsfont = Content.Load<SpriteFont>("pointsFont");
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();
            prevmouseState = mouseState;
            mouseState = Mouse.GetState();
            this.Window.Title = $"x = {mouseState.X}, y = {mouseState.Y}";

            if (mouseState.LeftButton == ButtonState.Pressed)
            {
                if (buttonRect.Contains(mouseState.Position))
                {

                    buttonRect = new Rectangle(0, 0, 325, 325);
                    buttonRect.X = 15;
                    buttonRect.Y = 12;
                }
            }

            if (mouseState.LeftButton == ButtonState.Pressed && prevmouseState.LeftButton == ButtonState.Released) 
            {
                if (buttonRect.Contains(mouseState.Position))
                {

                    points += 1;
                }
            }

            if (mouseState.LeftButton == ButtonState.Released)
            {

                
              buttonRect.X = 0;
              buttonRect.Y = 0;
              buttonRect = new Rectangle(0, 0, 350, 350);
                
            }

            // TODO: Add your update logic here

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here
            _spriteBatch.Begin();
            _spriteBatch.Draw(buttonTexture, buttonRect, Color.White);
            _spriteBatch.DrawString(pointsfont, points.ToString("00"), new Vector2(500, 0), Color.Black);
            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
