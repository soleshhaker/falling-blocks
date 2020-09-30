using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed = 7f;

    public float screenWidth;

    public event System.Action OnPlayerDeath;
    // Start is called before the first frame update
    void Start()
    {
        float playerHalfWidth = transform.localScale.x / 2f;
        screenWidth = Camera.main.aspect * Camera.main.orthographicSize + playerHalfWidth;
    }

    // Update is called once per frame
    void Update()
    {
        float X = Input.GetAxisRaw("Horizontal");
        float velocity = X * speed;
        transform.Translate(Vector3.right * velocity * Time.deltaTime);

        if (transform.position.x < -screenWidth)
        {
            transform.position = new Vector3(screenWidth, transform.position.y, transform.position.z);
        }

        if (transform.position.x > screenWidth)
        {
            transform.position = new Vector3(-screenWidth, transform.position.y, transform.position.z);
        }

      
    }
    void OnCollisionEnter(Collision col)
    {
        if(OnPlayerDeath != null)
        {
            OnPlayerDeath();
        }
        Destroy(gameObject);
    }
}
