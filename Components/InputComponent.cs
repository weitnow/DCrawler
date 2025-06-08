using System;
using System.ComponentModel;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace RheinwerkAdventure;

internal class InputComponent : GameComponent
{
    private readonly RheinwerkGame game;

    public Vector2 Movement
    {
        get;
        private set;
    }

    public InputComponent(RheinwerkGame game) : base(game)
    {
        this.game = game;
    }

    public override void Update(GameTime gameTime)
    {
        Vector2 movement = Vector2.Zero;

        // Gamepad Steuerung
        GamePadState gamepad = GamePad.GetState(PlayerIndex.One);
        movement += gamepad.ThumbSticks.Left * new Vector2(1f, -1f);

        // Keyboard Steuerung
        KeyboardState keyboard = Keyboard.GetState();
        if (keyboard.IsKeyDown(Keys.A))
            movement += new Vector2(-1f, 0f);
        if (keyboard.IsKeyDown(Keys.D))
            movement += new Vector2(1f, 0f);
        if (keyboard.IsKeyDown(Keys.W))
            movement += new Vector2(0f, -1f);
        if (keyboard.IsKeyDown(Keys.S))
            movement += new Vector2(0f, 1f);

        if (movement.Length() > 1f)
            movement.Normalize();

        Movement = movement;

        base.Update(gameTime);
    }

}
