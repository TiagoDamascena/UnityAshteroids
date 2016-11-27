using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Scripts.Nodes
{
    /// <summary>
	/// Movement node. Movements intermediary object.
    /// </summary>
	public class MovementNode
    {
        public Transform Transform { get; set; }
        public Rigidbody2D Rigidbody { get; set; }
    }
}
