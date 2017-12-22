using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "GameSetting",menuName = "CreateScriptable/GameSetting",order = 1)]
public class GameSetting : ScriptableObject {
    public float musicVolume;
    public float effectVolume;
}
