using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scoreText;

    void OnEnable(){
        EnemyController.OnScoreUpdate += ScoreUpdate;
    }
    void OnDisable(){
        EnemyController.OnScoreUpdate -= ScoreUpdate;
    }

    public void ScoreUpdate(){
        scoreText.text = (int.Parse(scoreText.text)+1).ToString();
    }

}
