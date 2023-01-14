using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class VectorListState
{
    public List<CustomVector> vectors;
}

public class VectorList : MonoBehaviour
{
    public VectorListState state;
    
    public List<VectorInfoWindow> vectorInfoWindows;
    
    // modify the model with this function
    public void ApplyToState()
    {
        
    }
    
    // modify the view with this function, using ONLY state variables
    public void UpdateView()
    {
        
    }

    public void ApplyAndUpdate()
    {
        ApplyToState();
        UpdateView();
    }
}
