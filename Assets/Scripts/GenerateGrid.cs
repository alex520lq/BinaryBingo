using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class GenerateGrid : MonoBehaviour
{
    [MenuItem("My Tools/Create Bingo Grid")]
    private static void generateGrid()
    {
        Vector3 position = Vector3.zero;
        
        for (int j = 0; j < 5; j++)
        {
            for (int i = 0; i < 6; i++)
            {
                GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
                cube.transform.position = position;
                cube.transform.localScale += new Vector3(3, 0, 3);

                GameObject go = new GameObject();
                go.transform.parent = cube.transform;
                go.transform.localPosition = Vector3.zero;
                go.name = "label";
                TextMesh text = go.AddComponent<TextMesh>();
                text.transform.localScale = new Vector3(1, 1, 1);
                text.transform.parent = go.transform;
                text.transform.localPosition = Vector3.zero;
                text.fontSize = 500;
                text.characterSize = 0.017f;
                text.text = "99";
                text.color = Color.black;
                text.anchor = TextAnchor.MiddleCenter;
                text.transform.Rotate(Vector3.right, 90f);

                
                position += new Vector3(0, 0, 5);
            }
            position.z = 0;
            position += new Vector3(5, 0, 0);
        }
    }
}
