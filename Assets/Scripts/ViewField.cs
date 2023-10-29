using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

public class ViewField : MonoBehaviour
{
    [SerializeField] private Transform _player;
    [SerializeField] private Camera _mainCamera;

    [SerializeField] private float _angularSpeed=180f;

    [SerializeField] private bool _lookToRight = true;
    [SerializeField] private PlayerController _emilia;
    private Vector3 upward = Vector3.forward;
    
    [SerializeField] private float timeAnimationDeath = 4.5f;

    [SerializeField] private Animator animator;

    private bool isDying;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isDying) return;
        Vector3 mousePosition = _mainCamera.ScreenToWorldPoint(Input.mousePosition);
        if (_lookToRight)
        {
            if (mousePosition.x < _player.position.x)
            {
                Vector3 tmp = transform.eulerAngles;
                transform.eulerAngles = new Vector3(tmp.x,tmp.y+180,tmp.z);
                this.upward *= -1;
                _emilia.Flip();
                _lookToRight = false;
                //kill emilia
                animator.SetTrigger("Death");
                isDying = true;
                _emilia.enabled = false;
                StartCoroutine(kill());
                IEnumerator kill()
                {
                    yield return new WaitForSeconds(timeAnimationDeath);
                    _player.gameObject.SetActive(false);
                    _emilia.enabled = true;
                    isDying = false;
                }
            }
        }
        else
        {
            if (mousePosition.x > _player.position.x)
            {
                Vector3 tmp = transform.eulerAngles;
                transform.eulerAngles = new Vector3(tmp.x, tmp.y - 180, tmp.z);
                this.upward *= -1;
                _emilia.Flip();
                _lookToRight = true;
            }
        }

        mousePosition.z = 0;

        Quaternion direction = Quaternion.LookRotation(mousePosition-_player.position, upward);

        transform.rotation = Quaternion.RotateTowards(transform.rotation, direction, _angularSpeed*Time.deltaTime);
    }
}
