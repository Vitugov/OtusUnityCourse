using System;
using UnityEngine;


namespace ShootEmUp
{
    public interface IDamageable
    {
        event Action<GameObject> HpEmpty;

        bool IsHitPointsExists();
        void TakeDamage(int damage);
    }
}