using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisplayTitleScript : MonoBehaviour
{

    public float waitTime = 1;
    public GameObject titlePanel;

    // Use this for initialization
    void Start()
    {
        Invoke("DisplayTitle", waitTime);
    }

    void DisplayTitle()
    {

        titlePanel.SetActive(true);
        //Debug.Log("Display Title Panel");
    }

}
