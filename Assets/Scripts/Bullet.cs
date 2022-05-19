using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float damage = 10;
    public float destroyTime = 100;
    public float speed = 10.0f;
    public Vector3 direction = Vector3.forward;
    float currentTime = 0;

    void Update()
    {
        if (currentTime >= destroyTime) {
            Destroy(gameObject);
            return;
        }

        // Timer
        currentTime += Time.deltaTime;

        // Moving
        transform.Translate(direction * speed * Time.deltaTime);
    }

    private void OnCollisionEnter(Collision other) {
        if (other.gameObject.tag == "Monster") {
            print("Monster");

            Destroy(gameObject);
        }
    }
}
