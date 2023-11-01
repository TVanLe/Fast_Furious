using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GraphicsSettings : MonoBehaviour
{
     TMPro.TMP_Dropdown dropdown;
    private void Awake()
    {
        dropdown = GetComponent<TMPro.TMP_Dropdown>();
        if (dropdown == null)
        {
            Debug.LogError("Dropdown-TextMeshPro component not found.");
            return;
        }

        int currentQuality = QualitySettings.GetQualityLevel();
        dropdown.value = currentQuality;    
    }

    public void SetQuality(int qualityIndex)
    {
        QualitySettings.SetQualityLevel(qualityIndex);
    }
}
