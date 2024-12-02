
using System;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuView : BaseView
{

   
    [SerializeField] private Button startButton;
    [SerializeField] private Button leadeboardButton;
    [SerializeField] private Button exitButton;

   void StartGame() {
      SceneManager.LoadScene(1);
   }
   void ShowLeaderboard() {
      Show(false);
      MenuViewManager.Instance.Show<ScoreboardView>(true);
   }

   public void CloseLeaderboard() {
        MenuViewManager.Instance.Show<ScoreboardView>(false);
        Show(true);
   }

    void ExitGame() {
      Application.Quit();
   }
   

      private void Start() {
         startButton.onClick.AddListener(StartGame);
         leadeboardButton.onClick.AddListener(ShowLeaderboard);
         exitButton.onClick.AddListener(ExitGame);
      }
    
   
}
