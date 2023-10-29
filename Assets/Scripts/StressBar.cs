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
    [SerializeField] private float _maxStress = 100f;

    [SerializeField] public float _stress = 0f;
    [SerializeField] private RectTransform _rectTransform;
    [SerializeField] private List<Sprite> touches;
    [SerializeField] private Image spriteRenderer;
    [SerializeField] private ViewField viewField;

    [SerializeField] private Transform player;
    [SerializeField] private Collider2D mort;
    private float timeLeftStress = 2f;

    [SerializeField] private float reactivite = 5f;

    public void AddStress(float moreStress)
    {
        float newStress = _stress + moreStress;
        if (newStress > _maxStress)
        {
            _stress = _maxStress;
            StartCoroutine(MaxStress());

            IEnumerator MaxStress()
            {
                var dead = false;
                var entier = Random.Range(97, 123);
                char keyChar = (char)entier;
                string key = keyChar.ToString();

                spriteRenderer.gameObject.SetActive(true);
                if (!spriteRenderer.IsUnityNull())
                {
                    spriteRenderer.sprite = touches[entier - 97];
                }

                var _startTime = Time.time;
                while (Input.inputString != key && !dead)
                {
                    if (Time.time - _startTime > reactivite)
                    {
                        dead = true;
                        StartCoroutine(viewField.kill());
                    }

                    yield return null;
                }

                spriteRenderer.gameObject.SetActive(false);
                if (!dead)
                {
                    _stress = 0;
                }

                UpdateBar();
            }
        }
        else
        {
            _stress = newStress;
        }

        UpdateBar();
    }

    public void UpdateBar()
    {
        _rectTransform.anchorMax = new Vector2((float)_stress / (float)_maxStress, 1);
    }


    void Update()
    {
        if (player.TryGetComponent<PlayerController>(out PlayerController playerController))
        {
            if (playerController.endGame)
            {
                Destroy(gameObject);
            }
        }

        timeLeftStress -= Time.deltaTime;
        if (timeLeftStress <= 0)
        {
            if (_stress < 100)
            {
                Vector3 closestPoint = mort.ClosestPoint(player.position);
                float distance = Vector3.Distance(closestPoint, player.position);
                AddStress((float)Math.Pow(distance, 2) / 150f);
                timeLeftStress = Random.Range(0.5f, 2f);
            }
        }
    }
}