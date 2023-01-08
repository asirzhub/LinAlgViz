using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.PlayerLoop;
using UnityEngine.UI;

public struct VectorInfoWindowState
{
    public int vectorID; // read only
    public string vectorName;
    public Vector3 components;
    public Color vectorColor;
}

public class VectorInfoWindow : MonoBehaviour
{
    public VectorInfoWindowState state;
    
    public TMP_InputField vectorName;

    public TMP_InputField x;
    public TMP_InputField y;
    public TMP_InputField z;

    public Image colorPreview;

    public float ParseFloat(string f)
    {
        float output = 0f;
        float.TryParse(f, out output);
        return output;
    }
    
    public void UpdateStateFromFields()
    {
        state.vectorName = vectorName.text;
        Vector3 componenets = new Vector3
        {
            x = ParseFloat(x.text),
            y = ParseFloat(y.text),
            z = ParseFloat(z.text)
        };
        state.components = componenets;
        
        // TODO : get a color picker
        //state.vectorColor = vectorName.text;
    }

    public void ApplyState()
    {
        // send the new data, from the state, to the vector manager
        //   (manager will handle applying the settings to the correct vector)
        
        vectorName.SetTextWithoutNotify(state.vectorName);

        Vector3 stateComps = state.components;
        x.SetTextWithoutNotify(stateComps.x.ToString());
        y.SetTextWithoutNotify(stateComps.y.ToString());
        z.SetTextWithoutNotify(stateComps.z.ToString());

        colorPreview.color = state.vectorColor;
    }

    public void UpdateAndApplyState()
    {
        UpdateStateFromFields();
        ApplyState();
    }
}
