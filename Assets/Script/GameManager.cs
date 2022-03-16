using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public Transform PlayerHead;

    public void Awake() {
        instance = this;
        PlayerHead.position.Set(0f, 0f, -8f);
        PlayerHead.rotation.Set(0f, 3.5f, 0f, 0f);
    }
}
