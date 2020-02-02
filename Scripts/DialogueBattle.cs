﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class DialogueBattle
{
    public string playerName;
    public string NPCName;
    
    [TextArea(3, 10)]
    public string[] sentences;
    


}
