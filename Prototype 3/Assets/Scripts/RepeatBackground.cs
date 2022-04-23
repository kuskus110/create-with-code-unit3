using UnityEngine;

[RequireComponent(typeof(BoxCollider))]
public class RepeatBackground : MonoBehaviour
{
    #region Variables
    float backgroundWidth;
    Vector3 startPos;
    #endregion

    void Awake() {
        backgroundWidth = GetComponent<BoxCollider>().size.x;
        startPos = transform.position;
    }

    void Update() {
        if (transform.position.x <= startPos.x - backgroundWidth / 2) {
            transform.position = startPos;
        }
    }
}
