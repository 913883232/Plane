using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//创建数据存储预置体
[CreateAssetMenu(fileName = "GameSetting",menuName = "CreateScriptable/GameSetting",order = 1)]
public class GameSetting : ScriptableObject {
    public float musicVolume;
    public float effectVolume;
}
