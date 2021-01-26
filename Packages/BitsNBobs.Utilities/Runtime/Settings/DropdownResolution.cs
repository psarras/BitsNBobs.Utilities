using System;
using System.Collections;
using System.Collections.Generic;
using BitsNBobs.Settings;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


namespace DesignReview
{
    [RequireComponent(typeof(TMP_Dropdown))]
    public class DropdownResolution : MonoBehaviour
    {
        private TMP_Dropdown dropdown;

        private Resolution[] resolutions;
        // Start is called before the first frame update
        void Awake()
        {
            dropdown = GetComponent<TMP_Dropdown>();
            resolutions = Screen.resolutions;
            Screen.fullScreen = false;
            Screen.fullScreenMode = FullScreenMode.MaximizedWindow;
        }

        void Start()
        {
            dropdown.options.Clear();

            foreach (var resolution in resolutions)
            {
                dropdown.options.Add(new TMP_Dropdown.OptionData($"{resolution.width} x {resolution.height}, {resolution.refreshRate}Hz"));
            }

            dropdown.onValueChanged.AddListener(ChangeResolution);
        }

        private void ChangeResolution(int index)
        {
            var resolution = resolutions[index];
            Screen.SetResolution(resolution.width, resolution.height, FullScreenMode.MaximizedWindow);
        }
    }
}