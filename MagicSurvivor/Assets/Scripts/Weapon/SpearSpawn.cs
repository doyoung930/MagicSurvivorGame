using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpearSpawn : MonoBehaviour
{
    public GameObject spearPrefab;
    [SerializeField] private int spearLevel = 1;
    [SerializeField] private int fireInterval = 1;

    void Start()
    {
        // 1초 후부터 fireInterval 간격으로 Fire 메서드 호출
        InvokeRepeating("Fire", fireInterval, fireInterval);
    }

    void Fire()
    {
        // 현재 스크립트가 부착된 게임 오브젝트의 위치로 설정
        Vector3 spawnPosition = transform.position; 
        // 현재 스크립트가 부착된 게임 오브젝트가 바라보는 방향
        Vector3 direction = transform.forward; 
        
        
        
        // 창 소환
        GameObject spear = Instantiate(spearPrefab, spawnPosition, Quaternion.identity);
        //spear.transform.rotation = Quaternion.Euler(90f, 0f, 0f);
        spear.transform.forward = direction; // 창의 방향 설정
        
    }
}