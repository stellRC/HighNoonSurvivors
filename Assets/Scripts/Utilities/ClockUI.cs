using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClockUI : MonoBehaviour
{
    private const float secondsPerGameDay = 60f;

    private Transform clockHourHandTransform;
    private Transform clockMinuteHandTransform;

    private Transform pivotPoint;

    private float day;

    private void Awake()
    {
        pivotPoint = transform.Find("PivotPoint");
        clockHourHandTransform = transform.Find("HourHand");
        clockMinuteHandTransform = transform.Find("MinuteHand");
    }

    private void Update()
    {
        day += Time.deltaTime / secondsPerGameDay;

        float hoursNormalized = Time.deltaTime % 1f;

        float minutesNormalized = day % 1f;

        clockHourHandTransform.RotateAround(pivotPoint.position, Vector3.forward, -hoursNormalized);

        clockMinuteHandTransform.RotateAround(
            pivotPoint.position,
            Vector3.forward,
            -minutesNormalized
        );
    }
}
