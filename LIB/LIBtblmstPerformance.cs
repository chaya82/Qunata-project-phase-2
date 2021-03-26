using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NDS.LIB
{
[Serializable]
public class LIBtblmstPerformance
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
private String _LatestPerformance;
public String LatestPerformance
{
get;
set;
}
private Int32 _PerLevel;
public Int32 PerLevel
{
get;
set;
}
}


[Serializable]
public class LIBtblmstPerformanceListing : List<LIBtblmstPerformance>
{

}
}
