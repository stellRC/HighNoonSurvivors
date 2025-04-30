using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ClockUI : MonoBehaviour
{
    private const float secondsPerGameDay = 60f;

    private Transform clockHourHandTransform;
    private Transform clockMinuteHandTransform;

    private Transform pivotPoint;

    private float day;
    private float hoursNormalized;
    private float minutesNormalized;

    public TMP_Text finalTime;

    private void Awake()
    {
        pivotPoint = transform.Find("PivotPoint");
        clockHourHandTransform = transform.Find("HourHand");
        clockMinuteHandTransform = transform.Find("MinuteHand");
    }

    private void Update()
    {
        if (!MainNavigation.isPaused)
        {
            day += Time.deltaTime / secondsPerGameDay;
        }

        hoursNormalized = Time.deltaTime % 1f;

        minutesNormalized = day % 1f;

        UpdateClock();
        UpdateFinalTime();
    }

    private void UpdateFinalTime()
    {
        // finalTime = TextMeshPro.SetText("{0} : {1}", hoursNormalized, minutesNormalized);
    }

    private void UpdateClock()
    {
        clockHourHandTransform.RotateAround(pivotPoint.position, Vector3.forward, -hoursNormalized);

        clockMinuteHandTransform.RotateAround(
            pivotPoint.position,
            Vector3.forward,
            -minutesNormalized
        );
    }
}
