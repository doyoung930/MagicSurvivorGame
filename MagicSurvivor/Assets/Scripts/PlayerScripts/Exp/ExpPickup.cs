using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExpPickup : MonoBehaviour
{
    [SerializeField] private int increaseExp = 1;
    [SerializeField] private float followDistance = 3f; // 플레이어와의 거리
    [SerializeField] private float followSpeed = 20f; // 따라가는 속도
    
    private Transform playerTransform;

    private void Start()
    {
        // 플레이어를 찾아서 Transform 저장
        playerTransform = GameObject.FindGameObjectWithTag("Player")?.transform;
    }

    private void Update()
    {
        if (playerTransform != null)
        {
            float distance = Vector3.Distance(transform.position, playerTransform.position);
            
            // 플레이어와의 거리가 followDistance보다 작으면 따라감
            if (distance < followDistance)
            {
                MoveTowardsPlayer();
            }
        }
    }

    private void MoveTowardsPlayer()
    {
        // 플레이어 방향으로 이동
        Vector3 direction = (playerTransform.position - transform.position).normalized;
        transform.position += direction * followSpeed * Time.deltaTime;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Destroy(this.gameObject);
            
            PlayerExpSystem playerExpSystem = FindObjectOfType<PlayerExpSystem>();

            if (playerExpSystem != null)
            {
                playerExpSystem.IncreaseExp(increaseExp);
            }
        }
    }
}
