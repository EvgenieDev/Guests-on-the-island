using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class flycamera : MonoBehaviour
{

    // Transforms to act as start and end markers for the journey.
    public Vector3 startMarker;
    public Vector3 endMarker;


    public Quaternion startAngle;
    public Quaternion endAngle;

    // Movement speed in units per second.
    public float speed = 1.0F;

    // Time when the movement started.
    private float startTime;
    public float anglespeed;

    // Total distance between the markers.
    private float journeyLength;

    private float angleLength;

    void Start()
    {
        // Keep a note of the time the movement started.
        startTime = Time.time;

        // Calculate the journey length.
        journeyLength = Vector3.Distance(startMarker, endMarker);
        angleLength = Quaternion.Angle(startAngle, endAngle);
    }

    // Move to the target end position.
    void Update()
    {
        // Distance moved equals elapsed time times speed..
        float distCovered = (Time.time - startTime) * speed;

        // Fraction of journey completed equals current distance divided by total distance.
        float fractionOfJourney = distCovered / journeyLength;

        // Set our position as a fraction of the distance between the markers.
        transform.position = Vector3.Lerp(startMarker, endMarker, fractionOfJourney);

        transform.rotation = Quaternion.Lerp(startAngle, endAngle, distCovered / anglespeed);
    }
}
