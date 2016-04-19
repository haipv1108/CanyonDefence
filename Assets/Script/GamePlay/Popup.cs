using UnityEngine;
using System.Collections;

public class Popup : MonoBehaviour {


    public void Open() {
        gameObject.SetActive(true);        
    }

    public void Close() {
        gameObject.SetActive(false);
    }
}
