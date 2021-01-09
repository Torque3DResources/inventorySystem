// ----------------------------------------------------------------------------
// Throw/Toss
// ----------------------------------------------------------------------------

function serverCmdThrow(%client, %data)
{
   %player = %client.player;
   if(!isObject(%player) || %player.getState() $= "Dead" || !$Game::Running)
      return;
   switch$ (%data)
   {
      //Do special cases by type here
      case "TestItem":
         if(%player.hasInventory(%data.getName()))
            %player.throw(%data);
      default:
         if(%player.hasInventory(%data.getName()))
            %player.throw(%data);
   }
}
