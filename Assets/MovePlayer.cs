using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlayer : MonoBehaviour
{
    public float velocidad = 8;


    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector3 movimiento = new Vector3(horizontal, 0.0f, vertical);
        transform.Translate(movimiento * Time.deltaTime * velocidad);

    }
}
