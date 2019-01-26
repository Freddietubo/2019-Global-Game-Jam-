using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public enum GameState { start, tutorial, playing, won, lost, pause };

public class GameManager : MonoBehaviour {

    public static GameManager GM;

    private GameState gameState;

    // GUI variables
    public GameObject startCanvas;
    public GameObject mainCanvas;
    public GameObject menuCanvas;
    public GameObject mainCamera;
    public GameObject tutorialCanvas;

    // GameObject instantiate position
    public float insPosX;
    public float insPosY;

    // Player Character variables
    public float sleepToT; // Total sleep value
    public float grade; // player's potential final grade
    public float reviseToT; //
    public float fireIndex;
    public float excitedIndex;


    private Scene myScene;
    private string sceneName;
    public string startScene;
    public string bedroomScene;
    public string sheepScene;
    public string wakeupScene;

    private string playerName;
    private Text playerNameBlock;


    void Start()
    {
        
        //Debug.Log(this.GetSceneName());
        //if (this.GetSceneName() == startScene)
        //{
        //    SetGameState(GameState.start);
        //    OnStateChange();
        //    if (startCanvas)
        //    {
        //        startCanvas.SetActive(true);
        //    }
        //}

        //if (this.GetSceneName() == bedroomScene)
        //{
        //    mainCanvas = GameObject.FindGameObjectWithTag("Main Canvas");
        //    menuCanvas = GameObject.FindGameObjectWithTag("Menu Canvas");

        //    // mainCanvas.SetActive(true);

        //}

        GM = this;

        if (GM == null)
        {
            GM = this.gameObject.GetComponent<GameManager>();
        }
        if (mainCamera)
        {
            mainCamera.SetActive(true);
        }
        if (mainCanvas)
        {
            mainCanvas.SetActive(false);
        }
        if (startCanvas)
        {
            startCanvas.SetActive(false);
        }
        if (tutorialCanvas)
        {
            tutorialCanvas.SetActive(false);
        }
        gameState = GameState.start;
    }

    void Update()
    {
        switch (gameState)
        {
            case GameState.start:
                if (startCanvas)
                {
                    startCanvas.SetActive(true);
                }
                else
                {
                    Debug.Log("Haven't assign start canvas!");
                }
                break;
            case GameState.tutorial:
                break;
            case GameState.playing:
                break;
            case GameState.won:
                break;
            case GameState.lost:
                break;
            case GameState.pause:
                break;
        }
    }

    public void SetGameState(GameState state)
    {
        this.gameState = state;
    }

    private void GenerateGameObject(GameObject go, GameObject prefab, float gX, float gY)
    {
        go = Instantiate(prefab, new Vector3(gX, gY, 0), Quaternion.identity) as GameObject;
    }

    private void loadScene(string scene2load)
    {
        SceneManager.LoadScene(scene2load);
    }

    public void goStart()
    {
        if (bedroomScene != null)
        {
            this.loadScene(bedroomScene);
            SetGameState(GameState.playing);

            if (mainCanvas)
            {
                mainCanvas.SetActive(true);
            }
        }

    }
    public void goSleep()
    {
        if (fireIndex >= excitedIndex)
        {
            this.loadScene(sheepScene);
        }
    }
    public void Quit()
    {
        Debug.Log("Quit!");
    }

    private string GetSceneName()
    {
        myScene = SceneManager.GetActiveScene();
        sceneName = myScene.name;
        return sceneName;
    }

    public void NamedSSL()
    {
        playerName = "SuperSuperLazy";
    }
}
