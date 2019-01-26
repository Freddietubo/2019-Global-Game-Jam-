using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public enum GameState { start, playing, won, lost, pause };

public class GameManager : MonoBehaviour {

    private GameObject GM;

    private GameState gameState;

    private GameObject startCanvas;

    private GameObject mainCanvas;

    private GameObject menuCanvas;

    private GameObject mainCamera;

    //public GameObject playerPrefab;

    //private GameObject playerInstance;

    public float insPosX;

    public float insPosY;

    public float sleepToT;

    public float grade;

    public float reviseToT;

    public float fireIndex;

    public float excitedIndex;

    private Scene myScene;

    public string startScene;

    public string bedroomScene;

    private string sceneName;

    public string sheepScene;

    public string wakeupScene;

    private string playerName;

    private Text playerNameBlock;


    void Start()

    {
        Debug.Log(this.GetSceneName());
        if (this.GetSceneName() == startScene)
        {
            SetGameState(GameState.start);
            OnStateChange();
            if (startCanvas)
            {
                startCanvas.SetActive(true);
            }
        }

        if (this.GetSceneName() == bedroomScene)
        {
            mainCanvas = GameObject.FindGameObjectWithTag("Main Canvas");
            menuCanvas = GameObject.FindGameObjectWithTag("Menu Canvas");

            // mainCanvas.SetActive(true);

        }
    }

    void Update()
    {

    }

    public void SetGameState(GameState state)
    {
        this.gameState = state;
        OnStateChange();
    }

    private void OnStateChange()
    {
        if (startCanvas)
        {
            startCanvas.SetActive(false);
        }
        if (mainCanvas)
        {
            mainCanvas.SetActive(false);
        }
        if (menuCanvas)
        {
            menuCanvas.SetActive(false);
        }
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
            OnStateChange();

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
