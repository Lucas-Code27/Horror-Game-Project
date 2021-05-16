using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    CharacterController characterController;
    public float speed = 5f;
    public float gravity = 9.81f;

    [Header("Camera and rotation")]
    public Transform cameraHolder;
    public float mouseSensitivity = 2f;
    public float upLimit = -50f;
    public float downLimit = 50f;

    [Header("FEAR")]
    public float fear = 0;

    private void Start()
    {
        characterController = GetComponent<CharacterController>();
        
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        Rotate();

        AudioSource audioSource = GetComponent<AudioSource>();
        audioSource.volume = fear / 100f;
        audioSource.pitch = fear / 100f * 1.5f;
    }

    public void Rotate()
    {
        float horRotation = Input.GetAxis("Mouse X");
        float verRotation = Input.GetAxis("Mouse Y");

        transform.Rotate(0, horRotation * mouseSensitivity, 0);
        cameraHolder.Rotate(-verRotation * mouseSensitivity, 0, 0);

        // Calculate camera rotation
        Vector3 currRotation = cameraHolder.localEulerAngles;
        if (currRotation.x > 180)
            currRotation.x -= 360;
        currRotation.x = Mathf.Clamp(currRotation.x, upLimit, downLimit);
        cameraHolder.localRotation = Quaternion.Euler(currRotation);
    }

    private void Move()
    {
        float horMove = Input.GetAxis("Horizontal");
        float verMove = Input.GetAxis("Vertical");

        Vector3 moveVec = transform.forward * verMove + transform.right * horMove;
        moveVec *= speed;

        moveVec.y -= gravity * Time.deltaTime;
        //Debug.LogFormat("moveVec {0}", moveVec);

        characterController.Move(Time.deltaTime * moveVec);
    }
}
