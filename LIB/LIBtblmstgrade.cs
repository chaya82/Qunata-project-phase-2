using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NDS.LIB
{
[Serializable]
public class LIBtblmstgrade
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
private String _Grade;
public String Grade
{
get;
set;
}
private Int32 _GLevel;
public Int32 GLevel
{
get;
set;
}
}


[Serializable]
public class LIBtblmstgradeListing : List<LIBtblmstgrade>
{

}
}
