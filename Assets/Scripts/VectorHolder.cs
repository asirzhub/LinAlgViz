using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//  VectorHolder doesn't hold the state (CustomVector) because
//  its data is already contained by its parent object, Global
public class VectorHolder : MonoBehaviour
{
    // tail position of the vector
    public Vector3 basePosition = Vector3.zero;
    public LineRenderer lineRenderer;
    
    public void BuildVector(CustomVector UpdatedVector)
    {
        Vector3[] positions = new Vector3[2]{basePosition, basePosition + UpdatedVector.GetVectorThree()};
        lineRenderer.SetPositions(positions);
        lineRenderer.SetColors(UpdatedVector.vectorColor, UpdatedVector.vectorColor);
    }
}
