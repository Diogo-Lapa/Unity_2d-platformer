using System.Collections;
using System.Collections.Generic;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngineInternal;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public float moveSpeed;
    public Rigidbody2D rig;
    public float jumpForce;
    public SpriteRenderer sr;
    public int score;
    public UI ui;

    void FixedUpdate()
    {
        float xInput = Input.GetAxis("Horizontal");

        rig.velocity = new Vector2(xInput * moveSpeed, rig.velocity.y);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow) && IsGrounded())
        {
            rig.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }

        if (rig.velocity.x > 0)
        {
            sr.flipX = false;
        }
        else if (rig.velocity.x < 0)
        {
            sr.flipX = true;
        }
    }

    bool IsGrounded()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position + new Vector3(0, -0.1f, 0), Vector2.down, 0.2f);
        return hit.collider != null;
    }

    public void GameOver ()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void AddScore(int amount)
    {
        score += amount;
        ui.SetScoreText(score);
    }
}
