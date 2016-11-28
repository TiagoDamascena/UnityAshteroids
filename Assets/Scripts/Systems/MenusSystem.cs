using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ash.Core;
using Ash.Helpers;
using Assets.Scripts.Components;
using Assets.Scripts.Nodes;

namespace Assets.Scripts.Systems
{
    /// <summary>
    /// Menus system. Controls the game menus.
    /// </summary>
	public class MenusSystem : NodelessSystem<MainMenu, Hud, Ranking, HighScore> 
    {
        private INodeList<WaitForStartNode> waitNodes;
        private INodeList<GameNode> gameNodes;
        private INodeList<Node<Asteroid, Entity>> asteroids;

        public MenusSystem()
        {
            _addedToEngineCallback = OnAddedToEngine;
            _updateCallback = OnUpdate;
        }

        private void OnAddedToEngine(IEngine engine)
        {
            gameNodes = engine.GetNodes<GameNode>();
            asteroids = engine.GetNodes<Node<Asteroid, Entity>>();
        }

		private void OnUpdate(float arg1, MainMenu menus, Hud hud, Ranking ranking, HighScore highScore)
        {
			if (menus.view.RankingClicked)
			{
				menus.view.Hide ();
				hud.view.Hide ();
				highScore.view.Hide ();
				ranking.view.Show ();
				menus.view.RankingClicked = false;
			}
			else if (ranking.view.BackClicked)
			{
				menus.view.Show ();
				hud.view.Hide ();
				highScore.view.Hide ();
				ranking.view.Hide ();
				ranking.view.BackClicked = false;
			}
			else if (menus.view.StartClicked)
			{
				foreach (var game in gameNodes)
				{
					foreach (var asteroid in asteroids)
						asteroid.Component2.Destroy();

					game.State.SetForStart();
					menus.view.Hide();
					hud.view.Show();
					highScore.view.Hide ();
					ranking.view.Hide ();
					menus.view.StartClicked = false;
				}
			}
			else if (highScore.view.SaveClicked)
			{
				menus.view.Show ();
				hud.view.Hide ();
				highScore.view.Hide ();
				ranking.view.Hide ();
				highScore.view.SaveClicked = false;
				ranking.view.name.text = highScore.view.name.text;
				ranking.view.score.text = highScore.view.score.text;
			}
        }
    }
}
