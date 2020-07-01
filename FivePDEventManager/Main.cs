using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CitizenFX.Core;
using CitizenFX.Core.Native;
using static CitizenFX.Core.Native.API;
using FivePD.API;
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

            string licensePlate = data.LicensePlate;
            string flag = data.Flag;
            int ownerNetworkID = data.OwnerNetworkID;
            string ownerFirstName = data.OwnerFirstName;
            string ownerLastName = data.OwnerLastName;
            bool insurance = data.Insurance;
            bool registration = data.Regustration;
            string color = data.VehicleColor;
            string vehicleName = data.VehicleName;
            int vehicleID = data.ID;
            List<dynamic> items = data.Items;

            TriggerEvent("FivePDEventManager:VehicleData:Return", licensePlate, flag, ownerNetworkID, ownerFirstName, ownerLastName, insurance, registration, color, vehicleName, vehicleID, items);
        }

        public async void PedData(int ped)
        {
            dynamic data = await Utilities.GetPedData(ped);

            string firstName = data.FirstName;
            string lastName = data.LastName;
            string warrant = data.Warrant;
            string license = data.License;
            string dob = data.DOB;
            double alcoholLevel = data.AlcoholLevel;
            bool[] drugs = data.DrugsUsed;
            string gender = data.Gender;
            int age = data.Age;
            string address = data.Address;
            List<dynamic> items = data.Items;
            List<dynamic> violations = data.Violations;

            TriggerEvent("FivePDEventManager:PedData:Return", firstName, lastName, warrant, license, dob, alcoholLevel, drugs, gender, age, address, items, violations);
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
