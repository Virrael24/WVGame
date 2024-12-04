using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HPTriggerChanger : MonoBehaviour
{
    public HPController Controller;
    public int HP;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            Controller.ChangeHp(HP);
        }
    }
}
