using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreboardView : BaseView
{
    [SerializeField] private Button backButton;
    [SerializeField] private PlayerScoreboardCard cardPrefab;
    [SerializeField] private Scoreboard scoreboard;
    private VerticalLayoutGroup layoutGroup;
    private List<PlayerScoreboardCard> playerCards = new List<PlayerScoreboardCard>();
    public override void Init()
    {
        base.Init();
        playerCards = new List<PlayerScoreboardCard>();
        layoutGroup = GetComponentInChildren<VerticalLayoutGroup>();
        scoreboard.GetComponentInParent<Scoreboard>();  
        backButton.onClick.AddListener(() =>
        {
            backButton.onClick.Invoke();
        });
    }
    public void AddPlayerCards(List<PlayerScoreboardCardData> cardsData)
    {
        
        foreach (var cardData in cardsData)
        {
            AddPlayerCard(cardData);
        }
    }
       
    private void AddPlayerCard(PlayerScoreboardCardData cardData)
    {
        try{
        PlayerScoreboardCard playerScoreboardCard = Instantiate(cardPrefab);
        playerScoreboardCard.transform.SetParent(layoutGroup?.transform, false);
        playerScoreboardCard.UpdateCard(cardData);   
        playerCards.Add(playerScoreboardCard);
        } catch (Exception err) {
            PlayerScoreboardCard playerScoreboardCard = Instantiate(cardPrefab);
            Debug.Log(playerScoreboardCard);
            Debug.Log(layoutGroup);
            Debug.LogError(err);
        }

    }

    public void RemovePlayerCard(string cardTag)
    {
        foreach (var playerCard in playerCards)
        {
            if (cardTag == playerCard.name)
            {
                playerCard.gameObject.SetActive(false);
                playerCards.Remove(playerCard);
            }
        }
    }

    public void RefreshPlayerCard(PlayerScoreboardCardData cardData)
    {
        foreach (var playerCard in playerCards)
        {
            if (cardData.playerName == playerCard.name)
                playerCard.UpdateCard(cardData);
        }               
    }
}
