using UnityEngine;

public class ItemPickup : Interactable {
    public Item item;

    public override void Interact()
    {
        base.Interact();

        PickUp();
    }

    void PickUp()
    {   
        bool wasItemPickedUp = Inventory.instance.AddItem(item);

        if(wasItemPickedUp)
        {
            Debug.Log(item.name + " picked up!");
            Destroy(gameObject);
        } 
    }
}
