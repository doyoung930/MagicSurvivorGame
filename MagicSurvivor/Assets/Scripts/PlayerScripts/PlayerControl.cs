using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 10.0f;
    [SerializeField] private float sprintSpeed = 15.0f;
    [SerializeField] private Camera mainCamera;
    private int cameraY = 23;
    private int cameraZ = 11;
    Rigidbody rb;

    private void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
    }
    private void Update()
    {
        MaintainCameraAngle();
    }

    private void FixedUpdate()
    {
        MovePlayer();
    }
    
    private void MovePlayer()
    {
        float xThrow = GetHorizontalInput();
        float yThrow = GetVerticalInput();
        
        float currentSpeed = GetCurrentSpeed();
        
        Vector3 moveDirection = new Vector3(xThrow, 0, yThrow).normalized;

        if (moveDirection.magnitude > 0)
        {
            // y 축만 회전
            Quaternion targetRotation = Quaternion.LookRotation(moveDirection);
            // 기존의 x 및 z 회전을 유지하고 y 회전만 변경
            targetRotation = Quaternion.Euler(0, targetRotation.eulerAngles.y, 0);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * 10f); // 회전 속도 조절

            // 이동
            Vector3 offset = moveDirection * (Time.deltaTime * currentSpeed);
            Vector3 newPosition = transform.localPosition + offset;

            transform.localPosition = newPosition;
            
            // 카메라의 새로운 위치 계산
            Vector3 cameraNewPosition = new Vector3(
                transform.localPosition.x, 
                transform.localPosition.y + cameraY, 
                transform.localPosition.z - cameraZ
            );
            
            mainCamera.transform.localPosition = cameraNewPosition;
        }
    }

    private void MaintainCameraAngle()
    {
        if (mainCamera)
        {
            Vector3 cameraRotation = mainCamera.transform.rotation.eulerAngles;
            cameraRotation.x = 60; // x 각도를 60도로 설정
            mainCamera.transform.rotation = Quaternion.Euler(cameraRotation);
        }
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
    
    // 충돌 이후 처리
    private void OnCollisionExit(Collision collision)
    {
        Debug.Log("hh");
        rb.velocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;
    }
}