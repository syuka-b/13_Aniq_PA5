using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class playerscript : MonoBehaviour
{
    public float speed;
    private float score = 0;
    Rigidbody RB;
    public Text Score;
    private float level;
    // Start is called before the first frame update
    void Start()
    {
        RB = GetComponent<Rigidbody>();

        Scene currentscene = SceneManager.GetActiveScene();
        string scenename = currentscene.name;

        if (scenename == "Game")
        {
            level = 1;
        }
        else if (scenename == "Level 2")
        {
            level = 2;
        }
    }

    // Update is called once per frame
    void Update()
    {
        Score.text = "Score: " + score;
        if(Input.GetKey(KeyCode.UpArrow))
        {
            RB.velocity = transform.forward * speed * Time.deltaTime;
        }
        else if (Input.GetKey(KeyCode.DownArrow))
        {
            RB.velocity = -transform.forward * speed * Time.deltaTime;
        }
        else if(Input.GetKey(KeyCode.RightArrow))
        {
            RB.velocity = transform.right * speed * Time.deltaTime;
        }
        else if(Input.GetKey(KeyCode.LeftArrow))
        {
            RB.velocity = -transform.right * speed * Time.deltaTime;
        }
        else
        {
            RB.velocity = new Vector3(0, 0, 0);
        }

        if (score == 4)
        {
            SceneManager.LoadScene(2);
        }
        else if (level == 2)
        {
            SceneManager.LoadScene(2);
        }
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Coins")
        {
            score++;
            Destroy(collision.gameObject);
        }

        if(collision.gameObject.tag == "Walls")
        {
            SceneManager.LoadScene("GameLose");
        }
    }
}


