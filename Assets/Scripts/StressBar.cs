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
    [SerializeField] private List<char> touchesChars;
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
                var entier = Random.Range(32, 128);
                var i = IndexOfSprite(Convert.ToChar(entier));
                var key = Convert.ToChar(entier).ToString();
                if (entier <= 90 && entier >= 65)
                    entier += 91 - 65;
                if (entier == 96) entier++;
                while (i == 0)
                {
                    entier = Random.Range(32, 128);
                    if (entier <= 90 && entier >= 65)
                        entier += 91 - 65;
                    if (entier == 96) entier++;
                    key = Convert.ToChar(entier).ToString();
                    i = IndexOfSprite(Convert.ToChar(entier));
                }

                spriteRenderer.gameObject.SetActive(true);
                if (!spriteRenderer.IsUnityNull())
                {
                    spriteRenderer.sprite = touches[i];
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

    private void UpdateBar()
    {
        _rectTransform.anchorMax = new Vector2((float)_stress / (float)_maxStress, 1);
    }

    private int IndexOfSprite(char a)
    {
        for (var i = 0; i < touchesChars.Count; i++)
        {
            if (touchesChars[i] == a)
            {
                return i;
            }
        }

        return 0;
    }

    void Update()
    {
        if (player.TryGetComponent<PlayerController>(out PlayerController playerController))
        {
            if (playerController.endGame)
            {
                this.enabled = false;
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