using UnityEngine;

public interface IHitable
{
    void GetHit(int damageValue, GameObject sender);
}
