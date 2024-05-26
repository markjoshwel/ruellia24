/*
 * Author: mark joshwel <mark@joshwel.co>
 * Date: 27/05/2024
 * Description: speed boosting collectible class
 */

using System.Collections;
using StarterAssets;
using UnityEngine;

/// <summary>
/// speed boosting collectible class
/// </summary>
public class SpeedBoostingCollectible : CommonCollectible
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
        player.MoveSpeed += BoostAmount;
        player.SprintSpeed += BoostAmount;
        // Debug.Log($"boosted 2 {player.MoveSpeed} & {player.SprintSpeed}!!!");

        yield return new WaitForSeconds(CooldownTime);

        player.MoveSpeed -= BoostAmount;
        player.SprintSpeed -= BoostAmount;
        // Debug.Log($"back @ {player.MoveSpeed} & {player.SprintSpeed}...");
        Destroy(this);
    }
}