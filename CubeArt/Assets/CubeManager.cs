using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeManager : MonoBehaviour
{
    public enum Mode
    {
        Start,
        RandomStart,
        InvokeRepeating,
        Coroutine
    }
    public Mode playMode;
}
