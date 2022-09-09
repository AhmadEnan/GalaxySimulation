using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(Generator))]
public class MGEditor : Editor
{
    MapDisplay mapDisplay;
    public override void OnInspectorGUI()
    {
        if (mapDisplay == null)
            mapDisplay = GameObject.FindGameObjectWithTag("MapDisplay").GetComponent<MapDisplay>();

        Generator gen = (Generator)target;

        if (DrawDefaultInspector() || GUILayout.Button("Generate")) 
        {
            float[,] map = gen.GetNoiseMap();
            mapDisplay.DrawMap(map);
        }
        // if (GUILayout.Button("Generate")) 
        // {
        //     float [,] map = gen.GetNoiseMap();
        //     mapDisplay.DrawMap(map);
        // }
    }
   
}
