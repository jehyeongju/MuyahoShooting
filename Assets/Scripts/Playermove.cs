using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Playermove : MonoBehaviour
{
    [SerializeField]
    private float fireRate = 0.2f;
    [SerializeField]
    private float speed = 5f;
    [SerializeField]
    private Transform bulletPosition = null;
    [SerializeField]
    private GameObject bulletPrefab = null;
    

    private Rigidbody2D rigid = null;
    private Vector2 targetPosition = Vector2.zero;
    private GameManager gameManager = null;
    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        gameManager = FindObjectOfType<GameManager>();
        StartCoroutine(Fire());
    }


    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            targetPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            //igid.MovePosition(targetPosition);
            transform.localPosition = Vector2.MoveTowards(transform.localPosition, targetPosition, speed * Time.deltaTime);
        }
    }
    private IEnumerator Fire()
    {
        while (true)
        {
            GameObject newBullet = Instantiate(bulletPrefab, bulletPosition);
            newBullet.transform.position = bulletPosition.position;
            newBullet.transform.SetParent(null);
            yield return new WaitForSeconds(fireRate);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        gameManager.Dead();
    }
}
