using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ScoreManager : MonoBehaviour {


    public ScoreManager instance;
    public static int score;

    public int finalScore;
    public static int highScore;
    public static bool restart;
    public static bool firstStart;

    public GameObject mainMenuScreen;
    public GameObject endScreen;

    public Text scoreText;
    public Text finalScoreText;
    public Text highScoreText;
    public Button play;
    public Button mainMenu;
    public Button retry;



    void Awake() {
        instance = this;
        firstStart = true;
        
    }

    // Update is called once per frame
    void Update() {
        scoreText.text = "" + score;

        if(!PlayerController.instance.alive && !mainMenuScreen.activeSelf && !endScreen.activeSelf) {
            Invoke("endScreenLoad", 2f);
        }
    }

    // Use this for initialization
    void Start () {
        if(restart) {
            restart = false;
            startGame();
        } else {
            mainMenuClick();
        }
        
	}

    public void startGame() {
        if(firstStart) {
            mainMenuScreen.SetActive(false);
            score = 0;
            PlayerController.instance.alive = true;
            firstStart = false;
        } else {
            restartGame();
        }
       
    }

    public void restartGame() {
        restart = true;
        SceneManager.LoadScene(0);
    }

    public void mainMenuClick() {
        mainMenuScreen.SetActive(true);
        endScreen.SetActive(false);
    }

    public void endScreenLoad() {
        finalScore = score;
        if(highScore < score) {
            highScore = score;
        }

        finalScoreText.text = "Final Score: " + finalScore;
        highScoreText.text = "High Score: " + highScore;

        endScreen.SetActive(true);
    }

 
}
