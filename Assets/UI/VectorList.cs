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
        for (int i = 0; i <  state.vectors.Count; i++)
        {
            var g = Instantiate(vectorInfoWindowPrefab).GetComponent<VectorInfoWindow>();
            g.transform.parent = this.transform;
            g.state = new VectorInfoWindowState(state.vectors[i]);
            g.state.vectorID = i;
            g.UpdateView();
        }
    }

    public void ApplyAndUpdate()
    {
        ApplyToState();
        UpdateView();
    }
}
