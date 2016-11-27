using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Scripts.Components
{
    /// <summary>
    /// Collisions. Store the collisions of a 2d object.
    /// </summary>
	public class Collisions : MonoBehaviour
    {
        public List<Collision2D> hits = new List<Collision2D>();

        void OnCollisionEnter2D(Collision2D coll)
        {
            hits.Add(coll);
        }
    }
}
