﻿using CardGame.Common;
using CardGame.Common.StateMachines;
using CardGame.GameStates;
using CardGame.Systems;

namespace CardGame.Factories
{
    public class GameFactory
    {
        public static Container Create()
        {
            var game = new Container();

            // Add Systems
            game.AddAspect<ActionSystem>();
            game.AddAspect<DataSystem>();
            game.AddAspect<MatchSystem>();

            // Add Others
            game.AddAspect<StateMachine>();
            game.AddAspect<GameState>();

            return game;
        }
    }
}
