# Inventory System
Implements a basic, script-driven inventory system for being able to track inventory of Items on other objects.
Uses Torques [RPC](https://www.techtarget.com/searchapparchitecture/definition/Remote-Procedure-Call-RPC) generating methods for networking inventory status to clients.
Also leverages callOnModules() to inform other modules when inventory changes or is cleared for interop
 
# Usage and Instructions
### Installation
Copy entire inventorySystem folder into the Torque3D project's data/ folder, restart the project if it's running and it'll be integrated.

## ShapeBase/Control Objects
These are the classes that players are actually controlling, or moving around as AI or the like. Objects you would track inventory for. The commands on these interface with the inventory functions to update their internal tracked inventory info. Because the primary functions are run via the ShapeBase namespace, it means that the inventory system integrates into any Shapebase-derived gameclass, such as Player, Vehicle, StaticShape, etc. Even items could be made to have inventory themselves, if you wanted to.
It generally reacts via direct script invocation(such as a weapon calling to decrease the gun user's ammo count when fired) or callbacks like when the shapebase object
collides with an item, acticating the item's onCollision callback response.
Also implements the ability to throw or use items in the inventory directly to example behavior outside of simply making the numbers go up or down.

## Items
Inventory tracking mainly works via the Item class, utilizing the Item's ItemData datablock for namespace callbacks and parameter
tracking. The object's inventory is categorized via ItemDatas acting as keys to arrays, allowing for very simple, consistent lookups. It also utilizes the callbacks
like onCollision to react to ShapeBase objects hitting it. 

### ItemData
These are for your pickups, such as the weapons or weapon ammo. The scripted behavior for handling the pickup dictates if it provides increased ammo amounts, or if when used it mounts the provided ShapeBaseImage to be used as an active weapon.
Additionally defines physical properties for when items are thrown or dropped, as well as secondary info like descriptions or preview images which can be used for GUI integration like inventory screens or HUD elements.

## RPC Samples:
### Sending a message from a client to the server
Client side command:
```
function useItem(%val)
{
   if (%val)
      commandToServer('Use', "TestItem");
}
```

Server side command:
```
function serverCmdUse(%client, %itemData)
{
   //Get the ControlObject and invoke the use function on it with the passed ItemData
   %client.getControlObject().use(%itemData);
}
```

Per above, when calling commandToServer(), the command name 'Use' is a tag string, using only single quotations.
This tag string is combined with the standard "serverCmd" prefix to build the full name of the callback function on the server to receive the RPC command.
Parameters are otherwise passed normally. Another example is the throw command, which calls from the client to the server to make the controlled object throw the inventory item.

## callOnModule callbacks
Uses the core callOnModules function to signal to any modules active that we have a particular event happening. It behaves akin to a regular signal-listen system.

Examples:

```
function ShapeBase::setInventory(%this)
{...
    callonModules("onSetInventory","Game", %this, %itemData, %value); //%this is the object-instance holding the item
}
```

```
function ShapeBase::clearInventory(%this)
{...
    callonModules("onClearInventory", %this);
}
```

