using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;

public class PlayerController : MonoBehaviour
{
    private int score = 0;

    public Text scoreText;

    public Text healthText;

    public Text WinOrLoose;

    public Image WinLoseBG;

    public int health = 5;

    [Tooltip("speed of the player")]
    [SerializeField]
    public float speed;

    private Rigidbody rb;

    public void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    public void Update()
    {
        if (health == 0)
        {
            WinLoseBG.color = Color.red;
            WinOrLoose.color = Color.white;
            WinOrLoose.text = "Game Over!";
            WinLoseBG.gameObject.SetActive(true);
            //Debug.Log("Game Over!");
            StartCoroutine(LoadScene(3));
        }

        if (Input.GetKeyDown(KeyCode.Escape)) {
            OnButtonClicked();
        }
    }

    public void FixedUpdate()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        Vector3 movement = new Vector3(horizontalInput, 0f, verticalInput) * speed;
        rb.MovePosition(rb.position + movement * Time.fixedDeltaTime);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Pickup")) 
        {
            score += 1;
            //Debug.Log($"Score: {score}");
            SetScoreText();
            Destroy(other.gameObject);
        }

        else if (other.CompareTag("Trap"))
        {
            health -= 1;
            SetHealthText();
            //Debug.Log($"Health: {health}");
        }

        else if (other.CompareTag("Goal"))
        {
            WinLoseBG.color = Color.green;
            WinOrLoose.color = Color.black;
            WinOrLoose.text = "You Win!";
            WinLoseBG.gameObject.SetActive(true);
            StartCoroutine(LoadScene(3));
            //Debug.Log("You win!");
        }
    }

    void SetScoreText()
    {
        scoreText.text = $"Score: {score}";
    }

    void SetHealthText()
    {
        healthText.text = $"Health: {health}";
    }

    IEnumerator LoadScene(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    void OnButtonClicked()
    {
        SceneManager.LoadScene (sceneName:"menu");
    }
}
