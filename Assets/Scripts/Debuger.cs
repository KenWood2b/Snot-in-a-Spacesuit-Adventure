using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Debuger : MonoBehaviour
{
    [SerializeField] bool isDebugMod;
    [SerializeField] GameObject localAudioManager;

    private void Awake()
    {
        if (isDebugMod)
        {
            localAudioManager.SetActive(true);
        }
    }
}
