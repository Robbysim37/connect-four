using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class slot : MonoBehaviour
{
    public controller cont;
    public SpriteRenderer spriteRenderer;
    public int index;

    private void OnMouseDown()
    {
        StartCoroutine(ChipFall());
    }

    private void OnMouseEnter()
    {
        spriteRenderer.color = new Color(0, 0, 0, 0.2f);
    }

    private void OnMouseExit()
    {
        spriteRenderer.color = Color.clear;
    }

    private IEnumerator ChipFall()
    {
        cont.SetSlotsOn(false);

        //board[row][column]

        for (int i = 0; i < cont.board.Count; i++)
        {
            if (cont.board[i][index].spriteRenderer.color == Color.clear) //the next spot is clear
            {
                if (i != 0) //if there is a spot above where the chip currently is, make it clear
                {
                    cont.board[i - 1][index].spriteRenderer.color = Color.clear;
                }

                //make the current spot the player's color
                cont.board[i][index].spriteRenderer.color = cont.currentColor;

                yield return new WaitForSeconds(0.1f);
            }
            else
            {
                if (i == 0) //column is full
                {
                    cont.SetSlotsOn(true);
                    yield break; //break out of the IENumerator
                }
                else //chip has fallen as far as it can
                {
                    break; //break out of for loop
                }
            }
        }

        cont.SetSlotsOn(true);
        cont.EndTurn();
    }
}
