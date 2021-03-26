using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NDS.LIB
{
[Serializable]
public class LIBtblOrgNatureofBussiness
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
private Int32 _natureid;
public Int32 natureid
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
}


[Serializable]
public class LIBtblOrgNatureofBussinessListing : List<LIBtblOrgNatureofBussiness>
{

}
}
