using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DayNight : MonoBehaviour
{
    public int rotationScale = 10;
    public bool isDay;

    void Update()
    {
        transform.Rotate(rotationScale * Time.deltaTime, 0, 0);

        float currentRotationX = transform.eulerAngles.x;
        isDay = currentRotationX > 0 && currentRotationX < 180;
    }
}