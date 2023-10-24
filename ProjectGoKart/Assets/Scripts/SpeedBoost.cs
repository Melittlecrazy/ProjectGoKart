using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedBoost : MonoBehaviour
{
    public float time = .5f, zoom;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player") StartCoroutine(Vroom(other));
    }

    IEnumerator Vroom(Collider player)
    {
        BasicKartMove vroom = player.GetComponent<BasicKartMove>();
        vroom.speed *= zoom;

        yield return new WaitForSeconds(time);
        vroom.speed /= zoom;
    }
}
