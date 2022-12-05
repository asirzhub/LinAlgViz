using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VectorHolder : MonoBehaviour
{
    // metadata about the vector
    public int id;
    public bool dirty = true; // if the vector's appearnce (view) needs to be refreshed
    public bool needsRegen = true; // if the vector's number of components has changed

    //visibility of vector
    public bool visible = true;
    public string label;
    public Color vColor;

    //dimensions and components of vector
    public int dimensions;
    public float[] components;

    // tail position of the vector
    public Vector3 basePosition;

    public LineRenderer lineRenderer;

    private void Update()
    {
        if (dirty)
        {
            dirty = false;

            if (needsRegen) // component number has changed
            {
                needsRegen = false;

                // before making a new list of components, temporarily store the old values
                List<float> lastValues = new List<float>();
                foreach(var i in components)
                { 
                    lastValues.Add(i); 
                }

                components = new float[dimensions];

                // to prevent index errors take the lowest num of indexes of the two (old vs new component num)
                // and place in values where possible
                int mindexes = (int)Mathf.Min(components.Length, lastValues.Count);
                for(int i = 0; i < mindexes; i++)
                {
                    components[i] = lastValues[i];
                }
            }

            //temporarily set to 3d
            Vector3 direction = Vector3.Normalize(new Vector3(components[0], components[1], components[2]));
            Vector3[] positions = new Vector3[4] { basePosition, basePosition + direction, basePosition + (2 * direction), basePosition + (3 * direction) };

            lineRenderer.material.SetColor("_Color", vColor);
            lineRenderer.SetPositions(positions);
        }
    }
}
