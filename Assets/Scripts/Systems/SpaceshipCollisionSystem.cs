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
    /// Spaceship collision system. Controls the collision of the spaceship.
    /// </summary>
	public class SpaceshipCollisionSystem : NodelessSystem<Spaceship, Transform, Entity, Collisions>
    {
        private readonly EntityCreator _creator;
        private INodeList<GameNode> _games;

		/// <summary>
		/// Initializes a new instance of the <see cref="Assets.Scripts.Systems.SpaceshipCollisionSystem"/> class.
		/// </summary>
		/// <param name="creator">Creator.</param>
        public SpaceshipCollisionSystem(EntityCreator creator)
        {
            _creator = creator;
            _updateCallback = OnUpdate;
            _addedToEngineCallback = OnAddedToEngine;
        }

		/// <summary>
		/// Raises the added to engine event.
		/// </summary>
		/// <param name="engine">Engine.</param>
        private void OnAddedToEngine(IEngine engine)
        {
            _games = engine.GetNodes<GameNode>();
        }

		/// <summary>
		/// Raises the update event.
		/// </summary>
		/// <param name="arg1">Arg1.</param>
		/// <param name="spaceship">Spaceship.</param>
		/// <param name="transform">Transform.</param>
		/// <param name="entity">Entity.</param>
		/// <param name="collisions">Collisions.</param>
        private void OnUpdate(float arg1, Spaceship spaceship, Transform transform, 
            Entity entity, Collisions collisions)
        {
            var game = _games.First();
            foreach (var hit in collisions.hits)
            {
                var asteroid = hit.gameObject.GetComponent<Asteroid>();
                if (asteroid == null)
                    continue;

                _creator.CreateSpaceshipInDeathroes(spaceship.transform);
                entity.Destroy();
                game.State.lives--;
            }

            collisions.hits.Clear();
        }
    }
}
