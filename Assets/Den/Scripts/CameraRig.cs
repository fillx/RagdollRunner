using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRig : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private List<Transform> playersList;
    [SerializeField] private Transform cameraTransform;
    
    [SerializeField] private float distanceForTopView;
    [SerializeField] private float maxDistanceCameraY;
    [SerializeField] private float minDistanceCameraY;
    [SerializeField] private float maxDistanceCameraX;
    [SerializeField] private float minDistanceCameraX;
    [SerializeField] private float maxDistanceCameraAngle;
    [SerializeField] private float minDistanceCameraAngle;


    private Vector3 _basePosition;

    private void Start()
    {
        _basePosition = new Vector3(0, transform.position.y, transform.position.z);

        transform.position = _basePosition + Vector3.right * PlayersMinX();
    }

    private void Update()
    {
        var minX = PlayersMinX();
        var maxX = PlayersMaxX();
        var distance = Mathf.Clamp(Mathf.Abs(minX - maxX), 0, distanceForTopView);
        var delta = distance / distanceForTopView;

        var targetViewHeight = Mathf.Lerp(minDistanceCameraY, maxDistanceCameraY, delta);
        var targetViewAngle = Mathf.Lerp(minDistanceCameraAngle, maxDistanceCameraAngle, delta);
        var targetX = Mathf.Lerp(minDistanceCameraX, maxDistanceCameraX, delta);

        transform.position = Vector3.Lerp(
            transform.position, 
            _basePosition + Vector3.right * maxX,
            speed * Time.deltaTime);
        
        cameraTransform.localPosition = Vector3.Lerp(
            cameraTransform.localPosition,
            new Vector3(targetX, targetViewHeight, 8),
            speed * Time.deltaTime
            );
        
        cameraTransform.localRotation = Quaternion.Lerp(
            cameraTransform.localRotation,
            Quaternion.Euler(targetViewAngle, 90, 0),
            speed * Time.deltaTime);
    }

    private float PlayersMinX()
    {
        var minX = Mathf.Infinity;
        foreach (var player in playersList)
        {
            if (player.position.x > minX) continue;
            minX = player.position.x;
        }

        return minX;
    }
    private float PlayersMaxX()
    {
        var maxX = Mathf.NegativeInfinity;
        foreach (var player in playersList)
        {
            if (player.position.x < maxX) continue;
            maxX = player.position.x;
        }

        return maxX;
    }
}
