using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CheaterDetectedEvent : MonoBehaviour
{
    [SerializeField] private GameObject cheaterHub;

    public void OnCheaterDetected()
    {
        cheaterHub.SetActive(true);
    }
}
