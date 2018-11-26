using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(SpriteRenderer))]
[RequireComponent(typeof(Collider2D))]
public class Player : MonoBehaviour {

    [SerializeField]
    [Range(200f, 500f)]
    private float jumpPower = 300f;

    [SerializeField]
    private Transform upperRight;
    [SerializeField]
    private Transform lowerRight;

    private Rigidbody2D rb;

    private void Awake()
    {
        this.rb = this.GetComponent<Rigidbody2D>();
    }
    
    // Pohyb uzivatela
    private void FixedUpdate()
    {
        if (Input.GetButtonDown("Fire1")) 
            //Vrati true ak hrac dopadol na nieco v Ground layeri, zamedzi skakaniu vo vzduchu
            if (Physics2D.OverlapArea(upperRight.position, lowerRight.position, 1 << (int)Layers.Ground))
                rb.AddForce(Vector2.up * this.jumpPower);
    }

    // Co sa ma spravit ked je hrac zasiahnuty trigger
    // bolo by lepsie spravit to inak ale na takuto jednoduchu hru to asi nemusime riesit
    // nechame to takto co najjednoduchsie
    private void OnTriggerEnter2D(Collider2D other)
    {
        Obstacle o = other.GetComponent<Obstacle>();
        if (o == null)
            return;

        // smrt alebo dostane dmg?
        print("tu");
    }
}
