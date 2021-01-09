function inventorySystem::onCreate(%this)
{
}

function inventorySystem::onDestroy(%this)
{
}

//This is called when the server is initially set up by the game application
function inventorySystem::initServer(%this)
{
   %this.queueExec("./scripts/server/commands.cs");
   %this.queueExec("./scripts/server/inventory.cs");
   %this.queueExec("./scripts/server/item.cs");
   %this.queueExec("./scripts/server/pickupItem.cs");
   %this.queueExec("./scripts/server/player.cs");
}

//This is called when the server is created for an actual game/map to be played
function inventorySystem::onCreateGameServer(%this)
{
   %this.registerDatablock("./datablocks/testItem.cs");
}

//This is called when the server is shut down due to the game/map being exited
function inventorySystem::onDestroyGameServer(%this)
{
}

//This is called when the client is initially set up by the game application
function inventorySystem::initClient(%this)
{
   //client scripts
   //Here, we exec out keybind scripts so the player is able to move when they get into a game
   %this.queueExec("./scripts/client/default.keybinds.cs");
   
   %prefPath = getPrefpath();
   if(isFile(%prefPath @ "/keybinds.cs"))
      exec(%prefPath @ "/keybinds.cs");
      
   %this.queueExec("./scripts/client/inputCommands.cs");
}

//This is called when a client connects to a server
function inventorySystem::onCreateClientConnection(%this)
{
   inventoryKeybindMap.push();
}

//This is called when a client disconnects from a server
function inventorySystem::onDestroyClientConnection(%this)
{
   inventoryKeybindMap.pop();
}
