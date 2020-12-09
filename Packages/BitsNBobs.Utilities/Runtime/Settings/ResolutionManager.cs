using System;
using System.Linq;
using UnityEngine;

namespace BitsNBobs.Settings
{
    public class ResolutionManager : MonoBehaviour
    {
        public Vector2Int[] resolutions;
        private int id = 0;

        private void Awake()
        {
            resolutions = Screen.resolutions.Select(x => new Vector2Int(x.width, x.height)).ToArray();
        }

        // private void Update()
        // {
        //     if (Input.GetKeyDown(KeyCode.R))
        //     {
        //         var resolution = resolutions[id];
        //         Debug.Log($"Changing resolution: {resolution}");
        //         Screen.SetResolution(resolution.x, resolution.y, FullScreenMode.Windowed);
        //         id = (id + 1 + resolutions.Length) % resolutions.Length;
        //     }
        // }
    }
}