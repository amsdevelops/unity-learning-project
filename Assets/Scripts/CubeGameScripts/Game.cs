using System.Collections.Generic;
using UnityEngine;

namespace CubeGameScripts
{
    public class Game : MonoBehaviour
    {
        private List<GameObject> cubesList;
        private void Start()
        {
            var player = new GameObject("player");
            player.AddComponent<Player>();
            cubesList.Add(player);
        }
    }
}