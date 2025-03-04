﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;

namespace clicker_game
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        Rectangle window;

        Texture2D moneyTexture;
        Rectangle moneyRect;
        Vector2 moneySpeed;

        Texture2D fallingmoneyTexture;
        Rectangle fallingmoneyRect, moneyfallingrect2;

        Random Random = new Random();

        Texture2D buttonTexture;
        Rectangle buttonRect;
        Texture2D boxTexture;
        Rectangle boxRect1;
        Rectangle boxRect2;
        Texture2D  introbox;
        Texture2D factoryTexture;
        Rectangle factoryRect1, factoryRect2, factoryRect3, factoryRect4, factoryRect5, factoryRect6, factoryRect7, factoryRect8, factoryRect9, factoryRect10;
        MouseState mouseState;
        MouseState prevmouseState;
        SpriteFont pointsFont, pointsFont1;
        Texture2D coolbackround;
        float points;
        float clickPower;
        float clickUpgrade, factoryUpgrade;
        float clickUpgradeIncrease, factoryUpgradeIncrease;
        float clickpowerincrease;
        bool done1, moneydraw, moneydraw2, timebool, done5, done6, done7, done8, done9, done10;
        float seconds, totalTime, randomnumber, clickpowerbefore, number;


        List<Rectangle> factories;
        

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
            factories = new List<Rectangle>();

            window = new Rectangle(0, 0, 800, 600);
            buttonRect = new Rectangle(0, 0, 350, 350);
            boxRect1 = new Rectangle(500, 0, 350, 125);
            boxRect2 = new Rectangle(500, 125, 350, 125);
            moneySpeed = new Vector2(5, 5);
            moneyRect = new Rectangle(0, 0, 100, 100);
            fallingmoneyRect = new Rectangle(0, -600, 800, 600);
            moneyfallingrect2 = new Rectangle(0, -1200, 800, 600);




            _graphics.PreferredBackBufferWidth = 800;
            _graphics.PreferredBackBufferHeight = 600;
            _graphics.ApplyChanges();
            points = 500;
            clickPower = 1;
            clickUpgrade = 50;
            factoryUpgrade = 200;
            clickUpgradeIncrease = 50;
            factoryUpgradeIncrease = 100;
            clickpowerincrease = 4;
            done1 = true;
            moneydraw = true;
            moneydraw2 = false;
            timebool = false;
            number = 0;
            
            seconds = 0;
            totalTime = 0;
            randomnumber = Random.Next(1,10);
            clickpowerbefore = 0;

        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here

            buttonTexture = Content.Load<Texture2D>("button");
            pointsFont = Content.Load<SpriteFont>("pointsFont");
            pointsFont1 = Content.Load<SpriteFont>("pointsFont1");
            boxTexture = Content.Load<Texture2D>("beige box");
            factoryTexture = Content.Load<Texture2D>("Factory");
            coolbackround = Content.Load<Texture2D>("cool background (1)");
            introbox = Content.Load<Texture2D>("intro (1)");
            moneyTexture = Content.Load<Texture2D>("money");
            fallingmoneyTexture = Content.Load<Texture2D>("canva money falling");
        }

        protected override void Update(GameTime gameTime)
        {

            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();
            prevmouseState = mouseState;
            mouseState = Mouse.GetState();
            this.Window.Title = $"x = {mouseState.X}, y = {mouseState.Y}";



            totalTime += (float)gameTime.ElapsedGameTime.TotalSeconds;
            seconds += (float)gameTime.ElapsedGameTime.TotalSeconds;
            if (factories.Count > 0)
            {
                if (seconds > 1)
                {
                    points += factories.Count + 10;
                    seconds = 0;
                }
            }

            if (factories.Count > 3)
            {
                if (seconds > 1)
                {
                    points += factories.Count + 20;
                    seconds = 0;
                }
            }

            if (factories.Count > 5)
            {
                if (seconds > 1)
                {
                    points += factories.Count + 40;
                    seconds = 0;
                }
            }

            if (factories.Count > 10)
            {
                if (seconds > 1)
                {
                    points += factories.Count + 75;
                    seconds = 0;
                }
            }

            if (factories.Count > 5)
            {
                if (seconds > 1)
                {
                    points += factories.Count + 15;
                    seconds = 0;
                }
            }


            if (mouseState.LeftButton == ButtonState.Pressed && prevmouseState.LeftButton == ButtonState.Released)
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

                    points += clickPower;
                }
            }

            if (points >= clickUpgrade)
            {
                if (mouseState.LeftButton == ButtonState.Pressed && prevmouseState.LeftButton == ButtonState.Released)
                {
                    if (boxRect1.Contains(mouseState.Position))
                    {
                        clickPower += clickpowerincrease;
                        points -= clickUpgrade;
                        clickUpgrade += clickUpgradeIncrease;

                    }
                }
            }
            if(clickUpgrade == 100)
            {
                clickpowerincrease = 2;
            }
            if (clickUpgrade >= 200)
            {
                clickUpgradeIncrease = 75;
                clickpowerincrease = 2;
            }
            if (clickUpgrade >= 400)
            {
                clickpowerincrease = 2;
                clickUpgradeIncrease = 100;
            }
            if (clickUpgrade >= 800)
            {
                clickUpgradeIncrease += 100;
            }
            if (mouseState.LeftButton == ButtonState.Released)
            {

                
              buttonRect.X = 0;
              buttonRect.Y = 0;
              buttonRect = new Rectangle(0, 0, 350, 350);
                
            }

            moneyRect.X += (int)moneySpeed.X;
            moneyRect.Y += (int)moneySpeed.Y;
            if (moneyRect.Right > window.Width || moneyRect.Left < 0)
            {
                moneySpeed.X *= -1;
            }

            if (moneyRect.Bottom > window.Height || moneyRect.Top < 0)
            {
                
                moneySpeed.Y *= -1;
            }

            if (totalTime >= randomnumber)
            {
                timebool = true;
                if(timebool == true && moneydraw2 == false)
                    totalTime = randomnumber;
                if (moneydraw2 == false)
                {
                    moneydraw = false;
                }
                if(mouseState.LeftButton == ButtonState.Pressed && prevmouseState.LeftButton == ButtonState.Released)
                {
                    if(moneyRect.Contains(mouseState.Position))
                    {
                        clickpowerbefore = clickPower;
                        clickPower *= 5;

                        moneydraw = true;
                        moneydraw2 = true;

                    }

                }
                if (totalTime >= randomnumber && totalTime <= randomnumber + 30)
                {
                    if (moneydraw2 == true)
                    {
                        fallingmoneyRect.Y += 12;
                        moneyfallingrect2.Y += 12;
                        if(fallingmoneyRect.Y >= 600)
                        {
                            fallingmoneyRect.Y = -600;
                        }
                        if (moneyfallingrect2.Y >= 600)
                        {
                            moneyfallingrect2.Y = -600;
                        }

                    }
                }
                if (totalTime >= randomnumber + 30 && number == 0)
                {
                    clickPower -= clickpowerbefore;
                }
                number = 5;
            }






            if (points >= factoryUpgrade)
            {
                if (mouseState.LeftButton == ButtonState.Pressed && prevmouseState.LeftButton == ButtonState.Released)
                {
                    if (boxRect2.Contains(mouseState.Position))
                    {
                        factories.Add(new Rectangle(factories.Count * 25, 300, 25, 25));
                        points -= factoryUpgrade;
                        factoryUpgrade += factoryUpgradeIncrease;

                    }
                }
            }

            if (mouseState.LeftButton == ButtonState.Pressed && prevmouseState.LeftButton == ButtonState.Released)
                done1 = false;


                // TODO: Add your update logic here

                base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here
            _spriteBatch.Begin();
            _spriteBatch.Draw(coolbackround, window, Color.White);
           
            _spriteBatch.Draw(buttonTexture, buttonRect, Color.White);
            _spriteBatch.DrawString(pointsFont1, points.ToString(" points: 00"), new Vector2(250, 0), Color.Black);
            
            _spriteBatch.Draw(boxTexture, boxRect1, Color.Orange);
            _spriteBatch.Draw(boxTexture, boxRect2, Color.Green);
            _spriteBatch.DrawString(pointsFont, points.ToString("add a factory"), new Vector2(580, 145), Color.Black);
            _spriteBatch.DrawString(pointsFont, clickPower.ToString("current click power: 00"), new Vector2(530, 50), Color.Black);

            _spriteBatch.DrawString(pointsFont, points.ToString("upgrade click power"), new Vector2(580, 20), Color.Black);
            foreach (Rectangle factory in factories)
                _spriteBatch.Draw(factoryTexture, factory, Color.White);
            _spriteBatch.DrawString(pointsFont, clickUpgrade.ToString("cost: 00 points"), new Vector2(650, 75), Color.Black);
            _spriteBatch.DrawString(pointsFont, factoryUpgrade.ToString("cost: 00 points"), new Vector2(650, 200), Color.Black);
            if(moneydraw == false)
                _spriteBatch.Draw(moneyTexture, moneyRect, Color.White);
            if (done1 == true)
            {
                _spriteBatch.Draw(introbox, window, Color.White);
            }
            if (totalTime >= randomnumber && totalTime <= randomnumber + 30)
            {
                if (moneydraw2 == true)
                {
                    _spriteBatch.Draw(fallingmoneyTexture, moneyfallingrect2, Color.White);
                    _spriteBatch.Draw(fallingmoneyTexture,fallingmoneyRect, Color.White);
                }
            }



            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
