using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Player
{
    [CreateAssetMenu(fileName = "PlayerData", menuName = "ScriptableObjects/Player/PlayerData", order = 1)]
    public class PlayerScriptableObject : ScriptableObject
    {
        public PlayerView playerPrefab;
        public PlayerEnum player;
        public int health;
        public float speed;
    }
}
