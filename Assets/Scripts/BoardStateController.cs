using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(ClickedObjGetter),typeof(TTTController))]
public class BoardStateController : MonoBehaviour
{
    public TTTTile[] boardTilesRow1;
    public TTTTile[] boardTilesRow2;
    public TTTTile[] boardTilesRow3;


    private string[][] board;
    private string[][] oldBoard;


    private TTTTile[][] boardTiles;

    private TTTController _TTTController;
    private ClickedObjGetter _clickedObjectGetter;
    public bool IsX=true;
    public GameObject xObj;
    public GameObject oObj;
    string symbol;
    GameObject symbolObj;


    bool moveCompleted=true;

    // Start is called before the first frame update
    void Start()
    {
        symbol = IsX ? "X" : "O";
        symbolObj = symbol == "X" ? xObj : oObj;

        board = new string[3][];
        board[0] = new[] { "", "", ""};
        board[1] = new[] { "", "", "" };
        board[2] = new[] { "", "", "" };
        oldBoard = board;
        boardTiles = new TTTTile[3][];
        boardTiles[0] = boardTilesRow1;
        boardTiles[1] = boardTilesRow2;
        boardTiles[2] = boardTilesRow3;
        _TTTController = GetComponent<TTTController>();
        _clickedObjectGetter = GetComponent<ClickedObjGetter>();
        _clickedObjectGetter.onGetObject.AddListener(MakeMove);

    }


    public async void MakeMove()
    {
       if(!moveCompleted)
        {
            return;
        }


        bool madeMove = false;

        switch (_clickedObjectGetter.MostRecentObject.name)
        {
            case "TileTL":
                board[0][0] = symbol;
                madeMove = ValidateMove(board[0][0], boardTiles[0][0]);
                break;
            case "TileTM":
                board[0][1] = symbol;
                madeMove = ValidateMove(board[0][1], boardTiles[0][1]);
                break;
            case "TileTR":
                board[0][2] = symbol;
                madeMove = ValidateMove(board[0][2], boardTiles[0][2]);
                break;
            case "TileML":
                board[1][0] = symbol;
                madeMove = ValidateMove(board[1][0], boardTiles[1][0]);
                break;
            case "TileMM":
                board[1][1] = symbol;
                madeMove = ValidateMove(board[1][1], boardTiles[1][1]);
                break;
            case "TileMR":
                board[1][2] = symbol;
                madeMove = ValidateMove(board[1][2], boardTiles[1][2]);
                break;
            case "TileBL":
                board[2][0] = symbol;
                madeMove = ValidateMove(board[2][0], boardTiles[2][0]);
                break;
            case "TileBM":
                board[2][1] = symbol;
                madeMove = ValidateMove(board[2][1], boardTiles[2][1]);
                break;
            case "TileBR":
                board[2][2] = symbol;
                madeMove = ValidateMove(board[2][2], boardTiles[2][2]);
                break;
        }

        if (!madeMove)
        {
            return;
        }

        moveCompleted = false;
        TTTController.DataModel result = await _TTTController.NextGameState(board);

        // Debug.Log("Test1 " + result.ToString());
        // Debug.Log("Test2 "+result.board[0]);




        RecieveMove(result);


    }

    void RecieveMove(TTTController.DataModel result)
    {
        board = result.board;

        for (int i = 0; i < board.Length; i++)//refactor this, and the other obvious thing..
        {
            for (int j = 0; j < board[i].Length; j++)
            {
                if(oldBoard[i][j]!=board[i][j])
                {
                    boardTiles[i][j].PerformMove(symbol == "X" ?oObj:xObj,1);
                }
            }
        }
        Debug.Log("checked new board");
        moveCompleted = true;
        oldBoard = board;
    }

    bool ValidateMove(string boardName, TTTTile boardTile)
    {
        if (boardTile.symbolObj==null)
        {
            boardTile.PerformMove(symbolObj,1);
            return true;
        }
        return false;
    }

}
