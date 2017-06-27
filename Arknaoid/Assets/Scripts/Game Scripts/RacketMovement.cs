using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RacketMovement : MonoBehaviour {

    private Rigidbody2D rg2D;
    private int speed = 150;

    // -------- Unity API ----------
    //Inicialización.
	void Start ()
    {
        this.rg2D = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void FixedUpdate ()
    {
        //Asignamos los axis horizontales que leen varios tipos de inputs registrados en el editor del juego hacia la variable v.
        float v = Input.GetAxisRaw("Horizontal");
        // Con la velocidad lo trasladamos físicamente.
        this.rg2D.velocity = new Vector2(v, 0) * speed;
	}
}
