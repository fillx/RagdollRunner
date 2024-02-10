using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterTriggerListener : MonoBehaviour
{
    public bool isJump;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Jumper"))
        {
            Debug.Log("JUMPER CONTACT");
            isJump = true;
        }
    }
}
