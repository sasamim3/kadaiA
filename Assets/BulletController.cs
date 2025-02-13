using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.Translate(10f * Time.deltaTime, 0, 0);
        if (this.transform.position.x >= 10) Destroy(this.gameObject);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Enemy")
        {
            ScoreController.Score += 100;
            Destroy(other.gameObject);
            Destroy(this.gameObject);
        }

    }
}
