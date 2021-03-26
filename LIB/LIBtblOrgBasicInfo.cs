using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NDS.LIB
{
[Serializable]
public class LIBtblOrgBasicInfo
{
private Int32 _id;
public Int32 id
{
get;
set;
}
private String _username;
public String username
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
private String _phone;
public String phone
{
get;
set;
}
private String _designation;
public String designation
{
get;
set;
}
private String _OrgName;
public String OrgName
{
get;
set;
}
private String _industry;
public String industry
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
public class LIBtblOrgBasicInfoListing : List<LIBtblOrgBasicInfo>
{

}
}
