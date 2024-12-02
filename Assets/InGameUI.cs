
using UnityEngine;

public class InGameUI : MonoBehaviour
{
   public void CloseLeaderboard() {
      ViewManager.Instance.Show<ScoreboardView>(false);
      ViewManager.Instance.Show<PausedView>(true);
   }
}
