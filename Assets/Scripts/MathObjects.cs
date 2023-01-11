using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

[Serializable]
public class CustomVector
{
    public List<float> components;
    public Color vectorColor;
    public string nameTag;
    public bool visible;

    public Vector3 GetVectorThree()
    {
        return new Vector3(components[0], components[1], components[2]);
    }
    
    public CustomVector(List<float> newComps, Color c, string s, bool isVisible)
    {
        components = newComps;
        vectorColor = c;
        nameTag = s;
        visible = isVisible;
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

public class MathObjects
{
    public const float PIOVERTHREE = Mathf.PI / 3;
    
    // i dont get why this has to be static
    public static Color RandomColour(float t)
    {
        float r = Mathf.Sin(t);
        r *= r;
        
        float g = Mathf.Sin(t+PIOVERTHREE);
        g *= g;
        
        float b = Mathf.Sin(-PIOVERTHREE);
        b *= b;

        return new Color(r, g, b);
    }
}