using UnityEngine;
using UnityEngine.UI;

public class DifficultyButton : MonoBehaviour
{

    private Button button;
    GameManager gameManager;

    public int difficultySet;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(SetDifficulty);
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
    }

    void SetDifficulty()
    {
        gameManager.StartGame(difficultySet);
        Debug.Log(gameObject.name + " got touched by BDR");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
