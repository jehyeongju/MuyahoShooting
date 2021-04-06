using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private GameObject enemyCroissant;

    private int score = 0;
    private int life = 3;

    void Start()
    {
        StartCoroutine(SpawnCroissant());
    }

    public void AddScore(int addscore)
    {
        score += addscore;
    }

    public int GetLife()
    {
        return life;
    }

    public void Dead()
    {
        life--;
    }
    private IEnumerator SpawnCroissant()
    {
        float randomX = 0f;
        float randomdDelay = 0f;
        
        while (true)
        {
            randomX = Random.Range(-7f, 7f);
            randomdDelay = Random.Range(1f, 5f);
            for(int i = 0; i < 5; i++)
            {
                Instantiate(enemyCroissant, new Vector2(randomX, 20f), Quaternion.identity);
                yield return new WaitForSeconds(0.5f);
            }
            Instantiate(enemyCroissant, new Vector2(randomX, 20f), Quaternion.identity);
            yield return new WaitForSeconds(randomdDelay);
        }

     


    }
}
