using UnityEngine;

[System.Serializable]
public class UpgradeSprite
{
    public Sprite sprite; // 스프라이트
    public int level; // 현재 레벨
    public const int maxLevel = 5; // 최대 레벨

    public bool CanLevelUp() // 레벨업 가능 여부 체크
    {
        return level < maxLevel;
    }

    public void LevelUp() // 레벨업 메서드
    {
        if (CanLevelUp())
        {
            level++;
        }
    }
}