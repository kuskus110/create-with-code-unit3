using UnityEngine;
using System.Collections.Generic;
using System.Linq;

public class DestroyCollidingObjects : MonoBehaviour
{
    #region Variables
    [Tooltip("Destroy obejcts only with these gametags. Optional - if empty, destroys every object")] 
    public List<string> gameTagWhitelist;
    [Tooltip("Destroy also this object after a collision")]
    public bool destroySelf = false;
    
    bool whitelistNotEmpty;
    #endregion

    void Awake() {
        whitelistNotEmpty = gameTagWhitelist.Any();
    }

    void OnTriggerEnter(Collider other) {
        if (whitelistNotEmpty && gameTagWhitelist.Contains(other.tag) || !whitelistNotEmpty) {
            Destroy(other.gameObject);
        }
        if (destroySelf) {
            Destroy(gameObject);
        }
    }
}
