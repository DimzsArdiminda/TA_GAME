using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DeadView : BaseView
{
    [SerializeField] private Button restartButton;
    [SerializeField] private Button scoreboardButton;
    [SerializeField] private Button mainMenuButton;
    
    public override void Init()
	{
        restartButton.onClick.AddListener(() =>
        {
            GameSession.Instance.RestartSession();
        });
   
        scoreboardButton.onClick.AddListener(() =>
        {
            Show(false);
            ViewManager.Instance.Show<ScoreboardView>(true);
        });

        mainMenuButton.onClick.AddListener(() =>
        {
            SceneManager.LoadScene(0);
        });

      
        base.Init();
	}

    public void CloseScoreboard() {
        ViewManager.Instance.Show<ScoreboardView>(false);
        Show(true);
    }

}
