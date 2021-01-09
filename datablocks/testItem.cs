//-----------------------------------------------------------------------------
// Item
//-----------------------------------------------------------------------------
datablock ItemData(TestItem)
{
   // Mission editor category
   category = "Pickup";

   // Add the Ammo namespace as a parent.  The ammo namespace provides
   // common ammo related functions and hooks into the inventory system.

   // Basic Item properties
   mass = 1;
   elasticity = 0.2;
   friction = 0.6;

   // Dynamic properties defined by the scripts
   pickUpName = "Test Item";
   description = "A Test Item";
   count = 1;
   maxInventory = 10;
   ShapeAsset = "Prototyping:SpherePrimitive";
   cameraMaxDist = "0.0100109";
   class = "PickupItem";
};
