using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Scripts.Components
{
	public enum AsteroidSize
    {
        Large,
        Medium,
        Small
    }

	/// <summary>
	/// Asteroid. Define an Asteroid of the game
	/// </summary>
    public class Asteroid : MonoBehaviour
    {
        public AsteroidSize size = AsteroidSize.Large;
    }
}
