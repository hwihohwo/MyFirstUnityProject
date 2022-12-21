using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Managers : MonoBehaviour
{
    static Managers Instance; // 유일성이 보장된다.
    static Managers GetInstance() { Init(); return Instance; } // 유일한 매니저를 가져온다.

    InputManager _input = new InputManager();
    public static InputManager Input { get { Init(); return Instance._input; } }

    // Start is called before the first frame update
    void Start()
    {
        Init();
    }

    // Update is called once per frame
    void Update()
    {
        _input.OnUpdate();
    }

    static void Init()
    {
        if (Instance == null)
        {
            GameObject go = GameObject.Find("@Managers");
            if (go == null)
            {
                go = new GameObject { name = "@Managers" };
                go.AddComponent<Managers>();
            }
            DontDestroyOnLoad(go); //왠만해선 삭제되지 않게.
            Instance = go.GetComponent<Managers>();
        }
    }
}
