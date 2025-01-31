using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldMove : MonoBehaviour
{
    private float rotationSpeed = 300f; 
    private float distanceFromPlayer = 5f;
    private float damage = 100f; 
    public Transform player;
    private float increaseDamageAmount = 1f;
    private float increaseSpeedAmount = 60f;
    private float increaseDistance = 1f;
    
    // Start is called before the first frame update
    void Start()
    {
        // 플레이어 오브젝트를 찾습니다. "Player"는 플레이어 오브젝트의 이름입니다.
        player = GameObject.Find("PlayerCapsule").transform;
    }

    // Update is called once per frame
    void Update()
    {
        // 방패의 현재 각도 계산
        float angle = rotationSpeed * Time.deltaTime;

        // 방패의 위치를 플레이어를 중심으로 원운동
        transform.RotateAround(player.position, Vector3.up, angle);

        // 방패가 플레이어로부터 일정 거리를 유지하도록 설정
        Vector3 direction = (transform.position - player.position).normalized;
        transform.position = player.position + direction * distanceFromPlayer;
        
        transform.Rotate(0,rotationSpeed * Time.deltaTime , 0);
    }
    
    void OnTriggerEnter(Collider other)
    {
        Hit(other);
    }

    void Hit(Collider other)
    {
        
        if (other == null) return;
        
        EnemyHealth target = other.GetComponent<EnemyHealth>();

        if (target != null)
        {
            target.TakeDamage(damage);
        }
        
       

    }

    void CreateHitImpact()
    {
        
    }
    
    public void IncreaseDamage()
    {
        damage += increaseDamageAmount;
        
        Debug.Log(damage);
    }

    public void IncreaseSpeed()
    {
        rotationSpeed += increaseSpeedAmount;
    }

    public void IncreaseDistance()
    {
        distanceFromPlayer += increaseDistance;
    }
}
