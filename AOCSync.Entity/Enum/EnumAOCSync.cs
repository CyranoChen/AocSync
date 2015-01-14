using System;
using System.Collections.Generic;
using System.Text;

namespace AOCSync.Entity.AOCEnum
{
    public enum EnumAOCSync
    {
        PVG,
        SHA,
    }

    public enum EnumDataBaseSource
    {
        CC,
        FQS
    }

    /// <summary>
    /// DataBase Control Type
    /// </summary>
    public enum EnumDBCtrlType
    {
        INSERT,
        UPDATE
    }

    /// <summary>
    /// Working Type
    /// </summary>
    public enum EnumSyncWorkType
    {
        ITV,
        DAY
    }
}
