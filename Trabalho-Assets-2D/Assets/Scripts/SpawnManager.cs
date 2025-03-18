using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{

    public float clock = 0;
    [SerializeField] GameObject[] enemy;
    public Vector2 spawmvermelho;
    public Vector2 spawmazul;


    private void Start()
    {
       
        spawmvermelho = new Vector2(3.47f, -2.65f);
        spawmazul= new Vector2(-4.48f, 0.57f);
    }

    private void Update()
    {
        clock = Time.deltaTime;
        SpawnEnemy();
    }
    public void SpawnEnemy()
    {
        if (clock >= 5)
        {
            Instantiate(enemy[0], spawmvermelho, Quaternion.identity);
            clock = 0f;
        }


    }


}
