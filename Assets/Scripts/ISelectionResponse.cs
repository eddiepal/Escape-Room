using UnityEngine;

internal interface ISelectionResponse
{
    void OnSelect(Transform selection);
    void OnDeselect(Transform selection);
    void DropObject(Transform selection);
}