using UnityEngine;
using UnityEngine.EventSystems;

public class Click : MonoBehaviour, IPointerDownHandler
{
    [SerializeField] private Player _player;

    public void OnPointerDown(PointerEventData eventData) => _player.Shoot();
}
