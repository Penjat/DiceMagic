using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager {
    int _curScore = 0;
    public void AddToScore(int points){
        _curScore += points;
    }
    public int GetScore(){
        return _curScore;
    }
    public void Reset(){
        _curScore = 0;
    }
}
