using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;


public class JoyStick : MonoBehaviour, IDragHandler, IPointerUpHandler
{
    [HideInInspector]
    public Vector2 originalPos;
    [HideInInspector] public Vector2 mousePos;
    Vector2 normal;
    public float magnitude;
    public float distanceFromCenter;
    [HideInInspector] public float clampedMag;

    public static Vector3 move;
    //public Vector3 M;

    [HideInInspector] public float LocposMagnitude;
    bool pressed;
    [HideInInspector] public float x;
    [HideInInspector] public float y;
    // Start is called before the first frame update
    void Start()
    {
        originalPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (!pressed)
        {
            transform.position = Vector2.Lerp(transform.position, originalPos, Time.deltaTime * 10f);
            if (transform.localPosition.magnitude < 25f)
            {
                transform.position = originalPos;
                move = Vector3.zero;
                pressed = true;
            }
        }
    }


    public void OnDrag(PointerEventData eventData)
    {
        pressed = true;
        mousePos = eventData.position - originalPos;
        normal = mousePos.normalized;
        magnitude = mousePos.magnitude;
        clampedMag = Mathf.InverseLerp(0, distanceFromCenter, magnitude);
        transform.localPosition = normal * clampedMag * distanceFromCenter;
        SetInput();
    }
    void SetInput()
    {
        LocposMagnitude = transform.localPosition.magnitude;
        x = transform.localPosition.x;
        y = transform.localPosition.y;
        if (x > 0)
        {
            move.x = Mathf.InverseLerp(0, distanceFromCenter, x + 2f);
            //M.x = Mathf.InverseLerp(0, distanceFromCenter, x + 2f);
        }
        else if (x < 0)
        {
            move.x = -Mathf.InverseLerp(0, -distanceFromCenter, x - 1.1f);
            //M.x = -Mathf.InverseLerp(0, -distanceFromCenter, x - 1.1f);
        }
        if (y > 0)
        {
            move.z = Mathf.InverseLerp(0, distanceFromCenter, y + 2f);
            //M.z = Mathf.InverseLerp(0, distanceFromCenter, y + 2f);
        }
        else if (y < 0)
        {
            move.z = -Mathf.InverseLerp(0, -distanceFromCenter, y - 2f);
            //M.z = -Mathf.InverseLerp(0, -distanceFromCenter, y - 2f);
        }

    }
    public void OnPointerUp(PointerEventData eventData)
    {

        pressed = false;
    }
}
