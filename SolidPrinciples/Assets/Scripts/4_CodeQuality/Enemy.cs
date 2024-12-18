using System;
using System.Collections.Generic;
using UnityEngine;

namespace CodeQuality
{
    public class Enemy : MonoBehaviour
    {
        public Transform player;
        public float speed = 5.0f;
        public List<Weapon> weapons = new();
        private Weapon selectedWeapon;

        private void Start()
        {
            weapons.Add(new Sword(5.5f));
            weapons.Add(new Bow(10));
            selectedWeapon = weapons[0];
        }

        void Update()
        {
            transform.position = Vector3.MoveTowards(transform.position,
                player.position + (Quaternion.Euler(0, 45, 0) * player.forward).normalized * 1.0f,
                speed * Time.deltaTime);
            
            
            if (Input.GetMouseButtonDown(0))
            {
                AttackAction(selectedWeapon);
            }
            if (Input.GetMouseButtonDown(1))
            {
                NextWeapon();
            }
        }

        public void NextWeapon()
        {
            for (int i = 0; i < weapons.Count; i++)
            {
                if (selectedWeapon == weapons[i])
                {
                    if (i < weapons.Count - 1)
                    {
                        selectedWeapon = weapons[++i];
                        return;
                    }
                    selectedWeapon = weapons[0];
                }
            }
        }
        
        //In base al tipo di arma sceglie quale funzione di attacco utilizzare
        public void AttackAction(Weapon weapon)
        {
            weapon.Attack();
            //animazioni, altre funzioni
        }
        
        
    }
}