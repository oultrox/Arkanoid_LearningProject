using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMovement : MonoBehaviour {
    [SerializeField] private float speed= 100;
    private TrailRenderer trail;
    [SerializeField] private LevelManager gameManager;

    private Rigidbody2D rg2D;
	
    // ------ Métodos API ----------------

    // Use this for initialization
	void Start () {
        this.rg2D = this.GetComponent<Rigidbody2D>();
        this.trail = this.GetComponent<TrailRenderer>();
    }

    private void Update()
    {
        //reinicio de la pelotica wip 
        if (this.transform.position.y < -120)
        {
            this.transform.position = new Vector2(0, -85);
            this.rg2D.velocity = new Vector2(0,0);
            StartCoroutine(ReinicioTrail());
            int life = gameManager.GetPlayerLife() - 1;
            gameManager.SetPlayerLife(life);
        }
        else if(rg2D.velocity.y == 0)
        {
            if (Input.GetKeyDown("space"))
            {
                this.rg2D.velocity = Vector2.up * speed;
            }
        }

    }
    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            float x = HitFactor(rg2D.transform.position, col.transform.position, col.collider.bounds.size.x);
            Vector2 dir = new Vector2(x, 1).normalized;


            //aplica la nueva velocidad.
            this.rg2D.velocity = dir * Random.Range(speed, speed + 100);
        }
        else if(col.gameObject.tag == "Brick")
        {
            int score = gameManager.GetPlayerScore() + 10;
            gameManager.SetPlayerScore(score);
        }
        CameraShake.Shake(0.05f, 3f);
    }

    // ------- Métodos custom -----------------

    // Math para la colisión de los jugadores.
    float HitFactor(Vector2 ballPos, Vector2 racketPos, float racketWidth)
    {
        //ASCII racket art:
        // ||  1 <- at the top of the racket
        // || 
        // ||  0 <-  at the middle of the racket
        // || 
        // || -1 <- at the bottonm of the racket.
        return (ballPos.x - racketPos.x) / racketWidth;
    }

    IEnumerator ReinicioTrail()
    {
        //Desactivamos el Trail effect
        trail.enabled = false;
        trail.time = 0;
        yield return new WaitForSeconds(0.5f);
        //Aquí le damos la velocidad.
        //Activamos trail effect
        trail.enabled = true;
        yield return new WaitForSeconds(0.1f);
        trail.time = 0.7f;
    }
}
