using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Scripts.Components
{
    /// <summary>
    /// Game state. Define the current state of the game.
    /// </summary>
	public class GameState : MonoBehaviour
    {
        public int lives;
		public int score;
        public int level;
        public int hits;
        public bool playing;

        public void SetForStart()
        {
            lives = 3;
			score = 0;
            level = 0;
            hits = 0;
            playing = true;
        }
    }
}
