using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpearMove : MonoBehaviour
{
    private float speed = 20f;
    private float range = 30f;
    private float damage = 100f;
    [SerializeField] private float increaseDamageAmount = 1f;
    [SerializeField] private float increaseSpeedAmount = 5f;

    private float traveledDistance = 0f; // 이동한 거리 저장

    void Update()
    {
        Move();
    }

    void Move()
    {
        float moveAmount = speed * Time.deltaTime; // 이동 거리 계산
        transform.position += transform.forward * moveAmount; // 위치 업데이트

        // 이동한 거리 추가
        traveledDistance += moveAmount;

        // 설정한 범위를 초과했는지 체크
        if (traveledDistance >= range)
        {
            Destroy(gameObject); // 범위를 초과하면 창 파괴
        }
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
    
    public float GetCurrentSpeed()
    {
        return speed; // 현재 속도 반환 메서드 추가
    }
    public void SetSpeed(float newSpeed)
    {
        speed = newSpeed; // 속도 설정 메서드 추가
    }

    public float GetCurrentDamage()
    {
        return damage;
    }

    public void SetDamage(float newDamage)
    {
        damage = newDamage;
    }
    
}