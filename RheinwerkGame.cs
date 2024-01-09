using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;

namespace Dungeoncrawler;

public class RheinwerkGame : Game
{
    private GraphicsDeviceManager _graphics;
    private SpriteBatch _spriteBatch;

    // Variables for FPS calculation
    int frameRate = 0;
    int frameCounter = 0;
    TimeSpan elapsedTime = TimeSpan.Zero;

    internal InputComponent Input
    {
        get;
        private set;
    }

    internal SimulationComponent Simulation
    {
        get;
        private set;
    }

    internal SceneComponent Scene
    {
        get;
        private set;
    }

    public RheinwerkGame()
    {
        _graphics = new GraphicsDeviceManager(this);
        Content.RootDirectory = "Content";
        IsMouseVisible = true;
        _graphics.IsFullScreen = false;


        Input = new InputComponent(this);
        Input.UpdateOrder = 0;
        Components.Add(Input);

        Simulation = new SimulationComponent(this);
        Simulation.UpdateOrder = 1;
        Components.Add(Simulation);

        Scene = new SceneComponent(this);
        Scene.UpdateOrder = 2;
        Scene.DrawOrder = 0;
        Components.Add(Scene);
    }

    protected override void Initialize()
    {
        // TODO: Add your initialization logic here

        base.Initialize();
    }

    protected override void LoadContent()
    {
        _spriteBatch = new SpriteBatch(GraphicsDevice);

        // TODO: use this.Content to load your game content here
    }

    protected override void Update(GameTime gameTime)
    {
        if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
            Exit();

        // TODO: Add your update logic here

        // Update FPS calculation
        elapsedTime += gameTime.ElapsedGameTime;

        if (elapsedTime > TimeSpan.FromSeconds(1))
        {
            elapsedTime -= TimeSpan.FromSeconds(1);
            frameRate = frameCounter;
            frameCounter = 0;
            Window.Title = "FPS: " + frameRate.ToString();
        }


        base.Update(gameTime);
    }

    protected override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(Color.Blue);

        // TODO: Add your drawing code here

        // Increment frame counter
        frameCounter++;

        base.Draw(gameTime);
    }
}
