using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Scripts
{
    /// <summary>
    /// Game config. Responsible for the game configuration.
    /// </summary>
	public class GameConfig : MonoBehaviour
    {
        public Bounds bounds;

        /// <summary>
        /// Inits the bounds of the game with the size of the screen.
        /// </summary>
        /// <param name="cam">Main camera.</param>
		public void InitBounds(Camera cam)
        {
            var size = cam.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height));
            bounds = new Bounds(Vector3.zero, new Vector3(size.x * 2, size.y * 2));
        }
    }
}
