using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GamePlayManager1 : MonoBehaviour, DiceDelegate {
    GameManagerDelegate _delegate;

    public GameObject _spawnLocation;
    private ScoreManager _scoreManager;

    public Dice _dice1;
    public Dice _dice2;

    public Text _scoreLabel;

    public Toggle _fixedToggle;
    private int _fixedCount = 0;

    public GameOverMenu _gameOverMenu;
    public Animator _animator;
    public Animator _scoreAnimator;

    bool _willReset;
    float _timer = 0.0f;

    bool _isRolling = false;
    void Start(){
        //Find the delegate
        GameObject managers = GameObject.Find("Managers");
        _delegate = managers.GetComponent<GameManagerDelegate>();

        _dice1.SetUp(this);
        _dice2.SetUp(this);
        _scoreManager = new ScoreManager();
        _dice1.Reset();
        _dice2.Reset();
        ShowControls(true);
        _gameOverMenu.Hide();
    }

    void Update(){
        if(_willReset){
            _timer -= Time.deltaTime;
            if(_timer <= 0.0){
                _willReset = false;
                ResetDice();
            }
        }
    }
    public void ShowControls(bool b){
        _animator.SetBool("shouldShowButtons", b);
    }

    public void PressedRoll(){
        Debug.Log("pressed roll");

        //check if roll is in progress
        if(_isRolling){
            return;
        }
        Roll();
    }
    private void Roll(){
        //roll the dice and wait for result

        //check if is fixed
        if(_fixedToggle.isOn){
            _fixedCount++;
        }else{
            _fixedCount = 0;
        }
        _isRolling = true;
        ShowControls(false);
        _dice1.Roll(_fixedCount == 5);
        _dice2.Roll(_fixedCount == 5);
    }
    private void DoneRolling(){
        Debug.Log("the roll has finished");
        int roll1 = _dice1.GetRoll();
        int roll2 = _dice2.GetRoll();
        if(roll1 != roll2){
            Debug.Log("you get " + (roll1 + roll2) + " points!");
            _scoreManager.AddToScore(roll1 + roll2);
            UpdateScore();

            //wait before reseting the dice
            _timer = 1.8f;
            _willReset = true;
        }else{
            Debug.Log("GAME OVER" );
            //check if we beat the highscore
            int score = _scoreManager.GetScore();
            if(_delegate.GetHighScore() < score){
                Debug.Log("is a high score");
                _delegate.UpdateHighScore(score);
                _gameOverMenu.Show(score);
            }else{
                Debug.Log("not a high score");
                _gameOverMenu.Show();
            }
        }
    }
    public void PressedPlayAgain(){
        Debug.Log("should restart game");
        _scoreManager.Reset();
        _gameOverMenu.Hide();
        ResetDice();

    }
    private void UpdateScore(){
        _scoreLabel.text = _scoreManager.GetScore().ToString();
        _scoreAnimator.Play("Grow");
    }
    public void PressedBack(){
        _delegate.BackToTitle();
    }
    private void ResetDice(){
        _dice1.Reset();
        _dice2.Reset();
        ShowControls(true);
        _isRolling = false;
    }
    //---------------DiceDelegate Methods---------------
    public void DoneMoving(){
        //check if both the dice are done moving
        if(!_dice1._isMoving && !_dice2._isMoving){
            DoneRolling();
        }
    }
}
public interface GameManagerDelegate{
    void BackToTitle();
    void UpdateHighScore(int score);
    int GetHighScore();
}
