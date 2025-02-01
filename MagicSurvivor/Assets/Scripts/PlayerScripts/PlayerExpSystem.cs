using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class PlayerExpSystem : MonoBehaviour
{
    private int exp = 0;
    private int expMax = 1;
    
    private int level = 0;

    [SerializeField] private TextMeshProUGUI levelText;
    
    // 레벨에 따라 expMax를 증가시키는 메서드
    private int CalculateExpMax(int level)
    {
        // 예: 레벨에 따라 expMax를 1.5배씩 증가시키기
        return Mathf.FloorToInt(1 * Mathf.Pow(1.5f, level));
    }
    
    // Start is called before the first frame update
    void Start()
    {
        expMax = CalculateExpMax(level); // 초기 expMax 설정
        LevelUp();
    }

    // Update is called once per frame
    void UpdateDisplay()
    {
        levelText.text = "Lv. " + level;
    }

    public void IncreaseExp(int amount)
    {
        exp += amount;
        CheckExp();
    }

    void CheckExp()
    {
        if (exp >= expMax)
        {
            exp = exp - expMax;
            LevelUp();
        }
    }
    
    void LevelUp()
    {
        level++;
        expMax = CalculateExpMax(level); // 레벨업 시 expMax 증가
        Debug.Log($"Level Up! New Level: {level}, New ExpMax: {expMax}");
        UpdateDisplay();
        // Upgrade UI 보이도록
        // 
    }
}