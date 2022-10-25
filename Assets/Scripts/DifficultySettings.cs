using UnityEngine;
using UnityEngine.UI;

public class DifficultySettings : MonoBehaviour
{
    private GameManager _gameManager;
    private Button _button;
    public int difficulty;

    private void Start()
    {
        _button = GetComponent<Button>();
        _button.onClick.AddListener(SetDifficulty);
    }

    private void SetDifficulty()
    {
        _gameManager.StartGame(difficulty);
    }
}
