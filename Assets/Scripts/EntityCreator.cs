using Assets.Scripts.Components;
using Assets.Scripts.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ash.Core;
using UnityEngine;

namespace Assets.Scripts
{
    /// <summary>
    /// Entity creator. Responsible for the entitys creation.
    /// </summary>
	public class EntityCreator : IEntityCreator
    {
        private readonly PrefabRepository prefabs;

        /// <summary>
        /// Initializes a new instance of the <see cref="Assets.Scripts.EntityCreator"/> class.
        /// </summary>
        /// <param name="prefabs">Prefabs.</param>
		public EntityCreator(PrefabRepository prefabs)
        {
            this.prefabs = prefabs;
        }

		/// <summary>
		/// Creates the game.
		/// </summary>
        public void CreateGame()
        {
            Instantiate(prefabs.game);
        }

		/// <summary>
		/// Creates the spaceship.
		/// </summary>
        public void CreateSpaceship()
        {
            Instantiate(prefabs.spaceship);
        }

		/// <summary>
		/// Creates the spaceship in deathroes.
		/// </summary>
		/// <returns>The spaceship in deathroes.</returns>
		/// <param name="at">At.</param>
        public Entity CreateSpaceshipInDeathroes(Transform at)
        {
            var deathroes = Instantiate(prefabs.spaceshipDeathroes);
            deathroes.transform.position = at.transform.position;
            deathroes.transform.rotation = at.rotation;
            return deathroes;
        }

		/// <summary>
		/// Creates the asteroid in deathroes.
		/// </summary>
		/// <returns>The asteroid in deathroes.</returns>
		/// <param name="at">At.</param>
        public Entity CreateAsteroidInDeathroes(Transform at)
        {
            var deathroes = Instantiate(prefabs.asteroidInDeathroes);
            deathroes.transform.position = at.transform.position;
            deathroes.transform.rotation = at.rotation;
            return deathroes;
        }

		/// <summary>
		/// Creates the asteroid.
		/// </summary>
		/// <returns>The asteroid.</returns>
		/// <param name="size">Size.</param>
		/// <param name="pos">Position.</param>
        public Entity CreateAsteroid(AsteroidSize size, Vector3 pos)
        {
            var prefab = prefabs.GetAsteroid(size);
            var asteroid = Instantiate(prefab);
            asteroid.transform.position = pos;
            asteroid.GetComponent<Hitpoints>().ResetToStart();
            return asteroid;
        }

		/// <summary>
		/// Creates the spaceship bullet.
		/// </summary>
		/// <returns>The spaceship bullet.</returns>
		/// <param name="gun">Gun.</param>
		/// <param name="gunTransform">Gun transform.</param>
        public Entity CreateUserBullet(Gun gun, Transform gunTransform)
        {
            var bullet = Instantiate(prefabs.playerBullet);

            bullet.transform.position = gunTransform.position;
            bullet.transform.rotation = gunTransform.rotation;
            bullet.GetComponent<Rigidbody2D>().AddRelativeForce(new Vector2(0, 80));

            return bullet;
        }

		/// <summary>
		/// Instantiate the specified prefab.
		/// </summary>
		/// <param name="prefab">Prefab.</param>
        public Entity Instantiate(GameObject prefab)
        {
#if UNITY_EDITOR
            var obj = (GameObject)UnityEditor.PrefabUtility.InstantiatePrefab(prefab);
            return obj.GetComponent<Entity>();
#else
            return GameObject.Instantiate(prefab).GetComponent<Entity>();
#endif
        }
    }
}
