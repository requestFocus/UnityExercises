using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class RateUs : MonoBehaviour
{
    private const float _duration = 1;
    private float _timeFraction1 = 0;
    private float _timeFraction2 = 0;
    private Vector3 _startPosBg;
    private Vector3 _middlePosBg;
    private Vector3 _endPosBg;
    private Vector3 _startPosText1;
    private Vector3 _middlePosText1;
    private Vector3 _endPosText1;
    private Vector3 _startPosText2;
    private Vector3 _middlePosText2;
    private Vector3 _endPosText2;

    public Button RateUsButton;
    public Button RateLaterButton;

    private bool _isHidden = false;

    private void Start()
    {
        _startPosBg = transform.position;
        _middlePosBg = new Vector3(0, 0, 0);
        _endPosBg = new Vector3(15, 0, 0);

        _startPosText1 = new Vector3(-250, 350, 0);
        _middlePosText1 = new Vector3(450, 350, 0);
        _endPosText1 = new Vector3(1150, 350, 0);

        _startPosText2 = new Vector3(-150, 350, 0);
        _middlePosText2 = new Vector3(550, 350, 0);
        _endPosText2 = new Vector3(1250, 350, 0);

        RateUsButton.onClick.AddListener(GoToStore);
        RateLaterButton.onClick.AddListener(HideNotification);

        _isHidden = true;
    }

    private void Update()
    {
        if (_isHidden)
            RollWindow();
        else
            PostponeRating();
    }

    private void RollWindow()
    {
        transform.position = Vector3.Lerp(_startPosBg, _middlePosBg, _timeFraction1);
        RateUsButton.transform.position = Vector3.Lerp(_startPosText1, _middlePosText1, _timeFraction1);
        RateLaterButton.transform.position = Vector3.Lerp(_startPosText2, _middlePosText2, _timeFraction1);
        _timeFraction1 += (Time.deltaTime / _duration);

        _isHidden = true;
    }

    private void GoToStore()
    {
        Application.OpenURL("http://www.google.com");
        // Application.OpenURL ("market://details?id=" + Application.productName);
    }

    private void PostponeRating()
    {
        transform.position = Vector3.Lerp(_middlePosBg, _endPosBg, _timeFraction2);
        RateUsButton.transform.position = Vector3.Lerp(_middlePosText1, _endPosText1, _timeFraction2);
        RateLaterButton.transform.position = Vector3.Lerp(_middlePosText2, _endPosText2, _timeFraction2);
        _timeFraction2 += (Time.deltaTime / _duration);
    }

    private void HideNotification()
    {
        _isHidden = false;
    }
}