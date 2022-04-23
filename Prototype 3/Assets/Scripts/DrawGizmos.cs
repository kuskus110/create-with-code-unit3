using UnityEngine;

public class DrawGizmos : MonoBehaviour
{
    #region Variables
    public Color color = Color.black;
    #endregion

    void OnDrawGizmos() {
        Gizmos.color = color;
        Gizmos.DrawCube(transform.position, Vector3.one);
    }
}
