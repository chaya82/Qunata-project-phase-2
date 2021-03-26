using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NDS.LIB
{
[Serializable]
public class LIBtblmstOrgInfo
{
private Int32 _id;
public Int32 id
{
get;
set;
}
private Int32 _orgid;
public Int32 orgid
{
get;
set;
}
private String _year;
public String year
{
get;
set;
}
private Decimal _turnover;
public Decimal turnover
{
get;
set;
}
private Decimal _HeadCount;
public Decimal HeadCount
{
get;
set;
}
private Decimal _Profit;
public Decimal Profit
{
get;
set;
}
private Decimal _WageBill;
public Decimal WageBill
{
get;
set;
}
private Decimal _Attrtion;
public Decimal Attrtion
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
private String _Currency;
public String Currency
{
    get;
    set;
}
}


[Serializable]
public class LIBtblmstOrgInfoListing : List<LIBtblmstOrgInfo>
{

}
}
