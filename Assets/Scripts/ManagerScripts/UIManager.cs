using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scoreText;
    
    public static UIManager Instance;
    
    private void Awake(){
        Instance = this;
    }

    public void ScoreUpdate(){
        scoreText.text = (int.Parse(scoreText.text)+1).ToString();
    }

}
