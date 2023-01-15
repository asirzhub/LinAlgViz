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
    public GameObject vectorInfoWindowPrefab;
    public List<VectorInfoWindow> vectorInfoWindows;
    
    // modify the model with this function
    public void ApplyToState()
    {
        
    }
    
    // modify the view with this function, using ONLY state variables
    public void UpdateView()
    {
        // destroy old windows first
        foreach (var window in vectorInfoWindows)
        {
            Destroy(window);
        }
        
        //respawn new windows
        foreach (var vector in state.vectors)
        {
            var g = Instantiate(vectorInfoWindowPrefab).GetComponent<VectorInfoWindow>();
            g.transform.parent = this.transform;
            g.state = new VectorInfoWindowState(vector);
            g.UpdateView();
        }
    }

    public void ApplyAndUpdate()
    {
        ApplyToState();
        UpdateView();
    }
}
