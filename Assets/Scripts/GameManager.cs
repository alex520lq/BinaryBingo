using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {


    public TextMesh[] b_labels = new TextMesh[5];
    public TextMesh[] i_labels = new TextMesh[5];
    public TextMesh[] n_labels = new TextMesh[5];
    public TextMesh[] g_labels = new TextMesh[5];
    public TextMesh[] o_labels = new TextMesh[5];

    BingoBoard board;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
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
                ColorAHit((BingoBoard.Column)bingoLetter, hitResult);
            }
        }
    }

    private void ColorAHit(BingoBoard.Column col, int index)
    {
        switch (col)
        {
            case BingoBoard.Column.B:
                b_labels[index].GetComponent<Renderer>().material.color = Color.red;
                break;
            case BingoBoard.Column.I:
                i_labels[index].GetComponent<Renderer>().material.color = Color.red;
                break;
            case BingoBoard.Column.N:
                n_labels[index].GetComponent<Renderer>().material.color = Color.red;
                break;
            case BingoBoard.Column.G:
                g_labels[index].GetComponent<Renderer>().material.color = Color.red;
                break;
            case BingoBoard.Column.O:
                o_labels[index].GetComponent<Renderer>().material.color = Color.red;
                break;
            default:
                break;
        }
    }


}
