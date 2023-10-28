using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrapplinHook : MonoBehaviour
{
    [SerializeField] private Camera mainCamera;
    [SerializeField] private float sizeGrapplin = 10;
    [SerializeField] private float speed = 20;
    private float _currentSize = 0;
    private Vector3 _direction;
    private CharacterController _characterController;
    public bool grapplinHit = false;
    public Vector3 grapplinTarget;
    // Start is called before the first frame update
    void Start()
    {
        Vector3 objectif = mainCamera.ScreenToWorldPoint(Input.mousePosition);
        objectif.z = 0;
        _direction = transform.position - objectif;
        
        _characterController = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (_currentSize < sizeGrapplin && !grapplinHit)
        {
            Vector3 deltaMove = _direction * (speed * Time.deltaTime);
            _characterController.Move(deltaMove);
            _currentSize += deltaMove.magnitude;
        }
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        grapplinTarget = collision.transform.position;
        grapplinHit = true;
    }
}
