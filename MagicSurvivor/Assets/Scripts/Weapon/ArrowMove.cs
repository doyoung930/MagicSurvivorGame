using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowMove : MonoBehaviour
{
    [SerializeField] private float speed = 20f;
    [SerializeField] private float range = 30f;
    [SerializeField] private int damage = 10;

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
}
