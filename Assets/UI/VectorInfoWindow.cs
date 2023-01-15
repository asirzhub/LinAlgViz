using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.PlayerLoop;
using UnityEngine.UI;

public class VectorInfoWindowState
{
    public int vectorID; // read only
    public string vectorName;
    public Vector3 components;
    public Color vectorColor;

    public VectorInfoWindowState(CustomVector v)
    {
        vectorName = v.nameTag;
        // will need to replace the components variable as List<float> soon
        components = new Vector3() { x = v.components[0], y = v.components[1], z = components[2] };
        vectorColor = v.vectorColor;
    }
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

    // modify the model with this function
    public void ApplyToState()
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
    
    // modify the view with this function
    public void UpdateView()
    {
        vectorName.SetTextWithoutNotify(state.vectorName);

        Vector3 stateComps = state.components;
        x.SetTextWithoutNotify(stateComps.x.ToString());
        y.SetTextWithoutNotify(stateComps.y.ToString());
        z.SetTextWithoutNotify(stateComps.z.ToString());

        colorPreview.color = state.vectorColor;
    }

    public void ApplyAndUpdate()
    {
        ApplyToState();
        UpdateView();
    }
}
