using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityStandardAssets.ImageEffects;


public class wakeupGame : MonoBehaviour {

    public GameObject wakeupRange;
    public GameObject wakeupBar;
    public GameObject wakeUpArea;
    Vector3 rangePosition;
    Vector3 worldRangePosition;
    public Text text1;
    public float vitality = GameManager.GM.vitalityIndex;
    private bool forWakeUp = true;
    private bool failToWakeUp = false;
    private float sleepIndex;
    //
    private ColorCorrectionCurves _colorCor;

    // Use this for initialization
    void Start () {
        rangePosition = new Vector3(Random.Range(transform.position.x, transform.position.x + 12), wakeupBar.transform.position.y,wakeupBar.transform.position.z);
        worldRangePosition = Camera.main.ViewportToWorldPoint(rangePosition);
        wakeUpArea = GameObject.Instantiate(wakeupRange, rangePosition, wakeupRange.transform.rotation);
        wakeUpArea.SetActive(true);
        if(_colorCor == null){
            _colorCor = FindObjectOfType<ColorCorrectionCurves>();
        }

        sleepIndex = 20.0f + (50.0f - vitality)/2;

        //if(_camera == null)        {
        //    _camera = FindObjectOfType<CameraShaker>();
        //}

	}
	
	// Update is called once per frame
	void Update () {
        if (forWakeUp) moveBar();
        wakeUp();
        if (failToWakeUp) sleepAgain();
	}

    void wakeUp(){
        if (Input.GetMouseButtonDown(0)) {
            if (transform.position.x <= (rangePosition.x + 0.5) && (transform.position.x >= rangePosition.x - 0.5))
            {
                text1.text = "Wake Up Successfully!!!";
                Invoke("wakeUpSuccessfully", 3);
            }
            else
            {
                text1.text = "GG!!!!";
                failToWakeUp = true;
                vitality += 10.0f;
                GameManager.GM.vitalityIndex = vitality;
                Debug.Log(vitality.ToString());
                Invoke("closeTheWakeUpGame", 3);
                //cameraShake();
            }

            forWakeUp = false;

            
        }
    }

    void moveBar(){
        transform.position = new Vector2(Mathf.PingPong(Time.time * sleepIndex, 12) - 6, transform.position.y);
    }

    void wakeUpSuccessfully(){
        SceneManager.LoadScene("BedroomScene");
    }

    void closeTheWakeUpGame() {
        SceneManager.LoadScene("wakeUpGme");
        //wakeupRange.SetActive(false);
        //wakeupBar.SetActive(false);
        //gameObject.SetActive(false);
        //Destroy(wakeUpArea);
        //text1.text = "";
    }

    void sleepAgain(){
        _colorCor.saturation = Mathf.Lerp(_colorCor.saturation, 0.0f, Time.deltaTime/2);
    }

    //void cameraShake(){
    //    _camera.ShakeOnce(4f, 4f, 0.15f, 1f);
    //}
}
