using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class LambMovement : MonoBehaviour {
    static LevelManager levelManager;
    public static int score = 0;
    public static int health = 100;
    public float speed = 0.2f;
    GameObject maze;
    public Text healthLabel;
    public Text scoreLabel;
    static int mazeit;

    void Start()
    {
        

        Debug.Log("maze it"+Maze.iteration);
        levelManager =  new LevelManager();
        healthLabel.text = ""+health;
        scoreLabel.text = "" + score;
        maze = GameObject.Find("maze");
    }

    void FixedUpdate()
    {
        healthLabel.text = ""+health;
        scoreLabel.text = "" + score;

        if(health <= 0)
        {
            healthLabel.text = "0";
            health = 100;
            levelManager.LoadLevel("End");
        }
        /* Move closer to Destination
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

        
        */
         
         if (Input.GetKey(KeyCode.LeftArrow))
         {
            resetTriggers();
            GetComponent<Animator>().SetTrigger("left");
             transform.position += Vector3.left * speed ;
            
            
         }
         if (Input.GetKey(KeyCode.RightArrow))
         {
            resetTriggers();
            GetComponent<Animator>().SetTrigger("right");
             transform.position += Vector3.right * speed;
            
            
         }
         if (Input.GetKey(KeyCode.UpArrow))
         {
            resetTriggers();
            GetComponent<Animator>().SetTrigger("up");
             transform.position += Vector3.up * speed ;
            
         }
         if (Input.GetKey(KeyCode.DownArrow))
         {
            resetTriggers();
            GetComponent<Animator>().SetTrigger("down");
             transform.position += Vector3.down * speed ;
            
         }
        
    }


    public void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.tag == "rayo")
        {
            score += collision.gameObject.GetComponent<Rayo>().points;
            scoreLabel.text = "" + score;
            maze.GetComponent<Maze>().rays--;
        }
        if (collision.tag == "fantasma")
        {
            mazeit = Maze.iteration;
            Debug.Log("maze it: "+mazeit);
            Maze.iteration = 0;
             Debug.Log("maze it: "+mazeit);
            levelManager.loadQuestion();
 
        }
        Destroy(collision.gameObject);

    }

    public void resetTriggers (){
            GetComponent<Animator>().ResetTrigger("down");
            GetComponent<Animator>().ResetTrigger("left");
            GetComponent<Animator>().ResetTrigger("up");
            GetComponent<Animator>().ResetTrigger("right");
        }
    public void answerQuestion(int a){
        if(a==1){
            score=score*2;
            scoreLabel.text = "" + score;
        }else{
            health-=50;
            healthLabel.text = ""+health;
        }
        Invoke("returnIteration", 2);
    }
    public void returnIteration(){
        Maze.iteration = mazeit; 
        Debug.Log(""+Maze.iteration);
    }
}