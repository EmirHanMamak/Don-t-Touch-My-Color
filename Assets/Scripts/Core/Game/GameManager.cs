using System;
using System.Collections;
using System.Collections.Generic;
using Core;
using Core.Tag;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag(TagList.Player) && this.gameObject.CompareTag(TagList.FinishLine))
        {
            Variables.GameCondition = Variables.GC_NEXTLEVEL;
            Variables.firstTouch = 0;
        }
    }
}
