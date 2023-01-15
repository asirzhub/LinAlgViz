using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class AppUIState
{
    public VectorListState vectorsListState;
    public MenuBarState menuBarState;
}

public class AppUI : MonoBehaviour
{
    public AppUIState state;
    public VectorList vectorList;
    public MenuBar menuBar;

    private void Awake()
    {
        state.vectorsListState = vectorList.state;
        state.menuBarState = menuBar.state;
    }

    public void UpdateView()
    {
        vectorList.state = state.vectorsListState;
        menuBar.state = state.menuBarState;
    }
}
