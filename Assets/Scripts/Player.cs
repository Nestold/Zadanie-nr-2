using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Player : MonoBehaviour
{
    public GameObject sprite;
    public float speed;

    Vector3 move;
    Rigidbody2D rb;
    Animator animator;
    UIManager uIManager;
    int itemsMaxValue = 4;

    private void Start()
    {
        animator = sprite.GetComponent<Animator>();
        uIManager = GetComponent<UIManager>();
        rb = GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        move = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0);
        if (move.x != 0 || move.y != 0)
        {
            Quaternion rotate = new Quaternion();

            if (move.x > 0)
                rotate.eulerAngles = new Vector3(0, 180, 0);
            else if (move.x < 0)
                rotate.eulerAngles = new Vector3(0, 0, 0);

            sprite.transform.rotation = rotate;

            animator.SetBool("IsMoving", true);
            animator.SetFloat("MoveX", move.x);
            animator.SetFloat("MoveY", move.y);
            rb.velocity = move * speed * Time.deltaTime;
        }
        else
        {
            animator.SetBool("IsMoving", false);
            rb.velocity = Vector3.zero;
        }

        if(Input.GetKeyDown(KeyCode.G) && 
            Globals.instance.game.items.Count > 0 && 
            Globals.instance.game.selectedEqSlot < Globals.instance.game.items.Count)
        {
            var items = Resources.LoadAll<Item>("Prefabs/Items").Where(x => x.id == Globals.instance.game.items[Globals.instance.game.selectedEqSlot].id);
            if(items.Any())
            {
                var newItem = Instantiate(items.First(), transform.position, new Quaternion());
                newItem.gameObject.name = items.First().id.ToString();
            }
            Globals.instance.game.items.RemoveAt(Globals.instance.game.selectedEqSlot);
            uIManager.UpdateItems();
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (collision.tag.Equals("Item") && Globals.instance.game.items.Count < itemsMaxValue)
            {
                Globals.instance.game.items.Add(collision.GetComponent<Item>());
                uIManager.UpdateItems();
                Destroy(collision.gameObject);
            }

            if(collision.tag.Equals("Usable"))
            {
                collision.GetComponent<SoulLampManager>().Use();
            }
        }
    }
}
