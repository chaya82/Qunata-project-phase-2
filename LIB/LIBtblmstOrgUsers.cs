using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NDS.LIB
{
[Serializable]
public class LIBtblmstOrgUsers
{
private Int32 _id;
public Int32 id
{
get;
set;
}
private String _Name;
public String Name
{
get;
set;
}
private String _Email;
public String Email
{
get;
set;
}
private String _Phone;
public String Phone
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
}


[Serializable]
public class LIBtblmstOrgUsersListing : List<LIBtblmstOrgUsers>
{

}
}
