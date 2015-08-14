namespace WETwebApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Advices",
                c => new
                    {
                        AdviceID = c.Int(nullable: false, identity: true),
                        HouseholdID = c.Int(nullable: false),
                        AdviceTypeID = c.Int(nullable: false),
                        Aware = c.Boolean(nullable: false),
                        AdviceComment = c.String(),
                        AdviceNotes = c.String(),
                        MessageComment = c.String(),
                        UpdateDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.AdviceID)
                .ForeignKey("dbo.AdviceTypes", t => t.AdviceTypeID, cascadeDelete: true)
                .ForeignKey("dbo.Households", t => t.HouseholdID, cascadeDelete: true)
                .Index(t => t.HouseholdID)
                .Index(t => t.AdviceTypeID);
            
            CreateTable(
                "dbo.AdviceTypes",
                c => new
                    {
                        AdviceTypeID = c.Int(nullable: false, identity: true),
                        Type = c.String(),
                    })
                .PrimaryKey(t => t.AdviceTypeID);
            
            CreateTable(
                "dbo.Households",
                c => new
                    {
                        HouseholdID = c.Int(nullable: false, identity: true),
                        HouseholdTypeID = c.Int(nullable: false),
                        DeveloperID = c.Int(nullable: false),
                        WPnumber = c.String(),
                        Address1 = c.String(),
                        Address2 = c.String(),
                        Town = c.String(),
                        Postcode = c.String(),
                        HESarea = c.String(),
                        HESbatch = c.String(),
                        MonitorStatus = c.String(),
                        FirstReading = c.DateTime(),
                    })
                .PrimaryKey(t => t.HouseholdID)
                .ForeignKey("dbo.Developers", t => t.DeveloperID, cascadeDelete: true)
                .ForeignKey("dbo.HouseholdTypes", t => t.HouseholdTypeID, cascadeDelete: true)
                .Index(t => t.HouseholdTypeID)
                .Index(t => t.DeveloperID);
            
            CreateTable(
                "dbo.Attitudes",
                c => new
                    {
                        AttitudeID = c.Int(nullable: false, identity: true),
                        HouseholdID = c.Int(nullable: false),
                        WashingMachine = c.Boolean(nullable: false),
                        Dishwasher = c.Boolean(nullable: false),
                        WashingLow = c.Boolean(nullable: false),
                        DishwashLow = c.Boolean(nullable: false),
                        WashingEff = c.Boolean(nullable: false),
                        DishwasherEff = c.Boolean(nullable: false),
                        Kettle = c.Boolean(nullable: false),
                        TapsOff = c.Boolean(nullable: false),
                        WashingBowl = c.Boolean(nullable: false),
                        RinsingBowl = c.Boolean(nullable: false),
                        TapsFlow = c.Boolean(nullable: false),
                        NoKitchen = c.Boolean(nullable: false),
                        OtherKitchen = c.String(),
                        NoFlush = c.Boolean(nullable: false),
                        LowFlush = c.Boolean(nullable: false),
                        CDD = c.Boolean(nullable: false),
                        LowShower = c.Boolean(nullable: false),
                        TapsOffBrush = c.Boolean(nullable: false),
                        ShowersNotBaths = c.Boolean(nullable: false),
                        LessBathWater = c.Boolean(nullable: false),
                        ShorterShowers = c.Boolean(nullable: false),
                        TapsFlowBath = c.Boolean(nullable: false),
                        NoBathroom = c.Boolean(nullable: false),
                        OtherBath = c.String(),
                        WaterButt = c.Boolean(nullable: false),
                        WaterCan = c.Boolean(nullable: false),
                        NoHosepipe = c.Boolean(nullable: false),
                        NoWaterLawn = c.Boolean(nullable: false),
                        NoGarden = c.Boolean(nullable: false),
                        OtherGarden = c.String(),
                        UpdateDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.AttitudeID)
                .ForeignKey("dbo.Households", t => t.HouseholdID, cascadeDelete: true)
                .Index(t => t.HouseholdID);
            
            CreateTable(
                "dbo.Bathrooms",
                c => new
                    {
                        BathroomID = c.Int(nullable: false, identity: true),
                        HouseholdID = c.Int(nullable: false),
                        BathroomTypeID = c.Int(nullable: false),
                        BathroomQuantity = c.Int(nullable: false),
                        ToiletQuantity = c.Int(nullable: false),
                        SingleToiletQuantity = c.Int(nullable: false),
                        DualToiletQuantity = c.Int(nullable: false),
                        Electric = c.Boolean(nullable: false),
                        Power = c.Boolean(nullable: false),
                        Mixer = c.Boolean(nullable: false),
                        Unknown = c.Boolean(nullable: false),
                        Round = c.Boolean(nullable: false),
                        Threaded = c.Boolean(nullable: false),
                        NonThreaded = c.Boolean(nullable: false),
                        Other = c.Boolean(nullable: false),
                        UpdateDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.BathroomID)
                .ForeignKey("dbo.BathroomTypes", t => t.BathroomTypeID, cascadeDelete: true)
                .ForeignKey("dbo.Households", t => t.HouseholdID, cascadeDelete: true)
                .Index(t => t.HouseholdID)
                .Index(t => t.BathroomTypeID);
            
            CreateTable(
                "dbo.BathroomTypes",
                c => new
                    {
                        BathroomTypeID = c.Int(nullable: false, identity: true),
                        Type = c.String(),
                    })
                .PrimaryKey(t => t.BathroomTypeID);
            
            CreateTable(
                "dbo.Developers",
                c => new
                    {
                        DeveloperID = c.Int(nullable: false, identity: true),
                        Type = c.String(),
                    })
                .PrimaryKey(t => t.DeveloperID);
            
            CreateTable(
                "dbo.HouseholdInformations",
                c => new
                    {
                        HouseholdInformationID = c.Int(nullable: false, identity: true),
                        HouseholdID = c.Int(nullable: false),
                        ElectricitySupplierTypeID = c.Int(nullable: false),
                        GasSupplierTypeID = c.Int(nullable: false),
                        TelevisionSupplierTypeID = c.Int(nullable: false),
                        HeatingSystemTypeID = c.Int(nullable: false),
                        HouseholdDescriptionTypeID = c.Int(nullable: false),
                        InternetAccess = c.Boolean(nullable: false),
                        HouseholdNotes = c.String(),
                        UpdateDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.HouseholdInformationID)
                .ForeignKey("dbo.ElectricitySupplierTypes", t => t.ElectricitySupplierTypeID, cascadeDelete: true)
                .ForeignKey("dbo.GasSupplierTypes", t => t.GasSupplierTypeID, cascadeDelete: true)
                .ForeignKey("dbo.HeatingSystemTypes", t => t.HeatingSystemTypeID, cascadeDelete: true)
                .ForeignKey("dbo.Households", t => t.HouseholdID, cascadeDelete: true)
                .ForeignKey("dbo.HouseholdDescriptionTypes", t => t.HouseholdDescriptionTypeID, cascadeDelete: true)
                .ForeignKey("dbo.TelevisionSupplierTypes", t => t.TelevisionSupplierTypeID, cascadeDelete: true)
                .Index(t => t.HouseholdID)
                .Index(t => t.ElectricitySupplierTypeID)
                .Index(t => t.GasSupplierTypeID)
                .Index(t => t.TelevisionSupplierTypeID)
                .Index(t => t.HeatingSystemTypeID)
                .Index(t => t.HouseholdDescriptionTypeID);
            
            CreateTable(
                "dbo.ElectricitySupplierTypes",
                c => new
                    {
                        ElectricitySupplierTypeID = c.Int(nullable: false, identity: true),
                        Type = c.String(),
                    })
                .PrimaryKey(t => t.ElectricitySupplierTypeID);
            
            CreateTable(
                "dbo.GasSupplierTypes",
                c => new
                    {
                        GasSupplierTypeID = c.Int(nullable: false, identity: true),
                        Type = c.String(),
                    })
                .PrimaryKey(t => t.GasSupplierTypeID);
            
            CreateTable(
                "dbo.HeatingSystemTypes",
                c => new
                    {
                        HeatingSystemTypeID = c.Int(nullable: false, identity: true),
                        Type = c.String(),
                    })
                .PrimaryKey(t => t.HeatingSystemTypeID);
            
            CreateTable(
                "dbo.HouseholdDescriptionTypes",
                c => new
                    {
                        HouseholdDescriptionTypeID = c.Int(nullable: false, identity: true),
                        Type = c.String(),
                    })
                .PrimaryKey(t => t.HouseholdDescriptionTypeID);
            
            CreateTable(
                "dbo.TelevisionSupplierTypes",
                c => new
                    {
                        TelevisionSupplierTypeID = c.Int(nullable: false, identity: true),
                        Type = c.String(),
                    })
                .PrimaryKey(t => t.TelevisionSupplierTypeID);
            
            CreateTable(
                "dbo.HouseholdTypes",
                c => new
                    {
                        HouseholdTypeID = c.Int(nullable: false, identity: true),
                        Type = c.String(),
                    })
                .PrimaryKey(t => t.HouseholdTypeID);
            
            CreateTable(
                "dbo.Kitchens",
                c => new
                    {
                        KitchenID = c.Int(nullable: false, identity: true),
                        HouseholdID = c.Int(nullable: false),
                        WashingMachine = c.Boolean(nullable: false),
                        Dishwasher = c.Boolean(nullable: false),
                        UpdateDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.KitchenID)
                .ForeignKey("dbo.Households", t => t.HouseholdID, cascadeDelete: true)
                .Index(t => t.HouseholdID);
            
            CreateTable(
                "dbo.Occupants",
                c => new
                    {
                        OccupantID = c.Int(nullable: false, identity: true),
                        HouseholdID = c.Int(nullable: false),
                        MaleQuantity = c.Int(nullable: false),
                        FemaleQuantity = c.Int(nullable: false),
                        ChildQuantity = c.Int(nullable: false),
                        OccupantNotes = c.String(),
                        SelfEmployed = c.Int(nullable: false),
                        EmployedFull = c.Int(nullable: false),
                        EmployedPart = c.Int(nullable: false),
                        Home = c.Int(nullable: false),
                        Retired = c.Int(nullable: false),
                        Unemployed = c.Int(nullable: false),
                        School = c.Int(nullable: false),
                        Further = c.Int(nullable: false),
                        GovWork = c.Int(nullable: false),
                        PreSchool = c.Int(nullable: false),
                        Other = c.Int(nullable: false),
                        DemographicNotes = c.String(),
                        BedroomQuantity = c.Int(nullable: false),
                        UpdateDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.OccupantID)
                .ForeignKey("dbo.Households", t => t.HouseholdID, cascadeDelete: true)
                .Index(t => t.HouseholdID);
            
            CreateTable(
                "dbo.Outdoors",
                c => new
                    {
                        OutdoorID = c.Int(nullable: false, identity: true),
                        HouseholdID = c.Int(nullable: false),
                        Garden = c.Boolean(nullable: false),
                        Car = c.Boolean(nullable: false),
                        WaterGarden = c.Boolean(nullable: false),
                        WashCar = c.Boolean(nullable: false),
                        UpdateDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.OutdoorID)
                .ForeignKey("dbo.Households", t => t.HouseholdID, cascadeDelete: true)
                .Index(t => t.HouseholdID);
            
            CreateTable(
                "dbo.People",
                c => new
                    {
                        PersonID = c.Int(nullable: false, identity: true),
                        HouseholdID = c.Int(nullable: false),
                        FirstName = c.String(),
                        LastName = c.String(),
                        Email = c.String(),
                        Telephone = c.String(),
                        Communication = c.String(),
                        Notes = c.String(),
                        UpdateDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.PersonID)
                .ForeignKey("dbo.Households", t => t.HouseholdID, cascadeDelete: true)
                .Index(t => t.HouseholdID);
            
            CreateTable(
                "dbo.Visits",
                c => new
                    {
                        VisitID = c.Int(nullable: false, identity: true),
                        HouseholdID = c.Int(nullable: false),
                        VisitTypeID = c.Int(nullable: false),
                        Complete = c.Boolean(nullable: false),
                        VisitDate = c.DateTime(),
                    })
                .PrimaryKey(t => t.VisitID)
                .ForeignKey("dbo.Households", t => t.HouseholdID, cascadeDelete: true)
                .ForeignKey("dbo.VisitTypes", t => t.VisitTypeID, cascadeDelete: true)
                .Index(t => t.HouseholdID)
                .Index(t => t.VisitTypeID);
            
            CreateTable(
                "dbo.Bookings",
                c => new
                    {
                        BookingID = c.Int(nullable: false, identity: true),
                        VisitID = c.Int(nullable: false),
                        AdvisorID = c.Int(nullable: false),
                        BookingDate = c.DateTime(nullable: false),
                        BookedVisitDate = c.DateTime(),
                        AttemptNumber = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.BookingID)
                .ForeignKey("dbo.Advisors", t => t.AdvisorID, cascadeDelete: true)
                .ForeignKey("dbo.Visits", t => t.VisitID, cascadeDelete: true)
                .Index(t => t.VisitID)
                .Index(t => t.AdvisorID);
            
            CreateTable(
                "dbo.Advisors",
                c => new
                    {
                        AdvisorID = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
                        Email = c.String(),
                        Telephone = c.String(),
                    })
                .PrimaryKey(t => t.AdvisorID);
            
            CreateTable(
                "dbo.VisitTypes",
                c => new
                    {
                        VisitTypeID = c.Int(nullable: false, identity: true),
                        Type = c.String(),
                    })
                .PrimaryKey(t => t.VisitTypeID);
            
            CreateTable(
                "dbo.WaterReductions",
                c => new
                    {
                        WaterReductionID = c.Int(nullable: false, identity: true),
                        Type = c.String(),
                        Household_HouseholdID = c.Int(),
                    })
                .PrimaryKey(t => t.WaterReductionID)
                .ForeignKey("dbo.Households", t => t.Household_HouseholdID)
                .Index(t => t.Household_HouseholdID);
            
            CreateTable(
                "dbo.WaterUnderstandings",
                c => new
                    {
                        WaterUnderstandingID = c.Int(nullable: false, identity: true),
                        HouseholdID = c.Int(nullable: false),
                        WaterReductionID = c.Int(nullable: false),
                        WaterSupplier = c.Boolean(nullable: false),
                        FamilyUsage = c.String(),
                        IndividualUsage = c.String(),
                        SavingBills = c.Boolean(nullable: false),
                        WaterReductionWhy = c.String(),
                        UpdateDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.WaterUnderstandingID)
                .ForeignKey("dbo.Households", t => t.HouseholdID, cascadeDelete: true)
                .ForeignKey("dbo.WaterReductions", t => t.WaterReductionID, cascadeDelete: true)
                .Index(t => t.HouseholdID)
                .Index(t => t.WaterReductionID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.WaterReductions", "Household_HouseholdID", "dbo.Households");
            DropForeignKey("dbo.WaterUnderstandings", "WaterReductionID", "dbo.WaterReductions");
            DropForeignKey("dbo.WaterUnderstandings", "HouseholdID", "dbo.Households");
            DropForeignKey("dbo.Visits", "VisitTypeID", "dbo.VisitTypes");
            DropForeignKey("dbo.Visits", "HouseholdID", "dbo.Households");
            DropForeignKey("dbo.Bookings", "VisitID", "dbo.Visits");
            DropForeignKey("dbo.Bookings", "AdvisorID", "dbo.Advisors");
            DropForeignKey("dbo.People", "HouseholdID", "dbo.Households");
            DropForeignKey("dbo.Outdoors", "HouseholdID", "dbo.Households");
            DropForeignKey("dbo.Occupants", "HouseholdID", "dbo.Households");
            DropForeignKey("dbo.Kitchens", "HouseholdID", "dbo.Households");
            DropForeignKey("dbo.Households", "HouseholdTypeID", "dbo.HouseholdTypes");
            DropForeignKey("dbo.HouseholdInformations", "TelevisionSupplierTypeID", "dbo.TelevisionSupplierTypes");
            DropForeignKey("dbo.HouseholdInformations", "HouseholdDescriptionTypeID", "dbo.HouseholdDescriptionTypes");
            DropForeignKey("dbo.HouseholdInformations", "HouseholdID", "dbo.Households");
            DropForeignKey("dbo.HouseholdInformations", "HeatingSystemTypeID", "dbo.HeatingSystemTypes");
            DropForeignKey("dbo.HouseholdInformations", "GasSupplierTypeID", "dbo.GasSupplierTypes");
            DropForeignKey("dbo.HouseholdInformations", "ElectricitySupplierTypeID", "dbo.ElectricitySupplierTypes");
            DropForeignKey("dbo.Households", "DeveloperID", "dbo.Developers");
            DropForeignKey("dbo.Bathrooms", "HouseholdID", "dbo.Households");
            DropForeignKey("dbo.Bathrooms", "BathroomTypeID", "dbo.BathroomTypes");
            DropForeignKey("dbo.Attitudes", "HouseholdID", "dbo.Households");
            DropForeignKey("dbo.Advices", "HouseholdID", "dbo.Households");
            DropForeignKey("dbo.Advices", "AdviceTypeID", "dbo.AdviceTypes");
            DropIndex("dbo.WaterUnderstandings", new[] { "WaterReductionID" });
            DropIndex("dbo.WaterUnderstandings", new[] { "HouseholdID" });
            DropIndex("dbo.WaterReductions", new[] { "Household_HouseholdID" });
            DropIndex("dbo.Bookings", new[] { "AdvisorID" });
            DropIndex("dbo.Bookings", new[] { "VisitID" });
            DropIndex("dbo.Visits", new[] { "VisitTypeID" });
            DropIndex("dbo.Visits", new[] { "HouseholdID" });
            DropIndex("dbo.People", new[] { "HouseholdID" });
            DropIndex("dbo.Outdoors", new[] { "HouseholdID" });
            DropIndex("dbo.Occupants", new[] { "HouseholdID" });
            DropIndex("dbo.Kitchens", new[] { "HouseholdID" });
            DropIndex("dbo.HouseholdInformations", new[] { "HouseholdDescriptionTypeID" });
            DropIndex("dbo.HouseholdInformations", new[] { "HeatingSystemTypeID" });
            DropIndex("dbo.HouseholdInformations", new[] { "TelevisionSupplierTypeID" });
            DropIndex("dbo.HouseholdInformations", new[] { "GasSupplierTypeID" });
            DropIndex("dbo.HouseholdInformations", new[] { "ElectricitySupplierTypeID" });
            DropIndex("dbo.HouseholdInformations", new[] { "HouseholdID" });
            DropIndex("dbo.Bathrooms", new[] { "BathroomTypeID" });
            DropIndex("dbo.Bathrooms", new[] { "HouseholdID" });
            DropIndex("dbo.Attitudes", new[] { "HouseholdID" });
            DropIndex("dbo.Households", new[] { "DeveloperID" });
            DropIndex("dbo.Households", new[] { "HouseholdTypeID" });
            DropIndex("dbo.Advices", new[] { "AdviceTypeID" });
            DropIndex("dbo.Advices", new[] { "HouseholdID" });
            DropTable("dbo.WaterUnderstandings");
            DropTable("dbo.WaterReductions");
            DropTable("dbo.VisitTypes");
            DropTable("dbo.Advisors");
            DropTable("dbo.Bookings");
            DropTable("dbo.Visits");
            DropTable("dbo.People");
            DropTable("dbo.Outdoors");
            DropTable("dbo.Occupants");
            DropTable("dbo.Kitchens");
            DropTable("dbo.HouseholdTypes");
            DropTable("dbo.TelevisionSupplierTypes");
            DropTable("dbo.HouseholdDescriptionTypes");
            DropTable("dbo.HeatingSystemTypes");
            DropTable("dbo.GasSupplierTypes");
            DropTable("dbo.ElectricitySupplierTypes");
            DropTable("dbo.HouseholdInformations");
            DropTable("dbo.Developers");
            DropTable("dbo.BathroomTypes");
            DropTable("dbo.Bathrooms");
            DropTable("dbo.Attitudes");
            DropTable("dbo.Households");
            DropTable("dbo.AdviceTypes");
            DropTable("dbo.Advices");
        }
    }
}
