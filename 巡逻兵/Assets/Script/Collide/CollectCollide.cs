using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CollectCollide : MonoBehaviour
{
    void OnCollisionEnter(Collision other)
    {
        SSDirector director;
        //当玩家与shuijing相撞
        if (other.gameObject.tag == "Player")
        {
            Debug.Log(this.gameObject.GetInstanceID());
            Destroy(this.gameObject);
            director = SSDirector.getInstance();
            int i=director.currentScenceController.GetCollector();
            i = i + 1;
            director.currentScenceController.setCollect(i);

        }

    }
}
