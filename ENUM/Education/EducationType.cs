using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ENUM.Education
{
    public enum EducationType
    {
        [Description("Associate Degree")]
        AssociateDegree = 1,
        [Description("Bachelor Degree")]
        BachelorDegree,
        [Description("High School")]
        HighSchool,
        [Description("Master Degree")]
        MasterDegree,
        [Description("Other")]
        Other,
        [Description("Some College")]
        SomeCollege,
    }
}
