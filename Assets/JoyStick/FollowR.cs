using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowR : MonoBehaviour
{
    public JoyStick joystick;
    Vector3 input;
    public float rotationSpeed = 5f;
    public float moveSpeed = 5f;


    // Update is called once per frame
    public Vector3 face;
    void Update()
    {

        //move(GetInput());
        //Rotation(GetInput());
        Move(JoyStick.move);
        Rotation(JoyStick.move);
    }
    void Move(Vector3 move)
    {
        transform.position += transform.forward * moveSpeed * Time.deltaTime * move.magnitude;
    }
    void Rotation(Vector3 _rotate)
    {
        if (_rotate.magnitude > 0)
        {
            Quaternion from = transform.rotation;
            Quaternion to = Quaternion.LookRotation(_rotate);
            transform.rotation = Quaternion.Lerp(from, to, rotationSpeed * Time.deltaTime);
        }

    }

    Vector3 GetInput()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        //return input = new Vector3(JoyStick.move.x, 0, JoyStick.move.y);
        return new Vector3(h, 0, v);
    }
}
