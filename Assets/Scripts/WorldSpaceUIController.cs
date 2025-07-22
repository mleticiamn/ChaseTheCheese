using TMPro;
using UnityEngine;

public class WorldSpaceUIController : MonoBehaviour
{
    public Camera targetCamera;
    public Vector3 screenOffset = new Vector3(0.05f, 0.95f, 10f); // (x: left, y: top, z: dist�ncia da c�mera)
    private TextMeshProUGUI tmpText;

    void Start()
    {
        tmpText = GetComponent<TextMeshProUGUI>();
        if (targetCamera == null) targetCamera = Camera.main;
    }

    void LateUpdate()
    {
        // Converte a posi��o normalizada da tela (0-1) para posi��o mundial
        Vector3 worldPos = targetCamera.ViewportToWorldPoint(screenOffset);
        transform.position = worldPos;

        // Mant�m o texto sempre virado para a c�mera (opcional)
        transform.rotation = targetCamera.transform.rotation;
    }
}