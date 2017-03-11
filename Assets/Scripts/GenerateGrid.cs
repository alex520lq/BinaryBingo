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

        GameObject master = new GameObject();
        master.name = "Bingo Board";
        BingoBoard board = master.AddComponent<BingoBoard>();
        GameManager manager = master.AddComponent<GameManager>();
        manager.board = board;

        for (int colu = 0; colu < 5; colu++)
        {
            GameObject bingoColumn = new GameObject();
            bingoColumn.name = "Column " + (colu + 1).ToString();
            bingoColumn.transform.parent = master.transform;

            for (int row = 6; row > 0; row--)
            {
                GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
                if (row == 1)
                {
                    cube.name = "Header";
                }
                else
                    cube.name = "Col " + (colu + 1).ToString() + " row " + (row - 1);

                cube.transform.position = position;
                cube.transform.localScale += new Vector3(3, 0, 3);
                cube.transform.parent = bingoColumn.transform;

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
                setTextMeshRefs(colu, manager, row, text);

                position += new Vector3(0, 0, 5);
            }
            position.z = 0;
            position += new Vector3(5, 0, 0);
        }
    }

    private static void setTextMeshRefs(int col, GameManager manager, int row, TextMesh mesh)
    {
        if (row != 1 && (row - 2) >= 0)
        {
            switch (col)
            {
                case 0:
                    manager.b_labels[row-2] = mesh;
                    break;
                case 1:
                    manager.i_labels[row-2] = mesh;
                    break;
                case 2:
                    manager.n_labels[row-2] = mesh;
                    break;
                case 3:
                    manager.g_labels[row-2] = mesh;
                    break;
                case 4:
                    manager.o_labels[row-2] = mesh;
                    break;

                default:
                    break;
            }
        }
        
    }
}
