using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NDS.LIB
{
[Serializable]
public class LIBtblmstEmployee
{
private Int32 _ID;
public Int32 ID
{
get;
set;
}
private String _EmpID;
public String EmpID
{
get;
set;
}
private String _DOb;
public String DOb
{
get;
set;
}
private Int32 _Age;
public Int32 Age
{
get;
set;
}
private Int32 _OrgID;
public Int32 OrgID
{
    get;
    set;
}

private String _DOJ;
public String DOJ
{
get;
set;
}
private String _Gender;
public String Gender
{
get;
set;
}
private String _Dept;
public String Dept
{
get;
set;
}
private String _Desig;
public String Desig
{
get;
set;
}
private String _Grade;
public String Grade
{
get;
set;
}
private String _Managerid;
public String Managerid
{
get;
set;
}
private String _LatestPerformance;
public String LatestPerformance
{
get;
set;
}
private String _LastPromotion;
public String LastPromotion
{
get;
set;
}
private Decimal _Grosspay;
public Decimal Grosspay
{
get;
set;
}
private String _currency;
public String currency
{
get;
set;
}
private String _createdBy;
public String createdBy
{
get;
set;
}
private String _dt;
public String dt
{
get;
set;
}
private String _fYear;
public String fYear
{
get;
set;
}
private Boolean _Status;
public Boolean Status
{
    get;
    set;
}
}


[Serializable]
public class LIBtblmstEmployeeListing : List<LIBtblmstEmployee>
{

}
}
