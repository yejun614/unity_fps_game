using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public Bullet bulletObject;
    bool isFire = false;

    void Update()
    {
        if (!isFire && Input.GetMouseButtonDown(0)) {
            isFire = true;

            print("Fire");
            Fire();

        } else if (Input.GetMouseButtonUp(0)) {
            isFire = false;
        }
    }

    void Fire()
    {
        GameObject.Instantiate<Bullet>(bulletObject, transform.position, transform.rotation);
    }
}
