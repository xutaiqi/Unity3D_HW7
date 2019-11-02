using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Interfaces;
using UnityEngine.UI;

public class InterfaceGUI : MonoBehaviour {
    UserAction UserActionController;
    ISceneController SceneController;
    CCActionManager CCManger;
   // public int collector=0;
    public GameObject t;
    bool ss = false;
    bool win = false ;
    float S;
    PropFactory PF;
    // Use this for initialization
    void Start () {
        UserActionController = SSDirector.getInstance().currentScenceController as UserAction;
        SceneController = SSDirector.getInstance().currentScenceController as ISceneController;
        S = Time.time;
    }

    private void OnGUI()
    {
        if(!ss) S = Time.time;
        GUI.Label(new Rect(0, 30, 75, 30), "Crystal: " + SceneController.GetCollector().ToString());
        GUI.Label(new Rect(Screen.width-160, 30, 150, 30),"Score: " + UserActionController.GetScore().ToString() + "  Time:  " + ((int)(Time.time - S)).ToString());
        if (ss)
        {
            if (!UserActionController.GetGameState())
            {
                ss = false;
            }if (SceneController.GetCollector() >= 9)
            {
                win = true;
                ss = false;
            }
        }
        else
        {
            if(win){
                GUIStyle fontStyle = new GUIStyle();
                fontStyle.alignment = TextAnchor.MiddleCenter;
                fontStyle.fontSize = 25;
                fontStyle.normal.textColor = Color.white;
                GUI.Label(new Rect(Screen.width / 2 - 25, Screen.height / 2 - 80, 100, 50), "WINNER!",fontStyle);
                PF = PropFactory.PF;
                PF.StopPatrol();

                if (GUI.Button(new Rect(Screen.width / 2 - 30, Screen.height / 2 - 30, 100, 50), "EXIT")){
                    UnityEditor.EditorApplication.isPlaying = false;
                }
            }

            else if (GUI.Button(new Rect(Screen.width / 2 - 30, Screen.height / 2 - 30, 100, 50), "Start"))
            {
                ss = true;
                SceneController.LoadResources();
                S = Time.time;
                UserActionController.Restart();
            }
        }
    }

    private void Update()
    {
        //获取方向键的偏移量
        float translationX = Input.GetAxis("Horizontal");
        float translationZ = Input.GetAxis("Vertical");
        //移动玩家
        UserActionController.MovePlayer(translationX, translationZ);
    }
}
