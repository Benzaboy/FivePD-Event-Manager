using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CitizenFX.Core;
using CitizenFX.Core.Native;
using static CitizenFX.Core.Native.API;
using FivePD.API;
using Newtonsoft.Json;
using System.ComponentModel;

namespace FivePDEventManager
{
    class Main : BaseScript
    {
        bool DutyStatus = false;

        public Main()
        {
            EventHandlers["FivePDEventManager:VehicleData:Get"] += new Action<int>(VehicleData);
            EventHandlers["FivePDEventManager:PedData:Get"] += new Action<int>(PedData);
            EventHandlers["FivePDEventManager:DutyStatus:Get"] += new Action(GetDutyStatus);

            Events.OnDutyStatusChange += updateDutyStatus;
        }

        public async void VehicleData(int vehicle)
        {
            dynamic data = await Utilities.GetVehicleData(vehicle);

            string dataJson = JsonConvert.SerializeObject(data, Formatting.Indented);

            TriggerEvent("FivePDEventManager:PedData:Return", dataJson);
        }

        public async void PedData(int ped)
        {
            dynamic data = await Utilities.GetPedData(ped);

            string dataJson = JsonConvert.SerializeObject(data, Formatting.Indented);

            TriggerEvent("FivePDEventManager:PedData:Return", dataJson);
        }

        public void GetDutyStatus()
        {
            TriggerEvent("FivePDEventManager:DutyStatus:Return", DutyStatus);
        }

        private async Task updateDutyStatus(bool onDuty)
        {
            if (onDuty)
            {
                DutyStatus = true;
            }
            else
            {
                DutyStatus = false;
            }
        }
    }
}
