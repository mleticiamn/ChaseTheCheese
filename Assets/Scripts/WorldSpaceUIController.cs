using TMPro;
using UnityEngine;

public class WorldSpaceUIController : MonoBehaviour
{
    public Camera targetCamera;
    public Vector3 screenOffset = new Vector3(0.05f, 0.95f, 10f); // (x: left, y: top, z: distância da câmera)
    private TextMeshProUGUI tmpText;

    void Start()
    {
        tmpText = GetComponent<TextMeshProUGUI>();
        if (targetCamera == null) targetCamera = Camera.main;
    }

    void LateUpdate()
    {
        // Converte a posição normalizada da tela (0-1) para posição mundial
        Vector3 worldPos = targetCamera.ViewportToWorldPoint(screenOffset);
        transform.position = worldPos;

        // Mantém o texto sempre virado para a câmera (opcional)
        transform.rotation = targetCamera.transform.rotation;
    }
}