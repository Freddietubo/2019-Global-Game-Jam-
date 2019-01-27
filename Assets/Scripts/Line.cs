using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Line : MonoBehaviour
{
    public float speed;
    private Vector3 destination;
    private Spawner spawner;
    public int countIndex;
    public int missCount;
    public Text ifSleep;
    private bool isChangeLoad=true;

    public GameObject perfect;
    public GameObject good;
    public GameObject miss;

    //
    private float currentX;

    // Use this for initialization
    void Start()
    {
        //initialization
        speed = 3.0f;
        countIndex = 0;
        missCount = 0;
        spawner = Spawner.getInstance();
        currentX = spawner.getCurrentX();
        GameManager.GM.fireIndex -= 10.0f;
        ifSleep = GameObject.Find("Canvas").GetComponentInChildren<Text>();
        perfect = GameObject.Find("perfect");
        good = GameObject.Find("good");
        miss = GameObject.Find("miss");
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(speed * Time.deltaTime, 0.0f, 0.0f);

        //smoothing the movement
        //transform.position = Vector3.Lerp(transform.position, destination, speed * Time.deltaTime);


        //deal with the keyboard control
        float linePositionX = this.transform.position.x;
        float sheepPositionX = currentX;
        if (Input.GetKeyUp(KeyCode.Space))
        {
            bool isHit = CountSheep(linePositionX, sheepPositionX);
            if (isHit & spawner.isElement()) currentX = spawner.getCurrentX();
        }

        if ((linePositionX - sheepPositionX > 0.5f) & spawner.isElement())
        {
            spawner.deleteElement();
            missCount++;
            Debug.Log("Auto delete");
            if (spawner.isElement()) currentX = spawner.getCurrentX();
        }

        if (isChangeLoad)
        {
            if ((countIndex + missCount) == 5)
            {
                isChangeLoad = false;
                if (countIndex == 5)
                {
                    sleepSuccessFully();
                }
                else failToSleep();
            }
        }

    }

    void sleepSuccessFully()
    {
        ifSleep.text = "Sleep!!!!!";
        //GameManager.GM.vitalityIndex -= 10.0f;
        Invoke("toWakeUp", 3);
    }

    void failToSleep()
    {
        ifSleep.text = "Fail To Sleep. You can revise or play the game!!!";
        GameManager.GM.vitalityIndex -= 10.0f;
        Invoke("toBedroom", 3);
    }

    void toWakeUp()
    {

        SceneManager.LoadScene("wakeUpGme");
    }

    void toBedroom()
    {
        SceneManager.LoadScene("BedroomScene");
    }

    bool CountSheep(float linePositionX, float sheepPositionX)
    {
        if (Mathf.Abs(linePositionX - sheepPositionX) < 0.1f)
        {
            spawner.deleteElement();
            countIndex++;
            perfect.SetActive(true);
            good.SetActive(false);
            miss.SetActive(false);
            Debug.Log("Perfect");
            return true;
        }

        if (Mathf.Abs(linePositionX - sheepPositionX) < 0.2f)
        {
            spawner.deleteElement();
            countIndex++;
            perfect.SetActive(false);
            good.SetActive(true);
            miss.SetActive(false);
            Debug.Log("Good");
            return true;
        }

        if (Mathf.Abs(linePositionX - sheepPositionX) < 0.5f)
        {
            spawner.deleteElement();
            missCount++;
            perfect.SetActive(false);
            good.SetActive(false);
            miss.SetActive(true);
            Debug.Log("Miss");
            return true;
        }

        return false;
    }
}