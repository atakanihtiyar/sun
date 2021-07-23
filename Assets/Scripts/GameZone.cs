using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameZone : MonoBehaviour
{
    public Camera cam;
    public BoxCollider2D box;

    void Start()
    {
        if (!cam.orthographic)
        {
            Debug.LogError("Camera must be Orthographic.");
            return;
        }
        box = GetComponent<BoxCollider2D>();

        float aspect = (float)Screen.width / Screen.height;
        float orthoSize = cam.orthographicSize;

        float width = 2.0f * orthoSize * aspect;
        float height = 2.0f * cam.orthographicSize;

        box.size = new Vector2(width, height);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        Destroy(collision.gameObject);
    }
}
