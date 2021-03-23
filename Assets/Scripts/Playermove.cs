using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Playermove : MonoBehaviour
{
    [SerializeField]
    private float speed = 5f;

    private Rigidbody2D rigid = null;
    private Vector2 targetPosition = Vector2.zero;
    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
    }


    void Update()
    {
        if (Input.GetMouseButton(0)) { 
            targetPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            //igid.MovePosition(targetPosition);
            transform.localPosition = Vector2.MoveTowards(transform.localPosition, targetPosition, speed * Time.deltaTime);
        }
    }
}
