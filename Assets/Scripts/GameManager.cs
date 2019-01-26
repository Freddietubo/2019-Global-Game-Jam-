using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum GameState { playing, won, lost, pause };

public class GameManager : MonoBehaviour {

    private GameObject GM;

    private GameState gameState;

    private GameObject startCanvas;

    private GameObject mainCanvas;

    private GameObject menuCanvas;

    private GameObject mainCamera;

    public GameObject playerPrefab;

    private GameObject playerInstance;

    public float insPosX;

    public float insPosY;

    public float sleepToT;

    public float grade;

    public float reviseToT;

    public float fireIndex;

    public float excitedIndex;

    public string sheepScene;

    void Awake()
    {
        GM = GameObject.FindGameObjectWithTag("Game Manager");

        startCanvas = GameObject.FindGameObjectWithTag("Start Canvas");
        mainCanvas = GameObject.FindGameObjectWithTag("Main Canvas");
        menuCanvas = GameObject.FindGameObjectWithTag("Menu Canvas");

        mainCamera = GameObject.FindGameObjectWithTag("Main Camera");

        OnStateChange();

    }

    void Start()
    {
        SetGameState(GameState.playing);

        this.GenerateGameObject(playerInstance, playerPrefab, insPosX, insPosY);

        mainCanvas.SetActive(true);
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
        this.startCanvas.SetActive(false);
        this.mainCanvas.SetActive(false);
        this.menuCanvas.SetActive(false);
    }

    private void GenerateGameObject(GameObject go, GameObject prefab, float gX, float gY)
    {
        go = Instantiate(prefab, new Vector3(gX, gY, 0), Quaternion.identity) as GameObject;
    }

    private void loadScene(string scene2load)
    {
        SceneManager.LoadScene(scene2load);
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
}
