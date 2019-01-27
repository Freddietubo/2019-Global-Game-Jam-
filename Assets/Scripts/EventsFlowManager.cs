using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EventsFlowManager : MonoBehaviour {

    public string scene2load;
    public GameObject dancingCanvas;
    public GameObject foodCanvas;
    public GameObject GameCanvas;

    public GameObject canvas2show;
    public GameObject canvas2hide0;
    public GameObject canvas2hide1;
    public GameObject canvas2hide2;

    private float sleepToT = 50.0f;
    private float grade = 60.0f;
    private float reviseToT = 10.0f;
    private float fireIndex = 30.0f;
    private float excitedIndex = 50.0f;
    private float vitalityIndex = 80.0f;

    public Text sleepValueText;
    public Text gradeValueText;
    public Text reviseEffortText;
    public Text fireIndexText;
    public Text excitedIndexText;
    public Text vitalityIndexText;

    public float addFire;
    public float reduceVit;

    public void loadScene()
    {
        SceneManager.LoadScene(scene2load);
    }

    public float GetPlayerSleepValue()
    {
        sleepToT = float.Parse(sleepValueText.text);
        return sleepToT;
    }

    public void SetPlayerAttributes()
    {
        Debug.Log(fireIndex);
        fireIndex += addFire;
        vitalityIndex -= reduceVit;
        
        Debug.Log(fireIndex);
        fireIndexText.text = fireIndex.ToString();
        vitalityIndexText.text = vitalityIndex.ToString();
    }

    public float GetPlayerPotentialGrade()
    {
        grade = float.Parse(gradeValueText.text);
        return grade;
    }

    public float GetPlayerRevisePoints()
    {
        reviseToT = float.Parse(reviseEffortText.text);
        return reviseToT;
    }

    public float GetPlayerFireIndex()
    {
        fireIndex = float.Parse(fireIndexText.text);
        return fireIndex;
    }

    public float GetPlayerExcitedIndex()
    {
        excitedIndex = float.Parse(excitedIndexText.text);
        return excitedIndex;
    }

    public float GetPlayerVitality()
    {
        vitalityIndex = float.Parse(vitalityIndexText.text);
        return vitalityIndex;
    }

    public void GenerateEvent()
    {
        int i = Random.Range(0, 3);
        //int i = 0;
        switch (i)
        {
            case 0:
                dancingCanvas.SetActive(true);
                foodCanvas.SetActive(false);
                GameCanvas.SetActive(false);
                break;
            case 1:
                dancingCanvas.SetActive(false);
                foodCanvas.SetActive(true);
                GameCanvas.SetActive(false);
                break;
            case 2:
                dancingCanvas.SetActive(false);
                foodCanvas.SetActive(false);
                GameCanvas.SetActive(true);
                break;
        }
    }

    public void CanvasControl()
    {
        if (canvas2show != null)
        {
            canvas2show.SetActive(true);
        }
        if (canvas2hide0 != null)
        {
            canvas2hide0.SetActive(false);
        }
        
    }

    public void toBedroom()
    {
        SceneManager.LoadScene("BedroomScene");
    }

}
