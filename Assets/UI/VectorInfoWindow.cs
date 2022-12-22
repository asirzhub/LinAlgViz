using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class VectorInfoWindowState : UIState
{
    public string vectorName;
    public Vector3 components;
    public Color vectorColor;

    public override void ApplyNewState()
    {

    }
}

public class VectorInfoWindow : MonoBehaviour
{
    public TMP_InputField vectorName;

    public TMP_InputField x;
    public TMP_InputField y;
    public TMP_InputField z;

    public Image colorPreview;
}
