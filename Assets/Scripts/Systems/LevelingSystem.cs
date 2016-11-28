using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ash.Core;
using Ash.Helpers;
using Assets.Scripts.Components;
using Assets.Scripts.Nodes;
using UnityEngine;

namespace Assets.Scripts.Systems
{
    /// <summary>
    /// Leveling system. Controls the game level progrssion.
    /// </summary>
	public class LevelingSystem : NodelessSystem<GameState>
    {
        private readonly EntityCreator _creator;
        private readonly GameConfig _config;

        private INodeList<Node<Asteroid>> asteroids;
        private INodeList<SpaceshipNode> spaceships;
        private INodeList<Node<Bullet>> bullets;

        public LevelingSystem(EntityCreator creator, GameConfig config)
        {
            _creator = creator;
            _config = config;
            _updateCallback = OnUpdate;
            _addedToEngineCallback = OnAddedToEngine;
        }

		/// <summary>
		/// On this system is added to engine event.
		/// </summary>
		/// <param name="engine">Engine.</param>
        private void OnAddedToEngine(IEngine engine)
        {
            asteroids = engine.GetNodes<Node<Asteroid>>();
            spaceships = engine.GetNodes<SpaceshipNode>();
            bullets = engine.GetNodes<Node<Bullet>>();
        }

        private void OnUpdate(float delta, GameState state)
        {
            if (IsReadyForNextLevel())
                NextLevel(state);
        }

		/// <summary>
		/// Determines whether this instance is ready for next level.
		/// </summary>
		/// <returns><c>true</c> if this instance is ready for next level; otherwise, <c>false</c>.</returns>
        private bool IsReadyForNextLevel()
        {
            return !asteroids.Any() && !bullets.Any() && spaceships.Any();
        }

		/// <summary>
		/// Nexts the level.
		/// </summary>
		/// <param name="state">State.</param>
        private void NextLevel(GameState state)
        {
            state.level++;

            var asteroidCount = 2 + state.level;
            for (int i = 0; i < asteroidCount; i++)
                SpawnAsteroid();
        }

		/// <summary>
		/// Spawns the asteroid.
		/// </summary>
        private void SpawnAsteroid()
        {
            var spaceship = spaceships.First();
            var position = FindPositionForNewAsteroid(spaceship);
            var asteroid = _creator.CreateAsteroid(AsteroidSize.Large, position);

            // Give it a kick
            var vel = UnityEngine.Random.insideUnitCircle.normalized;
            var torque = vel.x / 2;

            var rigidBody = asteroid.GetComponent<Rigidbody2D>();
            rigidBody.AddForce(vel, ForceMode2D.Impulse);
            rigidBody.AddTorque(torque, ForceMode2D.Impulse);
        }

		/// <summary>
		/// Finds the position for new asteroid.
		/// </summary>
		/// <returns>The position for new asteroid.</returns>
		/// <param name="spaceship">Spaceship.</param>
        private Vector2 FindPositionForNewAsteroid(SpaceshipNode spaceship)
        {
            Vector2 position;
            do
            {
                position = new Vector2(UnityEngine.Random.Range(_config.bounds.min.x, _config.bounds.max.x),
                    UnityEngine.Random.Range(_config.bounds.min.y, _config.bounds.max.y));
            }
            while (Vector2.Distance(position, spaceship.Transform.position) <= 2);
            return position;
        }

    }
}
