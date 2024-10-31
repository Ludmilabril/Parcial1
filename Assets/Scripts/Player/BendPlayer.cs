using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BendPlayer : MonoBehaviour
{
    public bool bend;
    public float smoothBend;

    private void Update()
    {
        bend= Input.GetKey(KeyCode.LeftControl);
        float ejeY = this.transform.localScale.y;
        if (bend == true)
        {
            this.transform.localScale = new Vector3(3.328193f, 2.328193f, 3.328193f);
        }
        else { this.transform.localScale = new Vector3(3.328193f, 3.328193f, 3.328193f); }

    }
}
