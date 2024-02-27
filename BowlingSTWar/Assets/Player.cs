using System.Collections.Generic;
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

    // Mảng lưu trữ số pin hạ gục từ mỗi lượt ném
    private List<int> rolls = new List<int>();

    // Hàm thêm số pin hạ gục từ mỗi lượt ném
    public void Roll(int pins)
    {
        rolls.Add(pins);
    }

    // Hàm tính tổng điểm
    public int CalculateScore()
    {
        int score = 0;
        int rollIndex = 0;

        for (int frame = 0; frame < 10; frame++)
        {
            if (IsStrike(rollIndex)) // Strike
            {
                score += 10 + StrikeBonus(rollIndex);
                rollIndex++;
            }
            else if (IsSpare(rollIndex)) // Spare
            {
                score += 10 + SpareBonus(rollIndex);
                rollIndex += 2;
            }
            else // Open Frame
            {
                score += SumOfBallsInFrame(rollIndex);
                rollIndex += 2;
            }
        }

        return score;
    }

    // Hàm kiểm tra xem lượt ném có phải là Strike không
    private bool IsStrike(int rollIndex)
    {
        return rolls[rollIndex] == 10;
    }

    // Hàm kiểm tra xem lượt ném có phải là Spare không
    private bool IsSpare(int rollIndex)
    {
        return rolls[rollIndex] + rolls[rollIndex + 1] == 10;
    }

    // Hàm tính điểm thưởng từ lượt ném Strike
    private int StrikeBonus(int rollIndex)
    {
        return rolls[rollIndex + 1] + rolls[rollIndex + 2];
    }

    // Hàm tính điểm thưởng từ lượt ném Spare
    private int SpareBonus(int rollIndex)
    {
        return rolls[rollIndex + 2];
    }

    // Hàm tính tổng số pin hạ gục trong một frame
    private int SumOfBallsInFrame(int rollIndex)
    {
        return rolls[rollIndex] + rolls[rollIndex + 1];
    }
}

