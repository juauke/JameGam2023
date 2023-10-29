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
    public bool grapplinHit = false;
    public Vector3 grapplinTarget;

    public Collider2D grapplinCollider;
    // Start is called before the first frame update
    void Start()
    {
        Vector3 objectif = mainCamera.ScreenToWorldPoint(Input.mousePosition);
        objectif.z = 0;
        _direction = (objectif -transform.position).normalized;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (_currentSize < sizeGrapplin && !grapplinHit)
        {
            Vector3 deltaMove = _direction * (speed * Time.deltaTime);
            transform.position += deltaMove;
            _currentSize += deltaMove.magnitude;
        }
        else if (_currentSize > sizeGrapplin)
        {
            Destroy(gameObject);
        }

    }

    private void OnTriggerStay2D (Collider2D col2D)
    {
        if (!grapplinHit)
        {
            grapplinTarget = transform.position;
            grapplinHit = true;
        }
    }

    public void Destroy()
    {
        Destroy(gameObject);
    }
}
