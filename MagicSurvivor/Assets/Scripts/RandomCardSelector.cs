using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RandomCardSelector : MonoBehaviour
{
    // Start is called before the first frame update
    
    public Sprite[] images;
    public Image image1;
    public Image image2;
    public Image image3;

    public float increaseSpeedAmount = 0.5f;
    
    public Sprite speedUpSprite;
    public Sprite damageUpSprite; 
    public Sprite attackSpeedUpSprite; 
    public Sprite arrowLevelUpSprite; 
    public Sprite shieldLevelUpSprite; 
    public Sprite spearLevelUpSprite; 
    
    [SerializeField] private GameObject upgradeUI; // Upgrade UI 추가
    public void Upgrade()
    {
        List<Sprite> selectedImages = GetRandomImages(images, 3);
        
        // 하위 UI의 이미지 변경
        image1.sprite = selectedImages[0];
        image2.sprite = selectedImages[1];
        image3.sprite = selectedImages[2];
    }

    void Start()
    {
        // 버튼 클릭 이벤트 등록
        image1.GetComponent<Button>().onClick.AddListener(() => OnImageClick(image1.sprite));
        image2.GetComponent<Button>().onClick.AddListener(() => OnImageClick(image2.sprite));
        image3.GetComponent<Button>().onClick.AddListener(() => OnImageClick(image3.sprite));
        
        List<Sprite> selectedImages = GetRandomImages(images, 3);
        
        // 하위 UI의 이미지 변경
        image1.sprite = selectedImages[0];
        image2.sprite = selectedImages[1];
        image3.sprite = selectedImages[2];
    }
    
    List<Sprite> GetRandomImages(Sprite[] sourceImages, int numberOfImages)
    {
        List<Sprite> imageList = new List<Sprite>(sourceImages);
        List<Sprite> selectedImages = new List<Sprite>();

        for (int i = 0; i < numberOfImages; i++)
        {
            if (imageList.Count == 0) break;

            int randomIndex = Random.Range(0, imageList.Count);
            selectedImages.Add(imageList[randomIndex]);
            imageList.RemoveAt(randomIndex);
        }

        return selectedImages;
    }
    
    private void OnImageClick(Sprite clickedSprite)
    {
        Debug.Log(clickedSprite + " is clicked");
        // 클릭된 이미지가 SpeedUp인지 확인
        if (clickedSprite == speedUpSprite)
        {
            // PlayerControl의 인스턴스를 찾아서 속도 증가
            PlayerControl playerControl = FindObjectOfType<PlayerControl>();
            if (playerControl != null)
            {
                playerControl.IncreaseSpeed(increaseSpeedAmount);
                upgradeUI.SetActive(false);
                Time.timeScale = 1;
            }
        }
        else if (clickedSprite == damageUpSprite)
        {
            ArrowSpawn arrowSpawn = FindObjectOfType<ArrowSpawn>();
            ShieldSpawn shieldSpawn = FindObjectOfType<ShieldSpawn>();
            SpearSpawn spearSpawn = FindObjectOfType<SpearSpawn>();
            if (arrowSpawn != null)
            {
                arrowSpawn.DamageLevelUp();
            }

            if (shieldSpawn != null)
            {
                shieldSpawn.DamageLevelUp();
            }

            if (spearSpawn != null)
            {
                spearSpawn.DamageLevelUp();
                upgradeUI.SetActive(false);
                Time.timeScale = 1;
            }
        }
        else if (clickedSprite == attackSpeedUpSprite)
        {
            ArrowSpawn arrowSpawn = FindObjectOfType<ArrowSpawn>();
            ShieldSpawn shieldSpawn = FindObjectOfType<ShieldSpawn>();
            SpearSpawn spearSpawn = FindObjectOfType<SpearSpawn>();
            if (arrowSpawn != null)
            {
                arrowSpawn.SpeedLevelUp();
            }

            if (shieldSpawn != null)
            {
                shieldSpawn.SpeedLevelUp();
            }

            if (spearSpawn != null)
            {
                spearSpawn.SpeedLevelUp();
                upgradeUI.SetActive(false);
                Time.timeScale = 1;
            }
        }
        else if (clickedSprite == arrowLevelUpSprite)
        {
            ArrowSpawn arrowSpawn = FindObjectOfType<ArrowSpawn>();

            if (arrowSpawn != null)
            {
                arrowSpawn.LevelUp();
                upgradeUI.SetActive(false);
                Time.timeScale = 1;
            }
        }
        else if (clickedSprite == shieldLevelUpSprite)
        {
            ShieldSpawn shieldSpawn = FindObjectOfType<ShieldSpawn>();

            if (shieldSpawn != null)
            {
                shieldSpawn.LevelUp();
                upgradeUI.SetActive(false);
                Time.timeScale = 1;
            }
        }
        else if (clickedSprite == spearLevelUpSprite)
        {
            SpearSpawn spearSpawn = FindObjectOfType<SpearSpawn>();
            if (spearSpawn != null)
            {
                spearSpawn.LevelUp();
                upgradeUI.SetActive(false);
                Time.timeScale = 1;
            }
        }
    }
}
