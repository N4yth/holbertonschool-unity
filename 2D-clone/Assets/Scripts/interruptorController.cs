using UnityEngine;

namespace utils
{
    public abstract class InterruptorController : MonoBehaviour
    {
        [SerializeField] protected teleporterHandler door;
        [SerializeField] protected bool used;

        [SerializeField] protected Sprite pressedSprite;
        [SerializeField] protected Sprite defaultSprite;
        [SerializeField] protected SpriteRenderer interruptorSprite;


    }
}