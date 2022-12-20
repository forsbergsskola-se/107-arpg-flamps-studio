using UnityEngine;

public class RotatingBall : MonoBehaviour
{
    public GameObject fireballPrefab;
    public float fireballDistance = 1.0f;
    public float playerRotationSpeed = 180.0f;
    public float fireballPulseSpeed = 1.0f;
    public int numFireballs = 3;

    private GameObject[] fireballs;
    private Vector3[] fireballOrigins;
    // private int currentFireballIndex = 0;
    private float pulseTime = 0.0f;

    void Start()
    {
        fireballs = new GameObject[numFireballs];
        fireballOrigins = new Vector3[numFireballs];

        for (int i = 0; i < numFireballs; i++)
        {
            float angle = 360.0f / numFireballs * i;
            Vector3 fireballPosition = Quaternion.Euler(0, angle, 0) * Vector3.forward * fireballDistance;
            fireballs[i] = Instantiate(fireballPrefab, transform.position + fireballPosition, Quaternion.identity);
            fireballOrigins[i] = fireballPosition;
        }
    }

    void Update()
    {
        pulseTime += Time.deltaTime * fireballPulseSpeed;

        float angle = playerRotationSpeed * Time.deltaTime;
        transform.Rotate(Vector3.up, angle);

        for (int i = 0; i < numFireballs; i++)
        {
            float pulse = Mathf.Sin(pulseTime);
            fireballs[i].transform.position = transform.position + fireballOrigins[i] * (1.0f + pulse);
        }
    }
}