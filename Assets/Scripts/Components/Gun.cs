using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Scripts.Components
{
    /// <summary>
	/// Gun. Define the spaceship gun.
    /// </summary>
	public class Gun : MonoBehaviour
    {
        public bool shooting;
        public Vector2 offsetFromParent;
        public float timeSinceLastShot;
        public float minimumShotInterval = 0.3f;
        public AudioClip shootSound;
    }
}
