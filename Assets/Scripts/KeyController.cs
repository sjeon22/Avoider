using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KeyController : MonoBehaviour
{
    private Text keyText;

    void Start()
    {
        keyText = GameObject.Find("KeyText").GetComponent<Text>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 9)
        {
            collision.gameObject.GetComponent<PlayerMovement>().hasKey = true;
            Destroy(this.gameObject);
            UpdateScore();
        }
    }
    public void UpdateScore()
    {
        keyText.GetComponent<KeyScoreManager>().score += 1;
        keyText.GetComponent<KeyScoreManager>().UpdateScore();
    }
}
