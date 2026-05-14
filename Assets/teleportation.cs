using System.Collections;
using UnityEngine;
using UnityEngine.UIElements;

public class teleportation : MonoBehaviour
{
    public teleportation portal;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        portal.gameObject.SetActive(false);
        collision.transform.position = portal.transform.position;
        StartCoroutine(TeleportPlayer(1.0f));
    }

    IEnumerator TeleportPlayer(float timeToTeleport)
    {
        yield return new WaitForSeconds(timeToTeleport);
        portal.gameObject.SetActive(true);
    }
}
