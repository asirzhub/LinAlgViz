using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class AppUIState
{
    public VectorListState vectorListState;
}

public class AppUI : MonoBehaviour
{
    public AppUIState state;
    public VectorList vectorList;

    public void UpdateView()
    {
        state.vectorListState = vectorList.state;
        vectorList.UpdateView();
    }
}
