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
    public Transform _rope;
    public SpriteRenderer _SpriteRenderer;
    public Transform _player;
    public Collider2D grapplinCollider;

    private float scale;

    // Start is called before the first frame update
    void Start()
    {
        Vector3 objectif = mainCamera.ScreenToWorldPoint(Input.mousePosition);
        objectif.z = 0;
        _direction = (objectif - transform.position).normalized;
        scale = transform.lossyScale.x;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 HandPosition = _player.position + Vector3.up * 0.5f;
        if (_currentSize < sizeGrapplin && !grapplinHit)
        {
            Vector3 deltaMove = _direction * (speed * Time.deltaTime);
            transform.position += deltaMove;
            Vector3 direction = transform.position - HandPosition;
            _currentSize = direction.magnitude;
            _SpriteRenderer.size = new Vector2(_currentSize / scale, 0.06f);
            _rope.position = HandPosition + direction / 2f;
            float angle = Mathf.Atan2(direction.y, direction.x) / Mathf.PI * 180f;
            transform.eulerAngles = Vector3.forward * angle;
        }
        else if (_currentSize > sizeGrapplin)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D col2D)
    {
        if (!grapplinHit)
        {
            grapplinTarget = transform.position;
            grapplinHit = true;
        }
    }

    private void OnTriggerStay2D(Collider2D col2D)
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