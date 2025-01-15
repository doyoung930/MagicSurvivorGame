using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    [SerializeField] float controlSpeed = 10f;
    [SerializeField] float xRange = 10f;
    [SerializeField] float yRange = 6f;

    // Update is called once per frame
    void Update()
    {
        float xThrwow = Input.GetAxis("Horizontal");
        float yThrwow = Input.GetAxis("Vertical");

        float xOffset = xThrwow * Time.deltaTime * controlSpeed;
        float rawXPos = transform.localPosition.x + xOffset;
        //float clampedXPos = Mathf.Clamp(rawXPos, -xRange, xRange);

        float yOffset = yThrwow * Time.deltaTime * controlSpeed;
        float rawYPos = transform.localPosition.z + yOffset;
        //float clampedYPos = Mathf.Clamp(rawYPos, -yRange, yRange);


        transform.localPosition = new Vector3(rawXPos, transform.localPosition.y, rawYPos);
    }
}
