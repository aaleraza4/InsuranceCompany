using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ENUM.Insurance_Company
{
    public enum InsuranceCompany
    {
        [Description("AARP")]
        AARP = 1,
        [Description("AETNA")]
        AETNA,
        [Description("AFLAC")]
        AFLAC,
        [Description("American Family")]
        AmericanFamily,
        [Description("Anthem")]
        Anthem,
        [Description("Armed Forces Insurance")]
        ArmedForcesInsurance,
        [Description("Blue Cross Blue Shield")]
        BlueCrossBlueShield,
        [Description("Cigna")]
        Cigna,
        [Description("GoldenRule")]
        GoldenRule,
        [Description("HartFord AARP")]
        HartFord_AARP,
        [Description("Health Net")]
        HealthNet,
        [Description("Health Plus of America")]
        HealthPlusOfAmerica,
        [Description("Health Markets")]
        HealthMarkets,
        [Description("LifeWise Health Plan")]
        LifeWiseHealthPlan,
        [Description("Metlife Insurance")]
        MetlifeInsurance,
        
        [Description("Mutual Of Omaha")]
        MutualOfOmaha,
        [Description("Oxford")]
        Oxford,
        [Description("Principle Financial")]
        PrincipleFinancial,
        [Description("State Farm")]
        StateFarm,
        [Description("Tricare")]
        Tricare,
        [Description("UnitedHealthCare")]
        UnitedHealthCare,
        [Description("USAA")]
        USAA,
        [Description("Wellpoint")]
        Wellpoint,
    }
}


