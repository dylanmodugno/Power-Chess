using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Instructions : MonoBehaviour
{
    public static Instructions Instance { set; get; }

    public Image background;
    public Text heading;
    public Text instructions;
    public Button startGameButton;

    void Start()
    {
        startGameButton.onClick.AddListener(StartGame);
    }

    void Update()
    {
        background.transform.SetAsLastSibling();
        startGameButton.gameObject.SetActive(true);
    }

    public void StartGame()
    {
        background.gameObject.SetActive(false);
        heading.gameObject.SetActive(false);
        instructions.gameObject.SetActive(false);
        startGameButton.gameObject.SetActive(false);
    }
}
