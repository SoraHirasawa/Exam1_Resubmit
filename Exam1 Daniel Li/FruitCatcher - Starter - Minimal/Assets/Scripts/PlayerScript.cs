using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class PlayerScript : NetworkBehaviour
{
	Rigidbody2D rbody;
    ManagerScript _manager;

    [SyncVar(hook = nameof(updateScore))]
    public int _score = 0;

    // Start is called before the first frame update
    void Start()
    {
        rbody = GetComponent<Rigidbody2D>();
        _manager = FindObjectOfType<ManagerScript>();
        /*if (!isClientOnly)
        {
            transform.position = new Vector2(-3, -3);
        }
        else
        {
            transform.position = new Vector2(3, -3);
        }*/
    }

    // Update is called once per frame
    void Update()
    {
        if (!isLocalPlayer)
        {
            GetComponent<SpriteRenderer>().color = Color.magenta;
        }
    }

	private void FixedUpdate()
	{
        if (!isLocalPlayer)
        {
            return;
        }
		rbody.velocity = new Vector2(4 * Input.GetAxis("Horizontal"), 0);
	}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Fruit"))
        {
            _score++;
        }
    }

    void updateScore(int oldScore, int newScore)
    {
        _manager.updateScore(isServer, _score);
    }
}
