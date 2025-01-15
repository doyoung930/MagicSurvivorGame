using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 10.0f;
    [SerializeField] private float sprintSpeed = 15.0f;
    
    private void Update()
    {
        MovePlayer();
    }

    private void MovePlayer()
    {
        float xThrow = GetHorizontalInput();
        float yThrow = GetVerticalInput();
        
        float currentSpeed = GetCurrentSpeed();

        // Time.deltaTime을 곱하여 프레임 독립적인 이동 보장
        Vector3 offset = new Vector3(xThrow, 0, yThrow) * (Time.deltaTime * currentSpeed);
        Vector3 newPosition = transform.localPosition + offset;

        transform.localPosition = newPosition;
    }

    private float GetHorizontalInput()
    {
        // WASD 키 입력 처리
        float xThrow = 0f;
        if (Input.GetKey(KeyCode.A)) xThrow = -1f; // 왼쪽
        if (Input.GetKey(KeyCode.D)) xThrow = 1f;  // 오른쪽
        return xThrow;
    }

    private float GetVerticalInput()
    {
        // WASD 키 입력 처리
        float yThrow = 0f;
        if (Input.GetKey(KeyCode.W)) yThrow = 1f;   // 위쪽
        if (Input.GetKey(KeyCode.S)) yThrow = -1f;  // 아래쪽
        return yThrow;
    }

    private float GetCurrentSpeed()
    {
        // 현재 속도 반환
        return Input.GetKey(KeyCode.LeftShift) ? sprintSpeed : moveSpeed;
    }
}