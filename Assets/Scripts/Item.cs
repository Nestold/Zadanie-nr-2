using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    [HideInInspector]
    public int id;
    [HideInInspector]
    public Sprite sprite;

    public new string name;

    private void Start()
    {
        id = int.Parse(gameObject.name);
        sprite = GetComponent<SpriteRenderer>().sprite;
    }
}
