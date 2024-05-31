using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kutya_desktop.Data
{
    public enum Dataset
    {
        [Description("Állat")]
        Animals,
        [Description("Gazda")]
        Owners,
        [Description("Kutya fajták")]
        Breeds,
        [Description("Kórlapok")]
        MedicalRecords,
    }
}
