using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManager : MonoBehaviour{
    MenuManagerDelegate _delegate;
    void Start(){
        _delegate = GameObject.Find("Managers").GetComponent<MenuManagerDelegate>();
    }
    public void PressedStart(){
        _delegate.PressedStart();
    }

}
public interface MenuManagerDelegate{
    void PressedStart();
}
