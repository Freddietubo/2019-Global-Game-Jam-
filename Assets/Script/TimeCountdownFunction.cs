using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeCountdownFunction : MonoBehaviour {

    public int testTotalSeconds = 10;
    private int leaveSeconds;
    private bool onCountDown = false;
    private string countDownTitle = "Start";

    private bool isEnd;
    void Awake()
    {
        leaveSeconds = testTotalSeconds;
    }


    void OnGUI()
    {
        GUI.Label(new Rect(50, 50, 50, 50), leaveSeconds.ToString());// 倒计时秒数 //


        //if (GUI.Button(new Rect(150, 50, 80, 30), countDownTitle))
        //{
        //    if (countDownTitle == "Start")
        //    {
        //        countDownTitle = "Pause";
        //        onCountDown = true;
        //        StartCoroutine(DoCountDown());
        //    }
        //    else
        //    {
        //        countDownTitle = "Start";
        //        onCountDown = false;
        //        StopAllCoroutines();
        //    }
        //}
    }
    // Use this for initialization
    void Start()
    {
        onCountDown = true;
        StartCoroutine(DoCountDown());
        isEnd = false;
    }

    // Update is called once per frame
    void Update()
    {

    }


    IEnumerator DoCountDown()
    {
        while (leaveSeconds > 0)
        {
            yield return new WaitForSeconds(1f);
            leaveSeconds--;
        }

        if(leaveSeconds == 0)
        {
            isEnd = true;
            
            
        }

    }

    public bool countdownValue()
    {
        return isEnd;
    }
}
