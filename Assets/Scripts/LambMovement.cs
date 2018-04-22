using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class LambMovement : MonoBehaviour {
    LevelManager levelManager;
    public static int score = 0;
    public float speed = 0.4f;
    Vector2 dest = Vector2.zero;
    public Text heatlthLabel;
    public Text scoreLabel;

    void Start()
    {
        scoreLabel.text = "" + score;
        dest = transform.position;
    }

    void FixedUpdate()
    {
        // Move closer to Destination
        Vector2 p = Vector2.MoveTowards(transform.position, dest, speed);
        GetComponent<Rigidbody2D>().MovePosition(p);

        // Check for Input if not moving
        if ((Vector2)transform.position == dest)
        {
            if (Input.GetKey(KeyCode.UpArrow) && valid(Vector2.up))
                dest = (Vector2)transform.position + Vector2.up;
            if (Input.GetKey(KeyCode.RightArrow) && valid(Vector2.right))
                dest = (Vector2)transform.position + Vector2.right;
            if (Input.GetKey(KeyCode.DownArrow) && valid(-Vector2.up))
                dest = (Vector2)transform.position - Vector2.up;
            if (Input.GetKey(KeyCode.LeftArrow) && valid(-Vector2.right))
                dest = (Vector2)transform.position - Vector2.right;
        }

        // Animation Parameters
        Vector2 dir = dest - (Vector2)transform.position;
        GetComponent<Animator>().SetFloat("DirX", dir.x);
        GetComponent<Animator>().SetFloat("DirY", dir.y);
    }

    bool valid(Vector2 dir)
    {
        //Valid Position 
        Vector2 pos = transform.position;
        RaycastHit2D hit = Physics2D.Linecast(pos + dir, pos);
        return (hit.collider == GetComponent<Collider2D>());
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.tag == "rayo")
        {
            score += collision.gameObject.GetComponent<Rayo>().points;
            scoreLabel.text = "" + score;
        }
        if (collision.tag == "fantasma")
        {
            if ()
            {

            }
            else
            {

            }

        }
        Destroy(collision.gameObject);

    }
}