using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {


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
            }
        }
	}

    public void CallBingoNumber()
    {
        int newNum = Random.Range(1, 99);
        int bingoLetter = Random.Range(1,5);
        if (board != null)
        {
            int hitResult = board.FindValue(newNum, (BingoBoard.Column)bingoLetter);
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
            mesh.GetComponent<Renderer>().material.color = Color.red;
        }
        
    }


}
