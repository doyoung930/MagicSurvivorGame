using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldMove : MonoBehaviour
{
    private float rotationSpeed = 300f;
    private float distanceFromPlayer = 5f;
    public Transform player;
    
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
}
