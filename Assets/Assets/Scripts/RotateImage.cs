using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateImage : MonoBehaviour
{
    //Just click and rotate

        private void OnMouseDown()
        {
        GameObject puzzle = GameObject.Find("Puzzle");
        var puzzlescript = puzzle.GetComponent("PuzzleScript");
        bool _win = puzzlescript.GetComponent<PuzzleScript>()._win;        

            if (!_win)
            {
                transform.Rotate(0f, 0f, 90f);
            }
        }
}
