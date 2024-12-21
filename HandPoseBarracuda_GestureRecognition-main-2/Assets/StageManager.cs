using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StageManager : Singleton<StageManager>
{
    
    private int curStage = 1;

    public int CuStage
    {
        get { return curStage; }
        set { curStage = value; }
    }
    
    

}
