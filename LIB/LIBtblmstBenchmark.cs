using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NDS.LIB
{
[Serializable]
public class LIBtblmstBenchmark
{
private Int32 _id;
public Int32 id
{
get;
set;
}
private Int32 _industryid;
public Int32 industryid
{
get;
set;
}
private Decimal _bm1_1;
public Decimal bm1_1
{
get;
set;
}
private Decimal _bm1_2;
public Decimal bm1_2
{
get;
set;
}
private Decimal _bm2_1;
public Decimal bm2_1
{
get;
set;
}
private Decimal _bm2_2;
public Decimal bm2_2
{
get;
set;
}
private Decimal _bm3_1;
public Decimal bm3_1
{
get;
set;
}
private Decimal _bm3_2;
public Decimal bm3_2
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
private String _metric;
public String metric
{
    get;
    set;
}
}


[Serializable]
public class LIBtblmstBenchmarkListing : List<LIBtblmstBenchmark>
{

}
}
