using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class controller : MonoBehaviour
{
    public List<List<spot>> board = new();

    public List<spot> row0;
    public List<spot> row1;
    public List<spot> row2;
    public List<spot> row3;
    public List<spot> row4;
    public List<spot> row5;

    public List<slot> slots;

    public Color currentColor;
    public Color player1Color;
    public Color player2Color;

    // Start is called before the first frame update
    void Start()
    {
        board.Add(row0);
        board.Add(row1);
        board.Add(row2);
        board.Add(row3);
        board.Add(row4);
        board.Add(row5);
    }
    public void EndTurn()
    {
        currentColor = currentColor == player1Color ? player2Color : player1Color;

        print($"player 1 has connected 4: {CheckWin(player1Color)}");
        print($"player 2 has connected 4: {CheckWin(player2Color)}");
    }

    private bool CheckWin(Color player)
    {
        return true;
    }

    public void SetSlotsOn(bool isOn)
    {
        foreach(slot currSlot in slots)
        {
            currSlot.GetComponent<BoxCollider2D>().enabled = isOn;
        }
    }
}
