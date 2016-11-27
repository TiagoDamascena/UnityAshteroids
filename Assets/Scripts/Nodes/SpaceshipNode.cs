using Assets.Scripts.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Scripts.Nodes
{
    /// <summary>
    /// Spaceship node. Spaceship intermediary object.
    /// </summary>
	public class SpaceshipNode
    {
        public Spaceship Spaceship { get; set; }
        public Transform Transform { get; set; }
    }
}
