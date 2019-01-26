using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.ImageEffects;
using EZCameraShake;

public class wakeupGame : MonoBehaviour {

    public GameObject wakeupRange;
    public GameObject wakeupBar;
    public GameObject wakeUpArea;
    Vector3 rangePosition;
    Vector3 worldRangePosition;
    public Text text1;
    public float fireIndex = 4.0f;
    private bool forWakeUp = true;
    private bool failToWakeUp = false;

    private CameraShaker _camera;
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
        
        if(_camera == null)        {
            _camera = FindObjectOfType<CameraShaker>();
        }

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
            }
            else
            {
                text1.text = "GG!!!!";
                failToWakeUp = true;
                //cameraShake();
            }

            forWakeUp = false;

            Invoke("closeTheWakeUpGame", 3);
        }
    }

    void moveBar(){
        transform.position = new Vector2(Mathf.PingPong(Time.time * fireIndex, 12) - 6, transform.position.y);
    }

    void closeTheWakeUpGame() {
        wakeupRange.SetActive(false);
        wakeupBar.SetActive(false);
        gameObject.SetActive(false);
        Destroy(wakeUpArea);
        text1.text = "";
    }

    void sleepAgain(){
        _colorCor.saturation = Mathf.Lerp(_colorCor.saturation, 0.0f, Time.deltaTime/2);
    }

    void cameraShake(){
        _camera.ShakeOnce(4f, 4f, 0.15f, 1f);
    }
}
