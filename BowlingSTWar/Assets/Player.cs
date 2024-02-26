using UnityEngine;

public class Player : MonoBehaviour
{
    public delegate void IsPlayingChanged(bool newValue);
    public event IsPlayingChanged OnIsPlayingChanged;
    private ResetGame resetGame;
    private bool _isPlaying = false;
    public bool isPlaying
    {
        get { return _isPlaying; }
        set
        {
            if (_isPlaying != value)
            {
                _isPlaying = value;
                OnIsPlayingChanged?.Invoke(_isPlaying);
            }
        }
    }

    void Start()
    {
        GameObject resetGameObj = GameObject.Find("Reset (Legacy) (1)");
        if (resetGameObj != null)
        {
            resetGame = resetGameObj.GetComponent<ResetGame>();
        }
        else
        {
            Debug.LogError("ResetGame object not found in the scene.");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartGame()
    {
        isPlaying = true;
        resetGame.ResetGameLevel();
    }

    public void ToggleIsPlaying()
    {
        isPlaying = !isPlaying;
    }
}
