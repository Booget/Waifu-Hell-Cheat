using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using UnityEngine;

namespace MonoCheat
{
    public class HentaiKilla : MonoBehaviour
    {

        public static GameObject GameObject { get; private set; }

        public static void Load()
        {
            GameObject = new GameObject();

            GameObject.AddComponent<Cheat>();

            DontDestroyOnLoad(GameObject);
        }

        public static void Unload()
        {
            GameObject.DestroyImmediate(GameObject);
        }
    }
}
