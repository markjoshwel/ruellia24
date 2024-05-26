/*
 * Author: mark joshwel <mark@joshwel.co>
 * Date: 15/05/2024
 * Description: common class for collectibles
 */

using UnityEngine;

/// <summary>
/// base collectible class, children to override Collect(GameObject collectorObject)
/// </summary>
public class CommonCollectible : MonoBehaviour
{
    /// <summary>
    /// virtual collect function that is called OnCollisionEnter or OnTriggerEnter
    /// </summary>
    /// <param name="collectorObject">object that is collided with the collectible</param>
    public virtual void Collect(GameObject collectorObject)
    {
    }

    private void OnCollisionEnter(Collision other)
    {
        Debug.Log($"common hit {other.gameObject}");
        Collect(other.gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log($"common hit {other.gameObject}");
        Collect(other.gameObject);
    }
}