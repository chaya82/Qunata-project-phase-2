using System;
using System.Collections.Generic;
using System.Text;

namespace MyCLS
{
    #region EMessageType are the name of the object use in the complete project
    [Serializable()]
    public enum EMessageType : int
    {
        Overtime = 1,
        payperiodtype = 2,
        Payperiodday = 3,
        Payperiodtimeslot = 4,
        payperioddays = 5,
        ColorCode = 6,
        PayType = 7,
        YesNo = 8
    }//end EMessageType
    #endregion EMessageType are the name of the object use in the complete project

    #region EStatus of the Action Perform
    [Serializable()]
    public enum EStatus : int
    {
        Failure,
        Success,
        DatabaseNotFound,
        Exception,
        RecordNotFound,
        Duplicate
    }//end EStatus
    #endregion EStatus of the Action Perform

    #region enum of EXMLContextTypes
    [Serializable()]
    public enum EXMLContextTypes : int
    {
        ClientDBConnection = 1,
        SearchInfo = 2
    }
    #endregion

    #region enum of Continet Types
    [Serializable()]
    public enum ContinetTypes : int
    {
        Australia = 1,
        Africa = 2,
        Asia = 3,
        SouthAmerica = 4,
        NorthAmerica = 5,
        Europe = 6,
        Antarctica = 7
    }
    #endregion
}