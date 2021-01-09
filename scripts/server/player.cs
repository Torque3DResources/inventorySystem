function AAKPlayerData::onCollision(%this, %obj, %col, %vec)
{
   if (!isObject(%col) || %obj.getState() $= "Dead")
      return;

   // Try and pickup all items
   if (%col.getClassName() $= "Item")
   {
      %obj.pickup(%col);
      return;
   }
}