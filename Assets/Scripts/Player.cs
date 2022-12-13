
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class Player : MonoBehaviour
{
    public SpriteRenderer sr;
    public string currentColor;
    public float jumpForce = 9f;
    public Rigidbody2D rb;
  
   // public Transform obstacle;
    public GameObject obstacle;
    public static int score = 0;
    public Text scoreText;

    public Color colorCyan;
    public Color colorYellow;
    public Color colorMagenta;
    public Color colorPink;

    public void Start()
    {
        SetRandomColor();
    }
    public void Update()
    {
        if(Input.GetButtonDown ("Jump") || Input.GetMouseButtonDown(0))
        {
            rb.velocity = Vector2.up * jumpForce;
        }
       scoreText.text = score.ToString();
    }
   public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Score")
        {
            score++;
            Destroy(collision.gameObject);
            //Instantiate(obstacle, new Vector2(transform.position.x,transform.position.y + 5f), transform.rotation);
            
            return;
        }
        if (collision.tag == "ColorChanger")
        {
           //obstacle.position = new Vector3(obstacle.position.x, obstacle.position.y + 5f, obstacle.position.z);
            SetRandomColor();
            Destroy(collision.gameObject);
            return;
        }
        if (collision.tag != currentColor)
        {
            Debug.Log("Game Over!");
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            score = 0;
        }

    }
    void SetRandomColor()
    {
        int index = Random.Range(0, 4);
        switch (index)
        {
            case 0:
                currentColor = "Cyan";
                sr.color = colorCyan;
                break;
            case 1:
                currentColor = "Yellow";
                 sr.color = colorYellow;
                break;
            case 2:
                currentColor = "Magenta";
                sr.color = colorMagenta;
                break;
            case 3:
                currentColor = "Pink";
                sr.color = colorPink;
                break;
        }
    }

}
