using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class SoulLampManager : MonoBehaviour
{
    private bool isRepair
    {
        get
        {
            return items[0] && items[1];
        }
    }
    private Light2D light;
    public bool isOn = false;
    private Animator animator;
    public bool[] items;

    private void Start()
    {
        light = transform.GetChild(0).GetComponent<Light2D>();
        animator = GetComponent<Animator>();
        items = new bool[] { false, false };
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.tag.Equals("Item"))
        {
            if (!items[0] && collision.transform.GetComponent<Item>().id == 0)
            {
                Globals.instance.PrintMessage(new string[] { "You pour soul into the lantern." }, "");
                items[0] = true;
                Destroy(collision.gameObject);
            }

            if (!items[1] && collision.transform.GetComponent<Item>().id == 1)
            {
                Globals.instance.PrintMessage(new string[] { "You put Ruby in lantern." }, "");
                items[1] = true;
                Destroy(collision.gameObject);
            }
        }
    }
    public void Use()
    {
        if (isRepair)
            this.isOn = !this.isOn;
        else
            Globals.instance.PrintMessage(
                new string[] {
                    "This lamp seems to be broken...",
                    "I think i can fix this.",
                    "I need Big Ruby and Bottled Soul."
                });
    }
    private void Update()
    {
        if (isRepair)
        {
            animator.SetBool("IsOn", isOn);
            light.gameObject.SetActive(isOn);
        }
    }
}
