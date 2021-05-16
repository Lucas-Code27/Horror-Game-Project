using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLook : MonoBehaviour
{
    CharacterController characterController;
    public float speed = 5f;

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    private void Move()
    {
        float horMove = Input.GetAxis("Horizontal");
        float verMove = Input.GetAxis("Vertical");

        Vector3 moveVec = transform.forward * verMove + transform.right * horMove;
        characterController.Move(speed * Time.deltaTime * moveVec);
    }
}
