using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppState
{
    
    public List<CustomVector> allVectorsData;
    public List<VectorHolder> allVectorsView;
    public List<CustomMatrix> allMatrices;
}

public class G
{
    public static Global I
    {
        get
        {
            if (_I == null) _I = GameObject.FindObjectOfType<Global>();
            return _I;
        }
    }

    static Global _I;
}

public class Global : MonoBehaviour
{
    public AppState appState;
    public GameObject vectorViewPrefab;
    public AppUI appUI;
    
    private void Awake()
    {
        appState = new AppState();
        appState.allVectorsData = new List<CustomVector>()
        {
            new CustomVector(new List<float>(){1, 0, 0}, Color.red, "X", true),
            new CustomVector(new List<float>(){0, 1, 0}, Color.green, "Y", true),
            new CustomVector(new List<float>(){0, 0, 1}, Color.blue, "Z", true) 
        };

        foreach (var vectorData in appState.allVectorsData)
        {
            var vectorView = Instantiate(vectorViewPrefab).GetComponent<VectorHolder>();
            vectorView.transform.parent = this.transform;
            vectorView.BuildVector(vectorData);
        }

        appUI.vectorList.state.vectors = appState.allVectorsData;
        appUI.vectorList.UpdateView();
    }

    public void UpdateView()
    {
        appState.allVectorsData = new List<CustomVector>();// flush
        
        foreach (var vectorData in appState.allVectorsData)
        {
            var vectorView = Instantiate(vectorViewPrefab).GetComponent<VectorHolder>();
            vectorView.transform.parent = this.transform;
            vectorView.BuildVector(vectorData);
        }

        appUI.vectorList.state.vectors = appState.allVectorsData;
        appUI.vectorList.UpdateView();
    }
}