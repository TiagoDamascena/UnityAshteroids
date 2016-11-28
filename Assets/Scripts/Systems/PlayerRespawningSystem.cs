using Assets.Scripts.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ash.Core;
using Assets.Scripts.Nodes;
using UnityEngine;

namespace Assets.Scripts.Systems
{
    /// <summary>
    /// Player respawning system. Controls the respawn of the player spaceship.
    /// </summary>
	public class PlayerRespawningSystem : ISystem
    {
        private readonly EntityCreator _creator;

        private INodeList<GameNode> _gameNodes;
        private INodeList<Node<Asteroid, Transform>> _asteroids;
        private INodeList<SpaceshipNode> _spaceships;
        private INodeList<Node<MainMenu>> _mainMenus;
		private INodeList<Node<HighScore>> _highScore;

		/// <summary>
		/// Initializes a new instance of the <see cref="Assets.Scripts.Systems.PlayerRespawningSystem"/> class.
		/// </summary>
		/// <param name="creator">Creator.</param>
        public PlayerRespawningSystem(EntityCreator creator)
        {
            _creator = creator;
        }

		/// <summary>
		/// On this system is added to engine.
		/// </summary>
		/// <param name="engine">Engine.</param>
        public void AddedToEngine(IEngine engine)
        {
            _gameNodes = engine.GetNodes<GameNode>();
            _asteroids = engine.GetNodes<Node<Asteroid, Transform>>();
            _spaceships = engine.GetNodes<SpaceshipNode>();
            _mainMenus = engine.GetNodes<Node<MainMenu>>();
			_highScore = engine.GetNodes<Node<HighScore>> ();
        }

		/// <summary>
		/// On this system is removed from engine.
		/// </summary>
		/// <param name="engine">Engine.</param>
        public void RemovedFromEngine(IEngine engine)
        {
        }

        public void Update(float delta)
        {
            foreach (var game in _gameNodes)
            {
                if (!game.State.playing)
                    continue;

                if (!_spaceships.Any())
                    RespawnPlayer(game);
            }
        }

		/// <summary>
		/// Respawns the player.
		/// </summary>
		/// <param name="game">Game.</param>
        private void RespawnPlayer(GameNode game)
        {
            if (game.State.lives > 0)
            {
                if (IsClearToAddShip(Vector2.zero))
                    _creator.CreateSpaceship();
            }
            else
            {
                game.State.playing = false;
				if (game.State.score >int.Parse(_highScore.First ().Component1.view.score.text)) {
					_highScore.First ().Component1.view.score.text = game.State.score.ToString ();
					_highScore.First ().Component1.view.name.text = "";
					_highScore.First ().Component1.view.Show ();
				} else {
					_highScore.First ().Component1.view.Hide ();
					_mainMenus.First().Component1.view.Show();
				}
            }
        }

		/// <summary>
		/// Determines whether this instance is clear to add ship the specified position.
		/// </summary>
		/// <returns><c>true</c> if this instance is clear to add ship the specified newSpaceshipPosition; otherwise, <c>false</c>.</returns>
		/// <param name="newSpaceshipPosition">New spaceship position.</param>
        private bool IsClearToAddShip(Vector2 newSpaceshipPosition)
        {
            foreach (var asteroid in _asteroids)
                if (Vector2.Distance(asteroid.Component2.position, newSpaceshipPosition) <= 3)
                    return false;

            return true;
        }
    }
}
