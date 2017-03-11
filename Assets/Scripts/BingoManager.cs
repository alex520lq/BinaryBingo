using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BingoManager : MonoBehaviour {


    public TextMesh[] b_labels = new TextMesh[5];
    public TextMesh[] i_labels = new TextMesh[5];
    public TextMesh[] n_labels = new TextMesh[5];
    public TextMesh[] g_labels = new TextMesh[5];
    public TextMesh[] o_labels = new TextMesh[5];

    [HideInInspector]
    public List<TextMesh[]> textMeshes = new List<TextMesh[]>();

    public struct BingoCall
    {
        public int index;
        public int column;
    }
    Dictionary<BingoCall, TextMesh> mapping = new Dictionary<BingoCall, TextMesh>();
    
    public BingoBoard board;

    // Use this for initialization
    void Start () {

        textMeshes.Add(b_labels);
        textMeshes.Add(i_labels);
        textMeshes.Add(n_labels);
        textMeshes.Add(g_labels);
        textMeshes.Add(o_labels);

        
        for (int col = 0; col < board.Board.Length; col++)
        {
            for (int row = 0; row < board.Board[col].Length; row++)
            {
                textMeshes[col][row].text = board.Board[col][row].ToString();
                mapping[new BingoCall() { column = col, index = row }] = textMeshes[col][row];
            }
        }
	}

    public void CallBingoNumber()
    {
        int key = Random.Range(1, 99);
        int bingoLetter = Random.Range(0,4);

        Debug.Log("Bingo info called is " + bingoLetter + " column and " + key + " row");

        if (board != null)
        {
            int hitResult = board.FindValue(key, (BingoBoard.Column)bingoLetter);
            if (hitResult != -1)
            {
                ColorAHit(new BingoCall() { column = bingoLetter, index = hitResult });
            }
        }
    }

    private void ColorAHit(BingoCall call)
    {
        TextMesh mesh = null;
        if (mapping.TryGetValue(call, out mesh))
        {
            mesh.transform.parent.gameObject.GetComponent<Renderer>().material.color = Color.red;
        }
        
    }


}
