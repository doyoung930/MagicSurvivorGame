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

    private int speedLevel = 0;
    private int damageLevel = 0;
    private int playerSpeed = 0;
    
    [SerializeField] private GameObject upgradeUI; // Upgrade UI 추가

    private int maxLevel = 5;
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

    private void RemoveImage(Sprite imageToRemove)
    {
        if (imageToRemove == null) return;
        
        // 기존 이미지를 List로 변환
        List<Sprite> imageList = new List<Sprite>(images);
    
        // 제거할 이미지가 List에 존재하는지 확인
        if (imageList.Remove(imageToRemove))
        {
            // List의 내용을 배열로 변환하여 images에 저장
            images = imageList.ToArray();
        }

    }
    
    private void OnImageClick(Sprite clickedSprite)
    {
        // 클릭된 이미지가 SpeedUp인지 확인
        if (clickedSprite == speedUpSprite)
        {
            // PlayerControl의 인스턴스를 찾아서 속도 증가
            PlayerControl playerControl = FindObjectOfType<PlayerControl>();
            if (playerControl != null)
            {
                playerControl.IncreaseSpeed(increaseSpeedAmount);
                playerSpeed++;

                if (playerSpeed >= maxLevel)
                {
                    RemoveImage(clickedSprite);
                }
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
                damageLevel++;

                if (damageLevel >= maxLevel)
                {
                    RemoveImage(clickedSprite);
                }
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
                speedLevel++;

                if (speedLevel >= maxLevel)
                {
                    RemoveImage(clickedSprite);
                }
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
                if (arrowSpawn.GetArrowLevel() == maxLevel) // shieldLevel이 5일 때
                {
                    RemoveImage(clickedSprite);
                }
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
                if (shieldSpawn.GetShieldLevel() == maxLevel) // shieldLevel이 5일 때
                {
                    RemoveImage(clickedSprite);
                }
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
                if (spearSpawn.GetSpearLevel() == maxLevel) // shieldLevel이 5일 때
                {
                    RemoveImage(clickedSprite);
                }
                upgradeUI.SetActive(false);
                Time.timeScale = 1;
            }
        }
    }
}
