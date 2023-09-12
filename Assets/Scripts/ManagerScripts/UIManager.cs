using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scoreText;

    public static UIManager instantiate;

    void Awake(){
        instantiate = this;
    }

    void OnEnable(){
        EventManager.OnScoreUpdate += ScoreUpdate;
    }
    void OnDisable(){
        EventManager.OnScoreUpdate -= ScoreUpdate;
    }

    public void ScoreUpdate(){
        scoreText.text = (int.Parse(scoreText.text)+1).ToString();
    }

    public void GameOver(){
        //to do
    }
}
