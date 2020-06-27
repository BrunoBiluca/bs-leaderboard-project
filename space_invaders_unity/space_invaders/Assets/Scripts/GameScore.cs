using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameScore {

    private int score;

    public GameScore() {
        score = 0;
    }

    private void IncreaseScore(int value) {
        score += value;
        if(score < 0) score = 0;
    }

    public void KillEnemy() {
        IncreaseScore(100);
    }

    public void MissedShoot() {
        IncreaseScore(-10);
    }

    public void PlayerDied() {
        IncreaseScore(-100);
    }

    public override string ToString() {
        var scorePlaceholder = "0000000000";
        var zeroPart = scorePlaceholder.Substring(0, 10 - score.ToString().Length);
        return zeroPart + score.ToString();
    }
}
