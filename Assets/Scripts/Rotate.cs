using UnityEngine;

public class Rotate : MonoBehaviour
{
    public float speed = 30.0f;

    private void Start()
    {
        transform.rotation = Quaternion.Euler(0, 0, Random.Range(0.0f, 360.0f));
    }

    void FixedUpdate()
    {
        transform.rotation = Quaternion.Euler(
            transform.rotation.eulerAngles
            + new Vector3(0, 0, speed * Time.deltaTime));
    }
}
