using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.Serialization;

public class ViewField : MonoBehaviour
{
    [SerializeField] private Transform _player;
    [SerializeField] private Camera _mainCamera;

    [SerializeField] private float _angularSpeed=180f;

    [SerializeField] private bool _lookToRight = true;
    [SerializeField] private PlayerController _emilia;
    private Vector3 upward = Vector3.forward;
    
    [SerializeField] private float timeAnimationDeath = 4.5f;

    [FormerlySerializedAs("animator")] [SerializeField] private Animator animatorPlayer;
    [SerializeField] private Animator animatorEnemy;
    [SerializeField] private Animator SpellAnimator;
    [SerializeField] private GameObject enemy;
    [SerializeField] private GameObject spell;
    public bool isDying;

    // Start is called before the first frame update
    void Start()
    {
        
    }

   
    public IEnumerator kill()
    {
        StartCoroutine(Coup()); 
        IEnumerator Coup()
        {
            enemy.SetActive(true);
            animatorEnemy.SetTrigger("Kill");
            yield return new WaitForSeconds(3f);
            enemy.SetActive(false);
        }
        StartCoroutine(Cast()); 
        IEnumerator Cast()
        {
            yield return new WaitForSeconds(1.5f);
            spell.SetActive(true);
            SpellAnimator.SetTrigger("Kill");
            yield return new WaitForSeconds(1.7f);
            spell.SetActive(false);
        }
        animatorPlayer.SetBool("isDying",true);
        isDying = true;
        _emilia.enabled = false;
        if(_lookToRight) _emilia.Flip();
        yield return new WaitForSeconds(1.7f);
        animatorPlayer.SetTrigger("Death");
        yield return new WaitForSeconds(timeAnimationDeath);
        animatorPlayer.SetBool("isDying",false);
        _emilia.enabled = true;
        isDying = false;
        if(_lookToRight) _emilia.Flip();
        _player.gameObject.SetActive(false);
    }
    // Update is called once per frame
    void Update()
    {
        if (isDying) return;
        if (!_emilia.enabled) _emilia.enabled = true;
        if(enemy.activeSelf) enemy.SetActive(false);
        if(spell.activeSelf) spell.SetActive(false);
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
                StartCoroutine(kill());
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
