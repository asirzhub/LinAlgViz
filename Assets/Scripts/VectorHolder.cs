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
    public Transform cone;
    
    public void BuildVector(CustomVector UpdatedVector)
    {
        Vector3 tipLocation = basePosition + UpdatedVector.GetVectorThree();
        Vector3[] positions = new Vector3[2]{basePosition, tipLocation};
        lineRenderer.SetPositions(positions);
        lineRenderer.material.SetColor("_Color", UpdatedVector.vectorColor);

        cone.transform.position = tipLocation;
        cone.LookAt(2*tipLocation);
        cone.GetComponent<Renderer>().material.SetColor("_Color", UpdatedVector.vectorColor);

        float coneSizeMult = Vector3.Magnitude(UpdatedVector.GetVectorThree()) * Globals.vectorTipScalar;
        cone.transform.localScale = new Vector3(coneSizeMult, coneSizeMult, coneSizeMult);
    }
}
