using UnityEngine;

public class Move : MonoBehaviour
{
    #region Variables
    public bool useGameSpeed = true;
    public float speed = 20f;
    public Vector3 direction = Vector3.left;
    #endregion


    void FixedUpdate() {
        speed = useGameSpeed ? GameSpeed.CurrentGameSpeed : speed;
        transform.Translate(direction * (Time.fixedDeltaTime * speed), Space.World);
    }
}
