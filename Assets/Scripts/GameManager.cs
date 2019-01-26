using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GameState { playing, won, lost, pause };

public class GameManager : MonoBehaviour {

    private GameObject GM;

    private GameState gameState;

    private GameObject mainCanvas;

    private GameObject menuCanvas;

    private GameObject mainCamera;

    public GameObject playerPrefab;

    public float insPosX;

    public float insPosY;

    void Awake()
    {
        GM = GameObject.FindGameObjectWithTag("Game Manager");

        mainCanvas = GameObject.FindGameObjectWithTag("Main Canvas");
        menuCanvas = GameObject.FindGameObjectWithTag("Menu Canvas");

        mainCamera = GameObject.FindGameObjectWithTag("Main Camera");

    }

    void Start()
    {
        SetGameState(GameState.playing);

        GameObject playerInstance = Instantiate(playerPrefab, new Vector3(insPosX, insPosY, 0), Quaternion.identity) as GameObject;

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
        this.mainCanvas.SetActive(false);
        this.menuCanvas.SetActive(false);
    }

    public void Quit()
    {
        Application.Quit();
    }
}
