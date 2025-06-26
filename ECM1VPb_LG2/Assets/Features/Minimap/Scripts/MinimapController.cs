using System;
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

    public Axis Axis;

    private float Player1X;
    private float Player2X;

    void Start()
    {
        Player1X = Player1Dot.anchoredPosition.x;
        Player2X = Player2Dot.anchoredPosition.x;
    }

    void Update()
    {
        switch (Axis)
        {
            case Axis.x:
                UpdateDot(Player1, Player1Dot,  Player1Dot.anchoredPosition.y);
                UpdateDot(Player2, Player2Dot, Player2Dot.anchoredPosition.y);
                break;
            case Axis.y:
                UpdateDot(Player1, Player1Dot,  Player1Dot.anchoredPosition.x);
                UpdateDot(Player2, Player2Dot, Player2Dot.anchoredPosition.x);
                break;
            case Axis.z:
                Debug.LogError("Not supported axis");
                break;
            case Axis.rx:
                UpdateDot(Player1, Player1Dot,  Player1Dot.anchoredPosition.y);
                UpdateDot(Player2, Player2Dot, Player2Dot.anchoredPosition.y);
                break;
            case Axis.ry:
                UpdateDot(Player1, Player1Dot,  Player1Dot.anchoredPosition.x);
                UpdateDot(Player2, Player2Dot, Player2Dot.anchoredPosition.x);
                break;
            case Axis.rz:
                Debug.LogError("Not supported axis");
                break;
            default:
                throw new ArgumentOutOfRangeException();
        }

    }

    void UpdateDot(Transform player, RectTransform dot, float offset)
    {

        float progress = Vector3.Distance(player.position, EndPoint.position) / Vector3.Distance(StartPoint.position, EndPoint.position);
        Debug.Log(progress);


        float y;
        switch (Axis)
        {
            case Axis.x:
                y = (progress - 0.5f) * MinimapRect.rect.width;
                dot.anchoredPosition = new Vector2(1-y, offset);
                break;
            case Axis.y:
                y = (progress - 0.5f) * MinimapRect.rect.height;
                dot.anchoredPosition = new Vector2(offset, 1-y);
                break;
            case Axis.z:
                Debug.LogError("Not supported axis");
                break;
            case Axis.rx:
                y = (progress - 0.5f) * MinimapRect.rect.width;
                dot.anchoredPosition = new Vector2(y, offset);
                break;
            case Axis.ry:
                y = (progress - 0.5f) * MinimapRect.rect.height;
                dot.anchoredPosition = new Vector2(offset, y);
                break;
            case Axis.rz:
                Debug.LogError("Not supported axis");
                break;
            default:
                throw new ArgumentOutOfRangeException();
        }

    }
}
