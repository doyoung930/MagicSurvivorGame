using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardBoard : MonoBehaviour
{
    
    
    // Start is called before the first frame update
    void Start()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        
        if (player != null)
        {
            
        }
        
        List<int> randomNumbers = PickRandomNumbers(1, 6, 3);
    }

    List<int> PickRandomNumbers(int min, int max, int count)
    {
        HashSet<int> numbers = new HashSet<int>();
        System.Random random = new System.Random();

        while (numbers.Count < count)
        {
            int num = random.Next(min, max + 1); // max는 비포함
            numbers.Add(num);
        }

        return new List<int>(numbers);
    }
}
