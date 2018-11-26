using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class Obstacle : MonoBehaviour {

    [SerializeField]
    [Range(1f, 10f)]
    private float speed = 5f;

	private void FixedUpdate()
    {
        Vector2 pos = this.transform.position;
        pos.x -= this.speed * Time.fixedDeltaTime;
        this.transform.position = pos;
    }
}
