using System.Dynamic;
using UnityEngine;

public class RaycastAbanico : MonoBehaviour
{
    [Header("Raycast Settings")]
    public int rayCount = 10;
    public float maxDistance = 10f;
    [Range(0, 180)]
    public float fieldOfView = 60f;

    [Header("Ray Origin Offset")]
    public Vector3 localOffset = Vector3.zero;

    [Header("Layer Mask")]
    public LayerMask hitLayers;

    void Update()
    {
        EmitRaycasts();
    }

    void EmitRaycasts()
    {
        Vector3 origin = transform.TransformPoint(localOffset);
        float halfFOV = fieldOfView / 2f;

        for (int i = 0; i < rayCount; i++)
        {
            float lerpFactor = (float)i / (rayCount - 1);
            float angle = Mathf.Lerp(-halfFOV, halfFOV, lerpFactor);
            Vector3 direction = Quaternion.Euler(0, angle, 0) * transform.forward;

            if (Physics.Raycast(origin, direction, out RaycastHit hit, maxDistance, hitLayers))
            {
                // Acción según etiqueta
                if (hit.collider.CompareTag("Player"))
                {
                    Debug.DrawRay(origin, direction * hit.distance, Color.red);
                }
                else
                {
                    Debug.DrawRay(origin, direction * hit.distance, Color.yellow);
                }
            }
            else
            {
                Debug.DrawRay(origin, direction * maxDistance, Color.blue);
            }
        }
    }

    void OnDrawGizmos()
    {
        if (rayCount < 2) return;

        Vector3 origin = transform.TransformPoint(localOffset);
        float halfFOV = fieldOfView / 2f;

        Gizmos.color = Color.green;
        Gizmos.DrawSphere(origin, 0.1f);

        for (int i = 0; i < rayCount; i++)
        {
            float lerpFactor = (float)i / (rayCount - 1);
            float angle = Mathf.Lerp(-halfFOV, halfFOV, lerpFactor);
            Vector3 direction = Quaternion.Euler(0, angle, 0) * transform.forward;

            // Simula raycast solo para visualización en editor
                if (Physics.Raycast(origin, direction, out RaycastHit hit, maxDistance, hitLayers))
                {
                    Gizmos.color = hit.collider.CompareTag("Player") ? Color.red : Color.yellow;
                    Gizmos.DrawLine(origin, hit.point);
                }
                else
                {
                    Gizmos.color = Color.blue;
                    Gizmos.DrawRay(origin, direction * maxDistance);
                }
        }
    }

    public bool PlayerDetectado()
    {
        Vector3 origin = transform.TransformPoint(localOffset);
        float halfFOV = fieldOfView / 2f;


        int raycastsQueHanDetectadoPlayer = 0;

        for (int i = 0; i < rayCount; i++)
        {
            float lerpFactor = (float)i / (rayCount - 1);
            float angle = Mathf.Lerp(-halfFOV, halfFOV, lerpFactor);
            Vector3 direction = Quaternion.Euler(0, angle, 0) * transform.forward;
            bool resultado = Physics.Raycast(origin, direction, out RaycastHit hit, maxDistance, hitLayers);

            if (resultado && hit.collider.CompareTag("Player"))
            {
                raycastsQueHanDetectadoPlayer++;
            }
        }
        return raycastsQueHanDetectadoPlayer > 0;
    }
}
