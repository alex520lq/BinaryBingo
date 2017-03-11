using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class BingoBoard : MonoBehaviour {

    private int[][] board;
    public int[][] Board { get { return board; } }


    private void Awake()
    {
        board = new int[5][];
        generateNewBoard(board);
    }

    public int FindValue(int key, Column col)
    {
        //Get min and max values for the column and then pass it in.
        int min = board[(int)col].Min();
        int max = board[(int)col].Max();
        return binarysearchrecursive(board[(int)col], key, min, max);
    }

    //public int FindValue (int key, int col)
    //{
    //    return FindValue(key, col);
    //}

    private static int binarysearchrecursive(int[] inputarray, int key, int min, int max)
    {
        if (max < min) { return -1; }

        int mid = (min + max) / 2;
        if (key == inputarray[mid])
        {
            return mid;
        }
        else if (key < inputarray[mid])
        {
            return binarysearchrecursive(inputarray, key, min, mid - 1);
        }
        else
        {
            return binarysearchrecursive(inputarray, key, mid + 1, max);
        }
    }

    private void generateNewBoard(int[][] board)
    {
        int value = 1;
        for (int column = 0; column < board.Length; column++)
        {
            board[column] = new int[5];
            for (int row = 0; row < 5; row++)
            {
                int addedRandomNumber = Random.Range(1, 19);
                if (value + addedRandomNumber < 100)
                {
                    value += addedRandomNumber;
                    int newValue = value;
                    board[column][row] = newValue;
                }

            }
            value = 1;//Reset per column
        }
    }

    public enum Column
    {
        B, I, N, G, O
    }
}
