using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdScript : MonoBehaviour
{
    public Rigidbody2D myRigidbody;
    public float flapStrength;
    public LogicScript logic;
    public bool IsAlive = true;
    // Start is called before the first frame update
    void Start()
    {
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
    }

    // Update is called once per frame
    void Update()
    {
        if (IsAlive)
        {
            if (Input.GetKeyDown(KeyCode.Space) == true || Input.GetMouseButtonDown(0))
            {
                myRigidbody.velocity = Vector2.up * flapStrength;
            }
            if (myRigidbody.position.y > 5.5 || myRigidbody.position.y < -5.5)
            {
                GameOverFunction();
            }
        }   
    }
    public void GameOverFunction()
    {
        logic.gameOver();
        IsAlive = false;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        GameOverFunction();
    }
}
