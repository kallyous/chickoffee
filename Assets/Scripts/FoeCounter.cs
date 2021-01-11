using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoeCounter : MonoBehaviour
{
    public Player player;

    // Update is called once per frame
    void Update()
    {
        if (transform.childCount <= 0) 
        {
            print("Todos mortos.");
            player.Win();
            Destroy(gameObject);
        }
    }
}
