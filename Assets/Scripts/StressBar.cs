using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

public class StressBar : MonoBehaviour
{
    [SerializeField] private int _maxStress=100;

    [SerializeField] private int _stress=0;
    [SerializeField] private RectTransform _rectTransform;

    private float timeLeftStress = 2f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame

    public void AddStress(int moreStress)
    {
        int newStress = _stress + moreStress;
        if (newStress > _maxStress)
        {
            _stress=_maxStress;
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

    void Update()
    {
        timeLeftStress -= Time.deltaTime;
        if (timeLeftStress <= 0)
        {
            AddStress(1);
            timeLeftStress = Random.Range(1f, 3f);
        }
    }
}
