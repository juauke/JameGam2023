using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using JetBrains.Annotations;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class StressBar : MonoBehaviour
{
    [SerializeField] private int _maxStress=100;

    [SerializeField] private int _stress=0;
    [SerializeField] private RectTransform _rectTransform;
    [SerializeField] private List<Sprite> touches;
    [SerializeField] private List<char> touchesChars;
    [SerializeField] private Image spriteRenderer;

    private float timeLeftStress = 2f;
    
    [SerializeField] private float reactivite = 5f;

    public void AddStress(int moreStress)
    {
        int newStress = _stress + moreStress;
        if (newStress > _maxStress)
        {
            _stress=_maxStress;
            StartCoroutine(MaxStress());
            IEnumerator MaxStress()
            {
                var dead = false;
                var entier = Random.Range(32, 128);
                if(entier<=90 && entier >=65)
                    entier+=91-65 ;
                if (entier == 96) entier++;
                var key = Convert.ToChar(entier).ToString();
                Debug.Log(key);
                var i = indexOfSprite(Convert.ToChar(entier));
                if (!spriteRenderer.IsUnityNull()) 
                {
                    spriteRenderer.sprite = touches[i] ;
                    Debug.Log(touches[i]);
                    Debug.Log(i);
                }
                else
                {
                    Debug.Log("spriteRenderer is null");
                }
                var _startTime = Time.time;
                while (Input.inputString != key && !dead)
                {
                    if(Input.anyKey)
                        Debug.Log("SSSS "+ key + Input.inputString);
                    if (Time.time - _startTime > reactivite)
                    {
                        dead = true;
                        Debug.Log("you deadge");
                    }
                    yield return null;
                }
                if (!dead)
                {
                    _stress = 0;
                    Debug.Log("you win");
                }
                UpdateBar();
            }
        }
        else
        {
            _stress=newStress;
        }
        UpdateBar();
    }

    private void UpdateBar()
    {
        _rectTransform.anchorMax=new Vector2((float) _stress/(float)_maxStress,1);
    }

    private int indexOfSprite(char a)
    {
        for (var i= 0; i < touchesChars.Count; i++)
        {
            if (touchesChars[i] == a)
            {
                return i;
            }
        }
        return -1;
    }

    void Update()
    {
        timeLeftStress -= Time.deltaTime;
        if (timeLeftStress <= 0)
        {
            if (_stress < 100)
            {
                
                AddStress(50);
            timeLeftStress = Random.Range(1f, 3f);
            }
            else
            {
                AddStress(50);
                timeLeftStress = Random.Range(5f, 10f);
            }
        }
    }
}
