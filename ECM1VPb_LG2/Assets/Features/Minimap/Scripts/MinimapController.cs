using UnityEngine;
using UnityEngine.UI;

public class MinimapController : MonoBehaviour
{
    [Header("UI Elements")][Space(10)]
    public RectTransform MinimapRect;
    public RectTransform Player1Dot;
    public RectTransform Player2Dot;

    [Header("World References")][Space(10)]
    public Transform StartPoint;
    public Transform EndPoint;
    public Transform Player1;
    public Transform Player2;

    private float Player1X;
    private float Player2X;

    void Start()
    {
        Player1X = Player1Dot.anchoredPosition.x;
        Player2X = Player2Dot.anchoredPosition.x;
    }

    void Update()
    {
        UpdateDot(Player1, Player1Dot, Player1X);
        UpdateDot(Player2, Player2Dot, Player2X);
    }

    void UpdateDot(Transform player, RectTransform dot, float xOffset)
    {
        Vector3 raceDirection = EndPoint.position - StartPoint.position;
        Vector3 playerOffset = player.position - StartPoint.position;

        float progress = Vector3.Dot(playerOffset, raceDirection.normalized) / raceDirection.magnitude;
        progress = Mathf.Clamp01(progress);

        float y = (progress - 0.5f) * MinimapRect.rect.height;

        dot.anchoredPosition = new Vector2(xOffset, y);
    }
}
