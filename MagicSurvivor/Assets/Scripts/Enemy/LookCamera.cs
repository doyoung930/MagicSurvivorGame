using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookCamera : MonoBehaviour
{
    private Camera mainCamera;

    void Start()
    {
        // 메인 카메라를 찾습니다.
        mainCamera = Camera.main;
    }

    void Update()
    {
        // 카메라를 바라보도록 회전합니다.
        if (mainCamera != null)
        {
            Vector3 direction = mainCamera.transform.position - transform.position; // 카메라 방향 계산
            direction.x = 0;
            //direction.y = 0; // y축 방향은 제외 (수평으로만 바라보도록)
            // 회전 설정
            Quaternion rotation = Quaternion.LookRotation(direction);
            transform.rotation = rotation;
        }
    }
}