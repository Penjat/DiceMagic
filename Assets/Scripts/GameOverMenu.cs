using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOverMenu : MonoBehaviour {
    public Text _scoreLabel;
    public GameObject _highScoreContainer;
    public void Hide(){
        gameObject.SetActive(false);
    }
    public void Show(int score = -1){
        gameObject.SetActive(true);
        //if no high score specified, default to -1
        if(score != -1){
            _highScoreContainer.SetActive(true);
            _scoreLabel.text = score.ToString();
        }else{
            _highScoreContainer.SetActive(false);
        }

    }

}
