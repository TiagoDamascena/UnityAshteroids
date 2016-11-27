using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.Graphics
{
    /// <summary>
    /// Hud view. Define the interface of the game.
    /// </summary>
	public class HudView : MonoBehaviour
    {
        public Text scoreTxt;
		public GameObject live01;
		public GameObject live02;
		public GameObject live03;
        
        public void SetLives(int lives)
        {
			if (lives == 3) {
				live01.SetActive (true);
				live02.SetActive (true);
				live03.SetActive (true);
			} else if (lives == 2) {
				live01.SetActive (true);
				live02.SetActive (true);
				live03.SetActive (false);
			} else if (lives == 1) {
				live01.SetActive (true);
				live02.SetActive (false);
				live03.SetActive (false);
			} else {
				live01.SetActive (false);
				live02.SetActive (false);
				live03.SetActive (false);
			}
        }

        public void SetScore(int score)
        {
			scoreTxt.text = score.ToString();
        }
    }
}
