using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.Graphics
{
    /// <summary>
    /// Main menu view. Define the interface of the main menu.
    /// </summary>
	public class MainMenuView : MonoBehaviour
    {
        public Button startBtn;
		public Button rankingBtn;

        public bool StartClicked { get; set; }
		public bool RankingClicked { get; set; }

        void Awake()
        {
            startBtn.onClick.AddListener(() => StartClicked = true);
			rankingBtn.onClick.AddListener(() => RankingClicked = true);
        }

        public void Hide()
        {
            gameObject.SetActive(false);
        }

        public void Show()
        {
            gameObject.SetActive(true);
        }
    }
}
