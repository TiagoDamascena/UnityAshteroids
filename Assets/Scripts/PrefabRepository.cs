using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Assets.Scripts.Components;
using UnityEngine;

namespace Assets.Scripts
{
    /// <summary>
    /// Prefab repository. Responsible for store prefabs.
    /// </summary>
	public class PrefabRepository : MonoBehaviour
    {
        public GameObject waitForClick;
        public GameObject game;
        public GameObject spaceship;
        public GameObject asteroidLarge;
        public GameObject asteroidMedium;
        public GameObject asteroidSmall;
        public GameObject playerBullet;
        public GameObject asteroidInDeathroes;
        public GameObject spaceshipDeathroes;

		/// <summary>
		/// Creates a new asteroid of an specific size.
		/// </summary>
		/// <returns>The asteroid.</returns>
		/// <param name="size">Size of the asteroid.</param>
        public GameObject GetAsteroid(AsteroidSize size)
        {
            if (size == AsteroidSize.Large)
                return asteroidLarge;
            if (size == AsteroidSize.Medium)
                return asteroidMedium;
            return asteroidSmall;
        }
    }
}
