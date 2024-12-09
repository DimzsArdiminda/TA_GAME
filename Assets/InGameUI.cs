
using UnityEngine;

public class InGameUI : MonoBehaviour
{
   [SerializeField] private Player Player;

   
   public void CloseLeaderboard() {
      ViewManager.Instance.Show<ScoreboardView>(false);
      if (Player.PlayerStateMachine.CurrentState == Player.PlayerStateMachine.PlayerDeadState) {
         ViewManager.Instance.Show<DeadView>(true);
      } else {
         ViewManager.Instance.Show<PausedView>(true);
      }
   }
}
