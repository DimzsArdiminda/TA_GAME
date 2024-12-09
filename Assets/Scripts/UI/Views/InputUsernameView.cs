using TMPro;
using UnityEngine;

[RequireComponent(typeof(RectTransform))]
public class InputUsernameView: BaseView {
    [SerializeField] private TMP_Text scoreText;
    [SerializeField] private GameSession GameSession;
    [SerializeField] private ViewManager ViewManager;

    [SerializeField] private Scoreboard Scoreboard;

    private string PlayerName;
    private string Score;
    public override void Init()
    {
        base.Init();
        transform.position = Vector3.zero;
        RectTransform rectTransform = GetComponent<RectTransform>();
        rectTransform.localPosition = Vector3.zero;
    }

    public void UpdatePlayerName(string playerName) {
        PlayerName = playerName;
    }

    public void SaveScore() {
        GameSession.UpdateScoreboard(new ScoreboardEntry(PlayerName, float.Parse(Score)));
        Show(false);
        ViewManager.Instance.Show<DeadView>(true);
    }

    public void UpdateScore(string score)
    {
        scoreText.text = $"YOUR SCORE : \n{score}"; 
        Score = score;
    }

    
}
