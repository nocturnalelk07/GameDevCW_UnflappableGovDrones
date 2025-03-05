using UnityEngine;

public class droneSpriteBehaviour : MonoBehaviour
{
    [SerializeField] private SpriteUpdateBehaviour spriteUpdater;

    private void FixedUpdate()
    {
        spriteUpdater.nextSprite();
    }

}
