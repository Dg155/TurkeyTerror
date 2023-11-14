using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private AudioSource source;
    private Rigidbody2D rb;
    private Health healthScript;
    private bool isDashing = false;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        healthScript = GetComponent<Health>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 movementDir = new Vector2(0, 0);
        if (Input.GetKey(KeyCode.W))
        {
            movementDir += new Vector2(0, 1);
        }
        if (Input.GetKey(KeyCode.A))
        {
            movementDir += new Vector2(-1, 0);
        }
        if (Input.GetKey(KeyCode.S))
        {
            movementDir += new Vector2(0, -1);
        }
        if (Input.GetKey(KeyCode.D))
        {
            movementDir += new Vector2(1, 0);
        }
        rb.velocity = movementDir.normalized * 6;

        // Check for left mouse button click
        if (Input.GetMouseButtonDown(0) && !isDashing)
        {
            // Start the dash coroutine with the mouse position as the target
            Vector3 targetPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Dash(targetPosition);
        }

    }

    void Dash(Vector3 targetPosition)
    {
        isDashing = true;

        Vector3 startPos = transform.position;

        Vector3 dashDirection = (targetPosition - startPos).normalized;

        // Change the multiplied value to a "dash speed" variable
        Vector3 endPos = startPos + dashDirection * 6;

        transform.position = endPos;

        isDashing = false;
    }

    public IEnumerator lose()
    {
        source.Play();
        Time.timeScale = 0;
        yield return new WaitForSecondsRealtime(1f);
        SceneManager.LoadSceneAsync("LoseScene");
    }
}
