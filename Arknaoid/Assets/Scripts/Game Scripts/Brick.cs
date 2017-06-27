using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brick : MonoBehaviour {
    [SerializeField] private int brickFrame = 0;
    [SerializeField] private List<Sprite> Sprites;
    [SerializeField] private bool creator = false;
    [SerializeField] private float brickCount = 10;

    private new SpriteRenderer renderer;
    // Use this for initialization
    void Start () {
        renderer = this.GetComponent<SpriteRenderer>();
        if (brickFrame < Sprites.Count)
        {
            this.renderer.sprite = Sprites[brickFrame];
        }
        if (this.creator)
        {

            BlockGeneration();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject);
    }

    private void BlockGeneration()
    {

        creator = false;
        for (int i = 0; i < brickCount; i++)
        {
            float posx = this.transform.position.x;
            float posy = this.transform.position.y;
            Instantiate(gameObject, new Vector3(posx + (i * 17), posy, 0), Quaternion.identity);
        }
            
    }
}
