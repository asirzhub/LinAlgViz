using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomVector
{
    public List<int> components;
    public Color vectorColor;
    public string nameTag;
    public bool visible;

    public CustomVector(List<int> newComps, Color c, string s, bool visible)
    {
        this.components = newComps;
        this.vectorColor = c;
        this.nameTag = s;
        this.visible = visible;
    }

    public int Dimensions()
    {
        return components.Count;
    }
}

public class CustomMatrix
{
    public List<CustomVector> componentVectors;
    public Color matrixColor;
    public string nameTag;
    public bool visible;

    public CustomMatrix(List<CustomVector> newComps, Color c, string s, bool visible)
    {
        // implement error catching for invalid vectors
        this.componentVectors = newComps;
        this.matrixColor = c;
        this.nameTag = s;
        this.visible = visible;
    }

    public int Dimensions()
    {
        return componentVectors.Count;
    }
}
