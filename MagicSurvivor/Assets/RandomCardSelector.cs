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
            }
        }
    }
}
