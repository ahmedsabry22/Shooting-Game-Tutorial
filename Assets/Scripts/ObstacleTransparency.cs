using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleTransparency : MonoBehaviour
{
    public float maxPlayerDistance = 20;

    private MeshRenderer meshRenderer;
    private Color materialColor;
    private Transform player;

    private void Awake()
    {
        meshRenderer = GetComponent<MeshRenderer>();
        materialColor = meshRenderer.material.color;

        player = FindObjectOfType<PlayerMovement>().transform;
    }

    private void Update()
    {
        float distance = Vector3.Distance(transform.position, player.position);
        distance = Mathf.Clamp(distance, 0, 20);

        float targetAlpha = distance / maxPlayerDistance;

        meshRenderer.material.color = new Color(materialColor.r, materialColor.g, materialColor.b, targetAlpha);
    }
}