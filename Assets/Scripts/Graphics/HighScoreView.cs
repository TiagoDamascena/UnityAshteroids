using UnityEngine;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.Graphics
{
	public class HighScoreView : MonoBehaviour
	{
		public Text score;
		public Text name;
		public Button saveBtn;

		public bool SaveClicked { get; set; }

		void Awake()
		{
			saveBtn.onClick.AddListener(() => SaveClicked = true);
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