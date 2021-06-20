using UnityEngine;
using System.Collections;

public static class CustomUtils
{
    static Camera mainCamera;

    public static Vector3 GetMouseWorldPosition()
    {
        if (mainCamera == null)
            mainCamera = Camera.main;

        Vector3 mouseWorldPosition = mainCamera.ScreenToWorldPoint(Input.mousePosition);
        mouseWorldPosition.z = 0;

        return mouseWorldPosition;
    }

    public static Vector3 GetMouseWorldPositionFixed()
    {
        if (mainCamera == null)
            mainCamera = Camera.main;

        Vector3 mouseWorldPositionFixed = mainCamera.ScreenToWorldPoint(Input.mousePosition);
        mouseWorldPositionFixed.x = Mathf.Round(mouseWorldPositionFixed.x);
        mouseWorldPositionFixed.y = Mathf.Round(mouseWorldPositionFixed.y);

        mouseWorldPositionFixed.z = 0;

        return mouseWorldPositionFixed;
    }

    public static float GetAngleFromVector(Vector3 vector)
    {
        float radians = Mathf.Atan2(vector.y, vector.x);
        float degrees = radians * Mathf.Rad2Deg;

        return degrees;
    }

    public static float GetAngleFromVectorPositive(Vector3 vector)
    {
        float radians = Mathf.Atan2(vector.y, vector.x);
        float degrees = radians * Mathf.Rad2Deg;
        if (degrees < 0) degrees += 360;

        return degrees;
    }

    public static void ScanPathfinding()
    {
        try
        {
            var lastMessageTime = Time.realtimeSinceStartup;
            foreach (var p in AstarPath.active.ScanAsync())
            {
                if (Time.realtimeSinceStartup - lastMessageTime > 0.2f)
                {
                    //UnityEditor.EditorUtility.DisplayProgressBar("Scanning", p.description, p.progress);
                    lastMessageTime = Time.realtimeSinceStartup;
                }
            }
        }
        catch (System.Exception e)
        {
            Debug.LogError("There was an error generating the graphs:\n" + e + "\n\nIf you think this is a bug, please contact me on forum.arongranberg.com (post a new thread)\n");
            throw e;
        }
    }
}

