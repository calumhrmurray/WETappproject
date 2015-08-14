using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace WETwebApp.Models
{
    public class Attitude
    {
        public int AttitudeID { get; set; }
        public int HouseholdID { get; set; }

        //Load of questions on water attitudes etc
        [DisplayName("Washing Machine with full loads")]
        public bool WashingMachine { get; set; }
        [DisplayName("Dishwasher with full loads")]
        public bool Dishwasher { get; set; }
        [DisplayName("Washing Machine - lower temperature/economy setting")]
        public bool WashingLow { get; set; }
        [DisplayName("Dishwasher - lower temperature/economy setting")]
        public bool DishwashLow { get; set; }
        [DisplayName("Energy and water efficient washing machine")]
        public bool WashingEff { get; set; }
        [DisplayName("Energy and water efficient dishwasher")]
        public bool DishwasherEff { get; set; }
        [DisplayName("Only fill kettle with water that is needed")]
        public bool Kettle { get; set; }
        [DisplayName("Turn the tap off when washing up")]
        public bool TapsOff { get; set; }
        [DisplayName("Washing up in a bowl")]
        public bool WashingBowl { get; set; }
        [DisplayName("Rinsing in a bowl")]
        public bool RinsingBowl { get; set; }
        [DisplayName("Tap flow regulators in the kitchen")]
        public bool TapsFlow { get; set; }
        [DisplayName("No behaviours in the kitchen")]
        public bool NoKitchen { get; set; }
        [DisplayName("Other in the kitchen")]
        public string OtherKitchen { get; set; }

        [DisplayName("Not flushing every time after using the toilet")]
        public bool NoFlush { get; set; }
        [DisplayName("Low or dual flush toilet")]
        public bool LowFlush { get; set; }
        [DisplayName("Save-a-flush bag or cistern displacement device")]
        public bool CDD { get; set; }
        [DisplayName("Water efficent shower")]
        public bool LowShower { get; set; }
        [DisplayName("Turn tapps off when brushing teeth")]
        public bool TapsOffBrush { get; set; }
        [DisplayName("Take showers instead of baths")]
        public bool ShowersNotBaths { get; set; }
        [DisplayName("Using less water in the bathroom")]
        public bool LessBathWater { get; set; }
        [DisplayName("Take shorter showers")]
        public bool ShorterShowers { get; set; }
        [DisplayName("Tap flow regulators in bathroom")]
        public bool TapsFlowBath { get; set; }
        [DisplayName("No behaviours in the bathroom")]
        public bool NoBathroom { get; set; }
        [DisplayName("Other in the bathroom")]
        public string OtherBath { get; set; }

        [DisplayName("Water butt")]
        public bool WaterButt { get; set; }
        [DisplayName("Watering can to water garden")]
        public bool WaterCan { get; set; }
        [DisplayName("Stopped using the hosepipe")]
        public bool NoHosepipe { get; set; }
        [DisplayName("Not watering the lawn")]
        public bool NoWaterLawn { get; set; }
        [DisplayName("No behaviours in the garden")]
        public bool NoGarden { get; set; }
        [DisplayName("Other in the garden")]
        public string OtherGarden { get; set; }
        
        [DisplayName("Update Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime UpdateDate { get; set; }

        public virtual Household Household { get; set; }
    }
}
