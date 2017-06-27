using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestroyOnLoad : MonoBehaviour {

    // Make this game object and all its transform children
    // survive when loading a new scene.
    void Awake()
    {
        DontDestroyOnLoad(this);
    }
}
