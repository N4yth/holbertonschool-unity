using UnityEngine;

namespace utils
{
    public class InterruptorHold : InterruptorController
    {
        private int objectsOnPlate = 0;
        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.CompareTag("Player") || collision.CompareTag("Object"))
            {
                objectsOnPlate++;

                if (objectsOnPlate == 1)
                {
                    interruptorSprite.sprite = pressedSprite;
                    door.ActivateSwitch();
                }
            }
        }

        private void OnTriggerExit2D(Collider2D collision)
        {
            if (collision.CompareTag("Player") || collision.CompareTag("Object"))
            {
                objectsOnPlate--;

                if (objectsOnPlate <= 0)
                {
                    objectsOnPlate = 0;
                    interruptorSprite.sprite = defaultSprite;
                    door.DeactivateSwitch();
                }
            }
        }
    }
}