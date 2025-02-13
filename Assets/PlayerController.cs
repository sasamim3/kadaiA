using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.SceneManagement;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    [SerializeField] GameObject Bullet;
    public static int Players = 1;
    public ScoreJson scoreJson;
    public Access access;

    // Start is called before the first frame update
    void Start()
    {
        scoreJson = GetComponent<ScoreJson>();
        access = GetComponent<Access>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.A))
        {
            this.transform.Translate(-5f*Time.deltaTime, 0, 0);
        }
        if (Input.GetKey(KeyCode.D))
        {
            this.transform.Translate(5f * Time.deltaTime, 0, 0);
        }
        if (Input.GetKey(KeyCode.W))
        {
            this.transform.Translate(0, 5f * Time.deltaTime, 0);
        }
        if (Input.GetKey(KeyCode.S))
        {
            this.transform.Translate(0, -5f * Time.deltaTime, 0);
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(Bullet, new Vector3(this.transform.position.x, this.transform.position.y, 0f),Quaternion.identity);
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.tag == "Enemy")
        {
            Destroy(other.gameObject);
            if (Players > 0)
            {
                scoreJson.scoreSaved();
                SceneManager.LoadScene("GameOver");
            }
            else
            {
                Players--;
            }
        }
    }
}
