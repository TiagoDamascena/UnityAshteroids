using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Scripts.Components
{
    /// <summary>
    /// Bullet. Define a bullet of the spaceship
    /// </summary>
	public class Bullet : MonoBehaviour
    {
        public float maxAge = 1f;
        public float age;
    }
}
