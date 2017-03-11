using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(BingoManager))]
public class GameManagerEditor : Editor
{
    
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        BingoManager manager = target as BingoManager;

        if (GUILayout.Button("Build Object"))
        {
            manager.CallBingoNumber();
        }
    }
}
