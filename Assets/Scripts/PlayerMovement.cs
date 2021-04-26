using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController2D controller;
    public Animator animator;
    public bool hasKey;

    public float speed = 1.0f;
    private Rigidbody2D rb;

    private float threshhold = 0.25f;
    private float dashCurrent = 0.0f;
    private float dashDuration = 1.5f;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        StartCoroutine("Move");
        animator.SetFloat("Speed", Mathf.Abs(speed));
    }

    IEnumerator Move()
    {
        Vector3 mouseInSpace = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        // On mouse click, change velocity / direction of the target
        if (Input.GetMouseButtonDown(0))
        {
            float duration = 0;
            bool doubleClicked = false;

            Vector2 velocity = new Vector2(
                (transform.position.x - mouseInSpace.x) * speed,
                (transform.position.y - mouseInSpace.y) * speed);
            rb.velocity = -velocity;

            while (duration < threshhold)
            {
                duration += Time.deltaTime;
                yield return new WaitForSeconds(0.005f);
                if (Input.GetMouseButtonDown(0))
                {
                    doubleClicked = true;
                    duration = threshhold;
                }
            }

            if (doubleClicked && dashCurrent < dashDuration)
            {
                dashCurrent += Time.deltaTime;
                speed = 2.0f;
            }
            else
            {
                dashCurrent = 0f;
                speed = 1.0f;
            }
        }
    }
}
