using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tracker : MonoBehaviour {

    public float frequency; // the frequency, in seconds, at which points are recorded
    public bool record = true; // if recording should continue

    public Stack<Vector3> pointsOverTime = new Stack<Vector3>(); // these are the points in space recorded over time

    private void Start()
    {
        StartCoroutine("recordPer"); // this starts recordPer sec so that points can be pushed to pointsOverTime
    }

    private void Update()
    {
        Vector3[] points = pointsOverTime.ToArray(); // This parsed the points in pointsOverTime to an array so I can drawlines between them in the viewport

        for(int i = 0; i < points.Length; i++) // itterates over the points so I that I can draw lines between them 
        {
            if(i != 0 && i != points.Length) // skips the first and last to draw i-1 to i
            {
                Debug.DrawLine(points[i-1], points[i]); // draws points i-1 to i
            }
        }

        if (Input.GetKey(KeyCode.Return)) // Return is used to start the time reversal process
        {
            record = false; // record is false so that while reversing time no more points are recorded
            StopAllCoroutines(); // All co-routines are stopped to stop recording

            StartCoroutine("reverse"); // starts co-routines reverse
        }
    }

    IEnumerator reverse()
    {
        GetComponent<characterController>().enabled = false; // stops the character controller so as not to interfere with revering time

        foreach(Vector3 v in pointsOverTime) // itterates through each point in pointsOverTime
        {
            transform.position = v; // the position of the object is made equal to v to travel back in time
            yield return null;
        }

        pointsOverTime = new Stack<Vector3>(); // the stack is cleared

        record = true; 
        GetComponent<characterController>().enabled = true; // control of the character is given back

        StartCoroutine("recordPer"); // recordPer starts again to record positions
    }

    IEnumerator recordPer()
    {
        while(record == true)
        {
            pointsOverTime.Push(transform.position); // the position is pushed to the stack
            yield return new WaitForSeconds(frequency); // freqency amount of seconds is now waited
        }
    }
}
