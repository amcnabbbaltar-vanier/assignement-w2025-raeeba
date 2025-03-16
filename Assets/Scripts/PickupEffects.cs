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

    // Start is called before the first frame update
    void Start()
    {
        startPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        Hover();
        Rotate();
    }

    void Hover()
    {
        float newY = Mathf.Sin(Time.time * hoverSpeed) * hoverHeight;
        transform.position = new Vector3(startPosition.x, startPosition.y + newY, startPosition.z);
    }

    void Rotate()
    {
        transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime);
    }

    public void OnCollisionEnter(Collision other)
    {
        
        if (other.gameObject.tag == "Player") 
        {
            collisionEffect.Play();
            Debug.Log("Player collided with pickup!");
        }
    }
}
