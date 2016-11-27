using Assets.Scripts.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ash.Core;

namespace Assets.Scripts.Nodes
{
    /// <summary>
	/// Wait for start node. Game start intermediary object.
    /// </summary>
	public class WaitForStartNode
    {
        public Entity Entity { get; set; }
        public MainMenu Wait { get; set; }
    }
}
