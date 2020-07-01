# FivePD-Event-Manager
This plugin is used with the FiveM plugin, FivePD. This is aimed towards developers who wish to use some of the functions where it is currently not possible due to API limitations. This makes use of FiveM's Events to get information.

You can find all of the information about these features on the official FivePD Wiki: https://github.com/KDani-99/FivePD-API/wiki

# Installation
All you need to do to set this up, is move the built `FivePDEventManager.net.dll` into your FivePD plugins folder.

# Usage
Get Vehicle Data:
```csharp
TriggerEvent("FivePDEventManager:VehicleData:Get", Vehicle vehicle);
EventHandlers["FivePDEventManager:VehicleData:Return"] += new Action<string, string, int, string, string, bool, bool, string, string, int, List<dynamic>>(VehicleData);
public void VehicleData(string licensePlate, string flag, int ownerNetworkID, string ownerFirstName, string ownerLastName, bool insurance, bool registration, string color, string vehicleName, int vehicleID, List<dynamic> items)
{
  // Do something here
}
```

Get Ped Data:
```csharp
TriggerEvent("FivePDEventManager:PedData:Get", Ped ped);
EventHandlers["FivePDEventManager:PedData:Return"] += new Action<string, string, string, string, string, double, bool[], string, int, string, List<dynamic>, List<Dynamic>>(PedData);
public void PedData(string firstName, string lastName, string warrant, string license, string dob, double alcoholLevel, bool[] drugs, string gender, int age, string address, List<dynamic> items, List<dynamic> violations)
{
  // Do something here
}
```

Get Duty Status:
```csharp
TriggerEvent("FivePDEventManager:DutyStatus:Get");
EventHandlers["FivePDEventManager:DutyStatus:Return"] += new Action<bool>(DutyStatus);
public void DutyStatus(bool DutyStatus)
{
  // Do something here
}
```
