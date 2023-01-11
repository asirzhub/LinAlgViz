using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Globals
{
    public static List<CustomVector> allVectorsData;
    public static List<VectorHolder> allVectorsView;
    public static List<CustomMatrix> allMatrices;
}

public class Global : MonoBehaviour
{
    public GameObject vectorViewPrefab;
    private void Awake()
    {
        Globals.allVectorsData = new List<CustomVector>()
        {
            new CustomVector(new List<float>(){1, 0, 0}, Color.red, "X", true),
            new CustomVector(new List<float>(){0, 1, 0}, Color.green, "Y", true),
            new CustomVector(new List<float>(){0, 0, 1}, Color.blue, "Z", true) 
        };

        foreach (var vectorData in Globals.allVectorsData)
        {
            var vectorView = Instantiate(vectorViewPrefab).GetComponent<VectorHolder>();
            vectorView.transform.parent = this.transform;
            vectorView.BuildVector(vectorData);
        }
    }

    private float timer = 3;

    private void Update()
    {
        timer += Time.deltaTime;

        if (timer > 3)
        {
            timer = 0;
        }
    }
}