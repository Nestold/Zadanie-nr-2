using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCanvasManager : MonoBehaviour
{
    public bool[] input = new bool[4];

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.W))
        {
            input[0] = true;
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            input[1] = true;
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            input[2] = true;
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            input[3] = true;
        }

        if(input[0] && input[1] && input[2] && input[3])
        {
            Destroy(gameObject);
        }
    }
}
