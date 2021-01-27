using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
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

        private HashSet<(int, int)> resolutionUnique;
        // Start is called before the first frame update
        void Awake()
        {
            resolutionUnique = new HashSet<(int, int)>();
            dropdown = GetComponent<TMP_Dropdown>();
            resolutions = Screen.resolutions;
            //Screen.fullScreen = false;
            //Screen.fullScreenMode = FullScreenMode.MaximizedWindow;
        }

        void Start()
        {
            dropdown.options.Clear();
            
            resolutions.ToList().ForEach(x => resolutionUnique.Add((x.width, x.height)));
            foreach (var resolution in resolutionUnique)
            {
                dropdown.options.Add(new TMP_Dropdown.OptionData($"{resolution.Item1} x {resolution.Item2}"));
            }

            dropdown.onValueChanged.AddListener(ChangeResolution);
        }

        private void ChangeResolution(int index)
        {
            var resolution = resolutionUnique.ToList()[index];
            Screen.SetResolution(resolution.Item1, resolution.Item2, FullScreenMode.Windowed);
        }
    }
}