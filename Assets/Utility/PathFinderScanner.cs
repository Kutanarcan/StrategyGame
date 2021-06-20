using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathFinderScanner : MonoBehaviour
{
    public static PathFinderScanner Instance { get; private set; }

    void Awake()
    {
        Instance = this;
    }

    public void Scan()
    {
        StartCoroutine(ScanCoroutine());
    }

    IEnumerator ScanCoroutine()
    {
        yield return new WaitForFixedUpdate();
        CustomUtils.ScanPathfinding();
    }
}
