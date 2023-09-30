using System;
using System.Collections;
using System.Collections.Generic;
using Core.Tag;
using UnityEngine;

public class CloseStageText : MonoBehaviour
{
    [SerializeField] private GameObject stagePanel;
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag(TagList.Player))
        {
            stagePanel.SetActive(false);
        }
    }
}
