using System;
using System.Linq;
using Dungeoncrawler.Model;
using Microsoft.Xna.Framework;

namespace Dungeoncrawler;

internal class SimulationComponent : GameComponent
{
    private readonly RheinwerkGame game;

    public World World
    {
        get;
        private set;
    }

    public Player Player
    {
        get;
        private set;
    }

    public Vector2 Position
    {
        get;
        set;
    }

    public SimulationComponent(RheinwerkGame game) : base(game)
    {
        this.game = game;
        NewGame();
    }

    public override void Update(GameTime gameTime)
    {
        #region Player Input

        Player.Velocity = game.Input.Movement * 10f;

        #endregion

        #region Character Movement

        foreach (var area in World.Areas)
        {
            foreach (var character in area.Items.OfType<Character>())
            {
                character.Position += character.Velocity * (float)gameTime.ElapsedGameTime.TotalSeconds;

                foreach (var item in area.Items)
                {
                    if (item == character) continue;

                    Vector2 distance = item.Position - character.Position;
                    float overlap = item.Radius + character.Radius - distance.Length();
                    if (overlap > 0f)
                    {
                        Vector2 resolution = distance * (overlap / distance.Length());
                        if (item.Fixed && !character.Fixed)
                        {

                        }
                        else if (!item.Fixed && character.Fixed)
                        {

                        }
                        else if (!item.Fixed && !character.Fixed)
                        {

                        }

                    }
                }
            }
        }

        #endregion


        base.Update(gameTime);
    }

    public void NewGame()
    {
        World = new World();

        Area area = new Area(2, 30, 20);
        for (int x = 0; x < area.Width; x++)
        {
            for (int y = 0; y < area.Height; y++)
            {
                area.Layers[0].Tiles[x, y] = new Tile();
                area.Layers[1].Tiles[x, y] = new Tile();

                if (x == 0 || y == 0 || x == area.Width - 1 || y == area.Height - 1)
                    area.Layers[0].Tiles[x, y].Blocked = true;
            }
        }

        Player = new Player() { Position = new Vector2(15, 10), Radius = 0.25f };
        Diamant diamant = new Diamant() { Position = new Vector2(10, 10), Radius = 0.25f };

        area.Items.Add(Player);
        area.Items.Add(diamant);

        World.Areas.Add(area);

    }
}
