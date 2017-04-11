using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace TheQuest
{
    class Ghost : Enemy
    {
        public Ghost(Game game, Point location) :
            base(game, location, 8)
        { }

        public override void Move(Random random)
        {
            Console.WriteLine("Ghost location: {0}", this.location.ToString());
            bool moveTowardPlayer = false;
            if (random.Next(0, 100) < 50)
            {
                moveTowardPlayer = true;
            }

            if (moveTowardPlayer)
                location = Move(FindPlayerDirection(game.PlayerLocation), game.Boundaries);
            else
                location = Move((Direction)random.Next(1, 4), game.Boundaries);

            if (NearPlayer())
            {
                game.HitPlayer(2, random);
            }
        }
    }
}
