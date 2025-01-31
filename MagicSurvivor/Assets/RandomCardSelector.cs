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
    
    public void Upgrade()
    {
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
}
