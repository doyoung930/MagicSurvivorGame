using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerExpSystem : MonoBehaviour
{

    private int exp = 0;
    private int expMax = 0;
    
    private int level = 0;
    private int levelMax = 0;

    
    
    // Start is called before the first frame update
    void Start()
    {
        LevelUp();
    }

    // Update is called once per frame
    void Update()
    {
        
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
        
        // Upgrade UI 보이도록
        
        // 
    }
}
