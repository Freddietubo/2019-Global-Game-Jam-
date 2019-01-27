using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Experimental.UIElements;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ChangeScene : MonoBehaviour {

    //public Text playername;
    public TextMeshProUGUI playername;

    public Text tips;

    // Use this for initialization
    void Start () {
        setPlayerName();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void sleepClick()
    {
        if (GameManager.GM.fireIndex >= 50.0f)
        {
            SceneManager.LoadScene(GameManager.GM.sheepScene);
        }
        else
        {
            tips.text = "Fall Sleep";
            Invoke("toWakeUp", 3);
        }
        
    }

    public void toWakeUp()
    {
        SceneManager.LoadScene(GameManager.GM.wakeupScene);
    }

    public void reviseClick()
    {
        SceneManager.LoadScene(GameManager.GM.reviseScene);
    }

    public void gameClick()
    {
        SceneManager.LoadScene(GameManager.GM.gameScene);
    }

    void setPlayerName()
    {
        playername.SetText(GameManager.GM.playerName);
    }

}
