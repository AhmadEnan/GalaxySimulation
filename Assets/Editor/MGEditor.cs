using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(MapDisplay))]
public class MGEditor : Editor
{
    public override void OnInspectorGUI() 
    {
        MapDisplay md = (MapDisplay)target;
        if (DrawDefaultInspector()) 
        {
            md.DrawMap();
        }
        if (GUILayout.Button("Generate")) 
        {
            md.DrawMap();
        }
    }
   
}
