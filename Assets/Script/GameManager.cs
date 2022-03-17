using System.Collections;
using System.Collections.Generic;
using Unity.XR.CoreUtils;
using UnityEngine;


public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public Transform PlayerHead;
    public XROrigin xROrigin;
    public Transform startPos;

    public void Awake() {
        instance = this;
    }
}
