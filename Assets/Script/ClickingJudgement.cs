using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ClickingJudgement : MonoBehaviour {
    public Button[] key;
    public GameObject winText;
    public GameObject  failText;
    public GameObject missText;
    public TimeCountdownFunction timeCountdown;
    //keyI = 0, keyG = 1, keyM = 2
    int count = 0;
    private int[] countIndex1 = new int[3];
    private int[] rightCountIndex1 = { 0, 1, 2 };
    private int keyLength1;
    private bool isEnd = false;
    private bool isSleep = true;
    


    // Use this for initialization
    void Start () {
        keyLength1 = rightCountIndex1.Length;
        key[0].transform.position = new Vector3(Random.Range(90.0f, 815.0f), Random.Range(92.0f, 419.0f), 0.0f);
        key[1].transform.position = new Vector3(Random.Range(90.0f, 815.0f), Random.Range(92.0f, 419.0f), 0.0f);
        key[2].transform.position = new Vector3(Random.Range(90.0f, 815.0f), Random.Range(92.0f, 419.0f), 0.0f);
        
    }
	
	// Update is called once per frame
	void Update () {
        isEnd = timeCountdown.countdownValue();

        if ((count == keyLength1)&&(isEnd == false))
        {

            if (compareArr(countIndex1, rightCountIndex1))
            {
                //Debug.Log("Right");
                winText.SetActive(true);
                count = 0;
                GameManager.GM.fireIndex -= 20.0f;
                isSleep = false;
                Invoke("toBedroom", 3);
            }
            else
            {
                missText.SetActive(true);
                count = 0;
                isSleep = false;
                GameManager.GM.fireIndex -= 20.0f;
                Invoke("toBedroom", 3);
            }
        }
        if (isSleep)
        {
            if ((count < keyLength1) && (isEnd == true))
            {
                failText.SetActive(true);
                count = 0;
                GameManager.GM.fireIndex = 40.0f;
                GameManager.GM.vitalityIndex = 30.0f;
                Invoke("toWakeUp", 3);
            }
        }


		
            
            
        
	}

    public void toBedroom()
    {
        SceneManager.LoadScene(GameManager.GM.bedroomScene);
    }

    public void toWakeUp()
    {
        SceneManager.LoadScene(GameManager.GM.wakeupScene);
    }

    public void PressKeyI()
    {
        if(count != keyLength1)
        {
          
            countIndex1[count] = 0;
            count++;
        }
        Debug.Log(count);
        Debug.Log(countIndex1[count - 1]);

    }

    public void PressKeyG()
    {
        if (count != keyLength1 )
        {
            countIndex1[count] = 1;
            count++;
        }
        Debug.Log(count);
        Debug.Log(countIndex1[count - 1]);
    }

    public void PressKeyM()
    {
        if(count != keyLength1)
        {
            countIndex1[count] = 2 ;
            count++;
        }
        Debug.Log(count);

        Debug.Log(countIndex1[count -1]);
        
    }
    public static bool compareArr(int[] arr1, int[] arr2)
    {

        bool[] flag = new bool[arr1.Length];//初始化一个bool数组，初始值全为false；

        for (int i = 0; i < arr1.Length; i++)
        {    
            if (arr1[i] == arr2[i]) flag[i] = true;//遇到有相同的值，对应的bool数组的值设为true；
         }

        foreach (var item in flag)
        {

            if (item == false) return false; //遍历bool数组，还有false，就说明有不同的值，结果返回false。

        }

        return true;

    }



}
