using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class PlayerExpSystem : MonoBehaviour
{
    private int exp = 0;
    private int expMax = 1;
    
    private int level = 0;

    [SerializeField] private TextMeshProUGUI levelText;
    [SerializeField] private Slider expSlider;
    [SerializeField] private GameObject upgradeUI;
    
    private RandomCardSelector randomCardSelector;
    
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
        UpdateDisplay();
        UpdateSlider();
        
        randomCardSelector = upgradeUI.GetComponentInChildren<RandomCardSelector>();
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
        UpdateSlider();
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
        UpdateSlider();
       
        // 게임 정지
        Time.timeScale = 0;
        // Upgrade UI
        randomCardSelector?.Upgrade();
        upgradeUI.SetActive(true);
    }

    void UpdateSlider()
    {
        expSlider.maxValue = expMax;
        expSlider.value = exp;
    }
    
    void Update()
    {
        // 게임이 정지된 상태에서 R 키를 누르면 게임 재개
        if (Time.timeScale == 0 && Input.GetKeyDown(KeyCode.R))
        {
            Time.timeScale = 1; // 게임 시간 재개
            upgradeUI.SetActive(false); // Upgrade UI 비활성화
            
        }
    }
}