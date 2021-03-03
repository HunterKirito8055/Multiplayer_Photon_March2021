using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody rigidbody;
    public float speed = 5f;
    public float rotateSpeed = 15f;

    public bool MblInputs = false;
    private void Awake()
    {
        rigidbody = GetComponent<Rigidbody>();
    }
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        MovePlayer();
    }
    void MovePlayer()
    {
        MoveDirection(GetInputs());
        RotateDirection(GetInputs());
    }
    public Vector3 move;
    void MoveDirection(Vector3 vec)
    {
        move = transform.localPosition;
        
        move += transform.forward * vec.magnitude * Time.deltaTime * speed;
        //move = transform.TransformDirection(move);
        rigidbody.MovePosition(move);
    }
    void RotateDirection(Vector3 _towards)
    {
        if (_towards.magnitude > 0)
        {
            //Quaternion from = transform.rotation;
            //Quaternion to = Quaternion.LookRotation(_towards);
            //rigidbody.rotation = Quaternion.Lerp(from, to, rotateSpeed * Time.deltaTime);
            transform.Rotate(0, _towards.x * rotateSpeed * Time.deltaTime, 0);
        }
    }
    Vector3 GetInputs()
    {
        float h, v;
        if (MblInputs)
        {
            h = JoyStick.move.x;
            v = JoyStick.move.z;
        }
        else
        {
            h = Input.GetAxis("Horizontal");
            v = Input.GetAxis("Vertical");
        }

        return new Vector3(h, 0, v);
    }
}
