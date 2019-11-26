using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainManager : MonoBehaviour, GameManagerDelegate, MenuManagerDelegate {
    private int _highScore;
    public Text _highScoreLabel;

    void Start(){
        Debug.Log("starting up.");
        DontDestroyOnLoad(this.gameObject);
        UpdateScoreLabel();
    }
    void OnEnable(){
       Debug.Log("OnEnable called");
       SceneManager.sceneLoaded += OnSceneLoaded;
   }
   void Awake(){
        GameObject[] objs = GameObject.FindGameObjectsWithTag("main");
        if (objs.Length > 1){
            Destroy(this.gameObject);
        }
        DontDestroyOnLoad(this.gameObject);
    }
    void OnSceneLoaded(Scene scene, LoadSceneMode mode){
        Debug.Log("OnSceneLoaded: " + scene.name);
        Debug.Log(mode);
        if(scene.name == "Title"){
            Debug.Log("title was loaded " + _highScore);
            _highScoreLabel = GameObject.Find("HighScoreLabel").GetComponent<Text>();
            UpdateScoreLabel();
        }

    }

    private void UpdateScoreLabel(){
        Debug.Log("updating the label " + _highScore);
        _highScoreLabel.text = _highScore.ToString();
    }
    //-----------Delegate Methods-------------
    public void BackToTitle(){
        SceneManager.LoadScene("Title", LoadSceneMode.Single);

    }
    public void UpdateHighScore(int score){
        Debug.Log("main manager updating high score " + score);
        _highScore = score;
    }
    public int GetHighScore(){
        return _highScore;
    }
    public void PressedStart(){
        Debug.Log("pressed to game");
        SceneManager.LoadScene("Game", LoadSceneMode.Single);
    }

}
