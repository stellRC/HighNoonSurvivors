using UnityEngine;

public class ClockUI : MonoBehaviour
{
    private const float secondsPerGameDay = 60f;
    private const float rotationDegreesPerDay = 360f;
    private const float hoursPerDay = 24f;
    private const float minutesPerHour = 60f;

    private GameManager gameManager;

    private Transform clockHourHandTransform;
    private Transform clockMinuteHandTransform;

    private Transform pivotPoint;

    private float day;
    private float dayNormalized;
    public float hoursNormalized;
    public float minutesNormalized;
    private string hoursString;
    private string minutesString;

    private void Awake()
    {
        gameManager = FindAnyObjectByType<GameManager>();
        pivotPoint = transform.Find("PivotPoint");
        clockHourHandTransform = transform.Find("HourHand");
        clockMinuteHandTransform = transform.Find("MinuteHand");
    }

    private void Update()
    {
        if (!MainNavigation.isPaused || !gameManager.isGameOver)
        {
            day += Time.deltaTime / secondsPerGameDay;
        }

        dayNormalized = day % 1f;

        hoursNormalized = Time.deltaTime % 1f;

        minutesNormalized = day % 1f;

        UpdateClock();
        hoursString = Mathf.Floor(dayNormalized * hoursPerDay).ToString("00");
        minutesString = Mathf
            .Floor(dayNormalized * hoursPerDay % 1f * minutesPerHour)
            .ToString("00");
        Debug.Log(hoursString + ":" + minutesString);
    }

    private void UpdateClock()
    {
        // clockHourHandTransform.RotateAround(
        //     pivotPoint.position,
        //     Vector3.forward,
        //     -dayNormalized * rotationDegreesPerDay
        // );

        // clockMinuteHandTransform.RotateAround(
        //     pivotPoint.position,
        //     Vector3.forward,
        //     -dayNormalized * rotationDegreesPerDay * hoursPerDay
        // );

        clockHourHandTransform.eulerAngles = new Vector3(
            0,
            0,
            -dayNormalized * rotationDegreesPerDay
        );
        clockMinuteHandTransform.eulerAngles = new Vector3(
            0,
            0,
            -dayNormalized * rotationDegreesPerDay * hoursPerDay
        );
    }
}
