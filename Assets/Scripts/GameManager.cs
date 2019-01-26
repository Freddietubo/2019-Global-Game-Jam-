using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public enum GameState { start, tutorial, playing, counting, cutting, pause };

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
    public float reviseToT; // revice pts will influence player's final grade
    public float fireIndex; // fireIndex >= excitedIndex count sheep
    public float excitedIndex; //
    public float vitalityIndex; // speed of cutting line

    private Scene myScene;
    private string sceneName;
    public string startScene;
    public string tutorialScene;
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

        sceneName = GetSceneName();
        Debug.Log(sceneName);



        switch (sceneName)
        {
            case "StartScene":
                gameState = GameState.start;
                break;
            case "BedroomScene":
                gameState = GameState.playing;
                break;
            case "TutorialScene":
                gameState = GameState.tutorial;
                break;
            case "CountingSheep":
                gameState = GameState.counting;
                break;
            case "wakeUpGme":
                gameState = GameState.cutting;
                break;
        }

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
            case GameState.counting:
                break;
            case GameState.cutting:
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

    public void getUp()
    {
        loadScene(wakeupScene);
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
