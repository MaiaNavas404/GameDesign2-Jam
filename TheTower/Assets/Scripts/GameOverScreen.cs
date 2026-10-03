using UnityEngine;
using UnityEngine.UI;

public class GameOverScreen : MonoBehaviour
{
    [SerializeField]Image _image;
    public static GameOverScreen Instance;

    void Awake()
    {
        Instance = this;
    }

    public void GameOver ()
    {
        _image.enabled = true;
    }
}
