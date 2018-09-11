using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitialSphereDisplay : MonoBehaviour
{

    public string videoURL;

    void Start()
    {
        // Keep this gameobject to hold variables.
        DontDestroyOnLoad(this.gameObject);
    }

}
