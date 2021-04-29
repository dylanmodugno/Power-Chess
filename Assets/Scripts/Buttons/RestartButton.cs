using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RestartButton : MonoBehaviour
{
    public Button button;

    // Start is called before the first frame update
    void Start()
    {
            ColorBlock colors = button.colors;
            colors.normalColor = Color.green;
            colors.highlightedColor = new Color32(60, 200, 50, 255);
            button.colors = colors;
    }

    public void Restart()
    {
        BoardManager board = BoardManager.Instance;
        board.RestartGame();
    }
}
