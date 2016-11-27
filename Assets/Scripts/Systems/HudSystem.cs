using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ash.Core;
using Ash.Helpers;
using Assets.Scripts.Components;

namespace Assets.Scripts.Systems
{
    /// <summary>
    /// Hud system. Controls the hub of the game.
    /// </summary>
	public class HudSystem : NodelessSystem<Hud, GameState>
    {
        public HudSystem()
        {
            _updateCallback = OnUpdate;
        }
 
        private void OnUpdate(float delta, Hud hud, GameState state)
        {
            hud.view.SetLives(state.lives);
			hud.view.SetScore(state.score);
        }
    }
}
