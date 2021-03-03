using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardStateController : MonoBehaviour
{
    public string[] row1 = {"", "", ""};
    public string[] row2 = { "", "", "" };
    public string[] row3 = { "", "", "" };

    public string[][] board;

    [SerializeField]
    private TTTController _TTTController;


    // Start is called before the first frame update
    void Start()
    {
        board = new string[3][];
    }


    public async void MakeMove()
    {
        board[0] = row1;
        board[1] = row2;
        board[2] = row3;
        var result = await _TTTController.NextGameState(board);

        Debug.Log("Test1 " + result.ToString());
        Debug.Log("Test2 "+result.board[0]);

        row1 = result.board[0];
        row2 = result.board[1];
        row3 = result.board[2];


    }


}
