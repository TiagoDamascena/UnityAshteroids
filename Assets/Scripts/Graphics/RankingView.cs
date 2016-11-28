using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.Graphics
{
	public class RankingView : MonoBehaviour
	{
		public Text name;
		public Text score;
		public Button backBtn;

		public bool BackClicked { get; set; }

		void Awake()
		{
			backBtn.onClick.AddListener(() => BackClicked = true);
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