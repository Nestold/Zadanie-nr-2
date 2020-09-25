using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level0Manager : MonoBehaviour
{
    private void Start()
    {
        Globals.instance.CreateCurtain(CurtainType.cin);
    }
}
