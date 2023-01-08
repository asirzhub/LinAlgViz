using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VectorManager : MonoBehaviour
{
    public List<VectorHolder> vectorObjects = new List<VectorHolder>();
    public List<VectorInfoWindowState> vectorInfoStates;
    
    private void Start()
    {
        foreach (var i in GameObject.FindObjectsOfType<VectorHolder>())
        {
            vectorObjects.Add(i);
        }
    }

    private void FixedUpdate()
    {
        // I need an architecture re-write...
        foreach (var vector in vectorObjects)
        {
            //vector.
        }
    }
}
