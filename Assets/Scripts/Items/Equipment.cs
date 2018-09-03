using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Equipment", menuName = "Inventory/Equipment")]
public class Equipment : Item {

    public EquipSlot equipSlot;

    [SerializeField] private int armorMod;
    [SerializeField] private int dmgMod;

    public override void Use()
    {
        base.Use();
        EquipmentManager.instance.Equip(this);
        RemoveFromInventory();
    }
}

public enum EquipSlot { Head, Body, Legs, Feet, Shield, Weapon}