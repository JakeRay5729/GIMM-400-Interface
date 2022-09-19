using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Contender : IAttackAI, IProjectile
{
    public abstract float _projDamage { get; }
    public abstract string _name { get; set; }
    public abstract float _health { get; set; }
    private static float HEALTHMULTIPLIER = 100;
    public abstract float _Vision { get; set; }
    public abstract float _damage { get; set; }
    private static float STANDARDMULTIPLIER = 10;
    public abstract float _fireRate { get; set; }
    public abstract float _AttackRange { get; set; }
    public abstract float _Speed { get; set; }
    public abstract float _arenaRadius { get; set; }
    public float shotTime { get; set; }
    public float _projSpeed { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }

    public abstract void Attack(GameObject proj);
    public bool CheckValue()
    {
        if (_health < 10 || _health > 90)
        {
            Debug.LogException(new System.Exception("Health needs to be in between 10 and 90"));
            return false;
        }
        else if (_health != _Vision / _Speed) {
            Debug.LogException(new System.Exception("Review your health ratio(Health = Vision / Speed)"));
            return false;
        }
        if (_damage < 2 || _damage > 10)
        {
            Debug.LogException(new System.Exception("Health needs to be in between 2 and 10"));
            return false; 
        }
        else if (_damage != _AttackRange / _fireRate)
        {
            Debug.LogException(new System.Exception("Review your damage ratio (Damage = Attack Range/ Fire Rate)"));
            return false;
        }
        if (_fireRate < .1 || _fireRate > 1)
        {
            Debug.LogException(new System.Exception("Fire Rate needs to be between .1 and 1"));
            return false;
        }
        
        return true;

    }
    public abstract void DealDamage();
    public bool DeathCheck()
    {
        if (_health <= 0) return true;
        else return false;
    }
    public abstract void Die();
    public abstract void Move();
    public abstract bool shotConnected();
    public void TakeDamage(float amt)
    {
        _health -= amt;
        if(DeathCheck()) Die();
    }
    public abstract void shoot(Vector3 projDirection);
    /// <summary>
    /// Groups should calculate this based on time.deltatime and the timeShot variable based on fire rate
    /// </summary>
    public abstract void inheritDamage();

    public abstract void calculateSpeed();

    public void shoot()
    {
        throw new System.NotImplementedException();
    }

    public bool CanShoot()
    {
        throw new System.NotImplementedException();
    }
}
