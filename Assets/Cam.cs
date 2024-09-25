using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cam : MonoBehaviour
{
    public Vector2 sencibilidad;
    private Transform camara;
    void Start()
    {
        camara = transform.Find("Main Camera");
        
    }

    void Update()
    {
        float rotacion_camx = Input.GetAxis("Mouse X");
        float rotacion_camy = Input.GetAxis("Mouse Y");

        if (rotacion_camx != 0)
        {
            transform.Rotate(Vector3.up * rotacion_camx * sencibilidad.x);
        }

        if (rotacion_camy != 0)
        {

            float angulo = (camara.localEulerAngles.x - rotacion_camy * sencibilidad.y + 360) % 360;
            if (angulo > 180)
            {
                angulo -= 360;
            }
            angulo = Mathf.Clamp(angulo, -70, 80);

            camara.localEulerAngles = Vector3.right * angulo;
        }

    }
}
