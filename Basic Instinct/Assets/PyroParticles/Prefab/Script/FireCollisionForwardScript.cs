using UnityEngine;
using System.Collections;

namespace DigitalRuby.PyroParticles
{
    public interface ICollisionHandler
    {
        void HandleCollision(GameObject obj, Collision c);
    }

    /// <summary>
    /// This script simply allows forwarding collision events for the objects that collide with something. This
    /// allows you to have a generic collision handler and attach a collision forwarder to your child objects.
    /// In addition, you also get access to the game object that is colliding, along with the object being
    /// collided into, which is helpful.
    /// </summary>
    public class FireCollisionForwardScript : MonoBehaviour
    {
        public ICollisionHandler CollisionHandler;

        void Start() {
            CollisionHandler = new CollisionHandler();
        }

        public void OnCollisionEnter(Collision col)
        {
            CollisionHandler.HandleCollision(gameObject, col);
        }
    }

    public class CollisionHandler : ICollisionHandler {
        public void HandleCollision(GameObject obj, Collision c) {
            if (c.collider.CompareTag("Player")) {
                Debug.Log("Got here.");
                CharacterStats playerStats = c.gameObject.GetComponent<CharacterStats>();
                playerStats.takeDamage(20);
            }
        }
    }
}
