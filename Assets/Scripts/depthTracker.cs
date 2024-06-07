using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class depthTracker : MonoBehaviour
{
    //new
    // public GameObject depthTrackerUI;
    [SerializeField] TextMeshProUGUI counter;

    float elapsedTime;
    // Update is called once per frame
    void Update()
    {
        elapsedTime += Time.deltaTime;
        int seconds = Mathf.FloorToInt(elapsedTime);
        counter.text =  "Depth:\n" + seconds + " m";
    }

//new
    // public void getDepth(){
    //     return counter.text;
    // }

    // public void stopDepthTracking(){
    //     elapsedTime = 0;
    // }
}
