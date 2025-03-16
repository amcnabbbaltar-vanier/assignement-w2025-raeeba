using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupEffects : MonoBehaviour
{
    public float hoverHeight = 0.5f;   
    public float hoverSpeed = 1.0f;    
    public float rotationSpeed = 50.0f;
    private Vector3 startPosition;
    public ParticleSystem collisionEffect;

    void Start()
    {
        startPosition = transform.position;
    }

    // make game objects hover and rotate
    void Update()
    {
        Hover();
        Rotate();
    }

    // make game object hover
    void Hover()
    {
        float newY = Mathf.Sin(Time.time * hoverSpeed) * hoverHeight;
        transform.position = new Vector3(startPosition.x, startPosition.y + newY, startPosition.z);
    }

    //  make game object rotate
    void Rotate()
    {
        transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime);
    }

    // on collision with player, play particle effects
    public void OnCollisionEnter(Collision other)
    {
        
        if (other.gameObject.tag == "Player") 
        {
            collisionEffect.Play();
            Debug.Log("Player collided with pickup!");
        }
    }
}
