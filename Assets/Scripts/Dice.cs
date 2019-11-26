using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Dice : MonoBehaviour {

    public DiceDelegate _delegate;
    public bool _isMoving;
    public Rigidbody _rigidbody;
    public Transform _spawnPos;
    public GameObject _rollDisplay;
    public Camera _mainCamera;
    public Text _rollLabel;
    private bool _isFixed;
    public Animator _animator;

    private int _rollValue;
    private float _lastMoving;

    void Update(){
        if(_isMoving && _rigidbody.velocity == Vector3.zero ){
            if(Time.time - _lastMoving > 0.5f){
                Debug.Log("stopped moving");
                StoppedMoving();
            }
        }else{
            _lastMoving = Time.time;
        }
    }
    private void StoppedMoving(){
        _isMoving = false;

        _rollDisplay.transform.position = transform.position + new Vector3(0,12,0);
        _rollDisplay.transform.LookAt(_mainCamera.transform.position);
        _rollDisplay.gameObject.SetActive(true);

        _rollValue = CalcRollValue();
        _rollLabel.text = _rollValue.ToString();
        _delegate.DoneMoving();
    }
    private int CalcRollValue(){
        if(_isFixed){
            return 1;
        }else{
            return Random.Range(1,6);
        }
    }
    public void SetUp(DiceDelegate diceDelegate){
        _delegate = diceDelegate;
    }
    public void Roll(bool isFixed){
        _isFixed = isFixed;
        _lastMoving = Time.time;
        _isMoving = true;
        _rigidbody.useGravity = true;

        float power = Random.Range(9000.0f,12000 );
        float direction = Random.Range(-0.5f,0.5f);
        Vector3 vector = _spawnPos.forward + new Vector3(direction,0,0);

        _rigidbody.AddForce(vector * power);
        _rollDisplay.gameObject.SetActive(false);
    }
    public int GetRoll(){
        return _rollValue;
    }
    public void Reset(){
        transform.localPosition = Vector3.zero;
        _rigidbody.useGravity = false;
        _rollDisplay.SetActive(false);
        _rigidbody.velocity = Vector3.zero;
        _animator.Play("FadeIn");
    }
}
public interface DiceDelegate{
    void DoneMoving();
}
