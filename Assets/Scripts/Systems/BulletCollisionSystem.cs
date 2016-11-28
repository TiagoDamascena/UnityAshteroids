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
    /// Bullet collision system. Control the colision of the bullets.
    /// </summary>
	public class BulletCollisionSystem : NodelessSystem<Bullet, Collisions, Entity>
    {
        private INodeList<GameNode> _games;

        public BulletCollisionSystem()
        {
            _updateCallback = OnUpdate;
            _addedToEngineCallback = OnAddedToEngine;
        }

		/// <summary>
		/// On this node added to engine event.
		/// </summary>
		/// <param name="engine">Engine.</param>
        private void OnAddedToEngine(IEngine engine)
        {
            _games = engine.GetNodes<GameNode>();
        }

        private void OnUpdate(float delta, Bullet bullet, Collisions collisions, Entity entity)
        {
            var game = _games.First();
            foreach (var hit in collisions.hits)
            {
                var asteroid = hit.gameObject.GetComponent<Asteroid>();
                if (asteroid == null)
                    continue;

                asteroid.GetComponent<Hitpoints>().hp--;

				game.State.hits++;
              	
				if (asteroid.size == AsteroidSize.Large) {
					game.State.score += 20;
				} else if (asteroid.size == AsteroidSize.Medium) {
					game.State.score += 50;
				} else {
					game.State.score += 100;
				}

                entity.Destroy();
            }

            collisions.hits.Clear();
        }
    }
}
