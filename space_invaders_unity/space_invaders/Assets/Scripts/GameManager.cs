using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

    private static GameManager _i;
    public static GameManager i {
        get {
            if(_i == null) _i = FindObjectOfType<GameManager>();
            return _i;
        }
    }

    [SerializeField] Text currentScoreText;
    [SerializeField] Text highScoreText;

    public GameScore gameScore;

    private void Awake() {
        gameScore = new GameScore();
    }

    private void Update() {
        currentScoreText.text = gameScore.ToString();
    }

    [SerializeField] GameObject gameOverPanel;
    [SerializeField] Text gameOverScoreNumber;
    public void GameOver() {
        Time.timeScale = 0;
        gameOverPanel.SetActive(true);
        gameOverScoreNumber.text = gameScore.ToString();
        // TODO: criar registro de score
    }

}
