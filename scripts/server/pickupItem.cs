function PickupItem::onPickup(%this, %obj, %shape, %amount)
{
   // The parent Item method performs the actual pickup.
   if (Parent::onPickup(%this, %obj, %shape, %amount))
      serverPlay3D(AmmoPickupSound, %shape.getTransform());

   // The clip inventory state has changed, we need to update the
   // current mounted image using this clip to reflect the new state.
   /*if ((%image = %shape.getMountedImage($WeaponSlot)) > 0)
   {
      // Check if this weapon uses the clip we just picked up and if
      // there is no ammo.
      if (%image.isField("clip") && %image.clip.getId() == %this.getId())
      {
         %outOfAmmo = !%shape.getImageAmmo($WeaponSlot);
         
         %currentAmmo = %shape.getInventory(%image.ammo);

         if ( isObject( %image.clip ) )
            %amountInClips = %shape.getInventory(%image.clip);
            
         %amountInClips *= %image.ammo.maxInventory;
         %amountInClips += %obj.getFieldValue( "remaining" @ %this.ammo.getName() );
         
         %shape.client.setAmmoAmountHud(%currentAmmo, %amountInClips );
         
         if (%outOfAmmo)
         {
            %image.onClipEmpty(%shape, $WeaponSlot);
         }
      }
   }*/
}