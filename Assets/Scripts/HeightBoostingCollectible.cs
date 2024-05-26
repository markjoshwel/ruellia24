/*
 * Author: mark joshwel <mark@joshwel.co>
 * Date: 27/05/2024
 * Description: height boosting collectible class
 */

using System.Collections;
using StarterAssets;
using UnityEngine;

/// <summary>
/// height boosting collectible class
/// </summary>
public class HeightBoostingCollectible : CommonCollectible
{
    private const float CooldownTime = 10f;
    private const float BoostAmount = 5f;

    public override void Collect(GameObject collectorObject)
    {
        StartCoroutine(BoostSpeed(collectorObject.GetComponent<FirstPersonController>()));
        GetComponent<Renderer>().enabled = false;
    }

    private IEnumerator BoostSpeed(FirstPersonController player)
    {
        player.JumpHeight += BoostAmount;
        // Debug.Log($"boosted 2 {player.JumpHeight}!!!");

        yield return new WaitForSeconds(CooldownTime);

        player.JumpHeight -= BoostAmount;
        // Debug.Log($"back @ {player.JumpHeight}...");
        Destroy(this);
    }
}
