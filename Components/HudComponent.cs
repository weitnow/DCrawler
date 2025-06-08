using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonoGame.Extended.Sprites;

namespace RheinwerkAdventure.Components;

internal class HudComponent : DrawableGameComponent
{
    private SpriteBatch spriteBatch;
    private RheinwerkGame game;
    private SpriteFont hudFont;

    public HudComponent(RheinwerkGame game) : base(game)
    {
        this.game = game;
    }

    protected override void LoadContent()
    {
        spriteBatch = new SpriteBatch(GraphicsDevice);
        hudFont = game.Content.Load<SpriteFont>("HudSpritefont");

    }

    public override void Draw(GameTime gameTime)
    {
        spriteBatch.Begin();
        spriteBatch.DrawString(hudFont, "Development Version", new Vector2(20, 20), Color.White);
        spriteBatch.End();
    }

}
