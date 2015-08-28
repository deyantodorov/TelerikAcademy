namespace Santase.Logic.Players
{
    using System;

    public class Player : BasePlayer
    {
        public Player()
            : base()
        {
        }

        public override PlayerAction GetTurn(PlayerTurnContext context, IPlayerActionValidater actionValidater)
        {
            // TODO: Need to be implemented
            return null;
        }
    }
}
