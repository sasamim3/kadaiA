using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    [SerializeField] GameObject Enemy;
    int reTime;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("EnemyGenerator",0,2f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void EnemyGenerator()
    {
        Instantiate(Enemy,new Vector3(10f,Random.Range(-5f,5f),0),Quaternion.identity);
    }
}
