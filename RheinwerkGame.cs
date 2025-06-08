using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using RheinwerkAdventure.Components;

namespace RheinwerkAdventure;

internal class RheinwerkGame : Game
{
    private GraphicsDeviceManager _graphics;

    public HudComponent Hud
    {
        get;
        private set;
    }

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

        Hud = new HudComponent(this);
        Hud.UpdateOrder = 3;
        Hud.DrawOrder = 1;
        Components.Add(Hud);
    }

    protected override void Initialize()
    {
        // TODO: Add your initialization logic here

        base.Initialize();
    }

    protected override void Update(GameTime gameTime)
    {
        if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
            Exit();

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
        
        // Increment frame counter
        frameCounter++;

        base.Draw(gameTime);
    }
}
