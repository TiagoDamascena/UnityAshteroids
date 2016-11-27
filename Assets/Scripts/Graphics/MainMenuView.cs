﻿using System;
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

        public bool StartClicked { get; set; }

        void Awake()
        {
            startBtn.onClick.AddListener(() => StartClicked = true);
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
