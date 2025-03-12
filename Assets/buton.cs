using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class buton : MonoBehaviour
{
    yonetici yonet;
    void Start()
    {
        yonet = GameObject.FindObjectOfType<yonetici>();
    }

   public void SecenekButon()
    {
        yonet.CevapKontrol(gameObject.name);
    }
}
