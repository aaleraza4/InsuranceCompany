using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ENUM.Occupation
{
    public enum OccupationType
    {
        [Description("Administration / Management")]
        Administration_Management = 1,
        [Description("Architect")]
        Architect,
        [Description("Banker")]
        Banker,
        [Description("Cashier")]
        Cashier,
        [Description("CEO")]
        CEO,
        [Description("Clergy")]
        Clergy,
        [Description("Clerical / Technical")]
        Clerical_Technical,
        [Description("College Professor")]
        CollegeProfessor,
        [Description("Contractor")]
        Contractor,
        [Description("Disabled")]
        Disabled,
        [Description("Government")]
        Government,
        [Description("Housewife / Househusband")]
        Housewife_Househusband,
        [Description("Military Officer")]
        MilitaryOfficer,
        [Description("Nurse / CNA")]
        Nurse_CNA,
        [Description("Other")]
        Other,
        [Description("Physician")]
        Physician,
        [Description("Retail")]
        Retail,
        [Description("Retired")]
        Retired,
        [Description("Self Employed")]
        SelfEmployed,
        [Description("Store Owner")]
        StoreOwner,
        [Description("Student Living")]
        StudentLiving,
        [Description("Teacher")]
        Teacher,
        [Description("Truck Driver")]
        TruckDriver,
        [Description("Unemployed")]
        Unemployed,
        [Description("Unknown")]
        Unknown,
    }
}
