using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Scripts.Components
{
    /// <summary>
	/// Gun controls. Define the spaceship gun controls.
    /// </summary>
	public class GunControls : MonoBehaviour
    {
        public KeyCode trigger = KeyCode.Space;
        public bool isTriggering;

        void Update()
        {
            isTriggering = Input.GetKey(trigger);
        }
    }
}
