using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMaker : MonoBehaviour {

    public static PlayerMaker instance;
    public List<GameObject> listPlayers;

    void Awake() {
        instance = this;
    }

}
