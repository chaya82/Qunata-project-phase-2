using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NDS.LIB
{
[Serializable]
public class LIBtblmstInstruction
{
private Int32 _ID;
public Int32 ID
{
get;
set;
}
private String _DOb_Age;
public String DOb_Age
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
}


[Serializable]
public class LIBtblmstInstructionListing : List<LIBtblmstInstruction>
{

}
}
