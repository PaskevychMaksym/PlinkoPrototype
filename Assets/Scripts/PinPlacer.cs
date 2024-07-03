using UnityEngine;

public class PinPlacer : MonoBehaviour
{
  private const float SPACING_MULTIPLIER = 2f;
  
  [SerializeField]
  private Pin _pinPrefab;
  [SerializeField]
  private int _rows = 10;

  private float _pinScale;

  private void Start()
  {
    Initialize();
  }

  private void Initialize()
  {
    CalculatePinScale();
    PlacePins();
  }

  private void CalculatePinScale()
  {
    ScreenScaler screenScaler = ScreenScaler.Instance;
    _pinScale = screenScaler.ScreenWidth / (_rows + 2) * 0.5f;
  }

  private void PlacePins()
  {
    ScreenScaler screenScaler = ScreenScaler.Instance;
    float spacingX = _pinScale * SPACING_MULTIPLIER;
    float spacingY = _pinScale * SPACING_MULTIPLIER;

    float startY = screenScaler.ScreenHeight / 2 - (_rows * spacingY) / 2;
    startY -= screenScaler.ScreenHeight / 4;

    for (int row = 0; row < _rows; row++)
    {
      int pinsInRow = row + 3;
      float rowCenter = (pinsInRow - 1) * spacingX / 2;

      for (int col = 0; col < pinsInRow; col++)
      {
        Vector3 position = new Vector3(col * spacingX - rowCenter, startY - row * spacingY, 0);
        GameObject pin = Instantiate(_pinPrefab.gameObject, position, Quaternion.identity, transform);
        pin.transform.localScale = new Vector3(_pinScale, _pinScale, 1.0f);
      }
    }
  }
}