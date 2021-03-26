using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyCLS
{
    public class MultiRowXML
    {

        #region "Insert Multiple Rows"

        //*****CODE TO USE THIS FUNCTIONALITY*****

        //MyCLS.MultiRowXML.XMLItemListManyCols MyXMLItemListManyCols = new MyCLS.MultiRowXML.XMLItemListManyCols();    //BEFORE LOOP - OBJECT INITIALIZATION
        //MyXMLItemListManyCols.RowBegin("Invoice");
        //MyXMLItemListManyCols.AddItem("ItemNo", dgvItems.Rows(i).Cells("ItemNo").Value);
        //MyXMLItemListManyCols.AddItem("ItemDesc", dgvItems.Rows(i).Cells("ItemDesc").Value);
        //MyXMLItemListManyCols.RowEnd("Invoice");
        //MyXMLItemListManyCols.ToString().Replace("&", "&amp;");          //AFTER LOOP    //USE THIS AS FINAL STRING TO BE SENT TO STORED PROCEDURE
        
        //######################################################################################################

        //*****STORED PROCEDURE CODE*********MODIFY ACCORDINGLY*************
            //ALTER PROCEDURE [dbo].[SP_InsertInvoiceD]
            //    @XMLDOC varchar(MAX),	
            //    @AUDTUSER date,
            //    @IID int
            //AS BEGIN 
            //    declare @xml_handle int 
            //    --prepare the XML Document by executing a system stored procedure	
            //    exec sp_xml_preparedocument @xml_handle OUTPUT, @XMLDOC 	
	
            //    INSERT INTO InvoiceD ([IID],[AUDTDATE])
            //    SELECT [IID]=@IID,[AUDTDATE]=getdate(),[AUDTUSER]=@AUDTUSER,ItemNo,ItemDesc
            //        FROM
            //            OPENXML(@xml_handle, '/Rows/Invoice', 1)
            //                With
            //                        (
            //                            [ItemNo]		varchar(500)	'ItemNo',
            //                            [ItemDesc]	varchar(500)	'ItemDesc'
            //                        )

            //        IF @@ERROR <> 0
            //            BEGIN
            //                --ROLLBACK TRANSACTION
            //                RETURN -9
            //            END

            //    exec sp_xml_removedocument @xml_handle		
					
            //    Return @@ERROR
            //END
        //******KIND OF STRING TO BE PASSED TO SP*****
            //<cars><car><Name>BMW</Name><Color>Red</Color></car><car><Name>Audi</Name><Color>Green</Color></car></cars>
        //*******************************************************************        
        //######################################################################################################

        public class XMLItemList
        {

            private System.Text.StringBuilder sb;
            public XMLItemList()
            {
                sb = new System.Text.StringBuilder();
                //sb.Append("<items>" + "\n");
                sb.Append("<items>");
            }

            public void AddItem(string Item)
            {
                //sb.AppendFormat("<item id={0}{1}{2}></item>{3}",  "'", Item, "'", "\n");
                sb.AppendFormat("<item id={0}{1}{2}></item>", "'", Item, "'");
            }

            public override string ToString()
            {
                //sb.Append("</items>" + "\n");
                sb.Append("</items>");
                return sb.ToString();
            }
        }


        public class XMLItemListManyCols
        {

            private System.Text.StringBuilder sb;
            public XMLItemListManyCols()
            {
                sb = new System.Text.StringBuilder();
                //sb.Append("<Rows>" + "\n");
                sb.Append("<Rows>");
            }

            public void RowBegin(string RowName)
            {
                //<cars><car><Name>BMW</Name><Color>Red</Color></car><car><Name>Audi</Name><Color>Green</Color></car></cars>
                //sb.AppendFormat("<{0}>{1}", RowName, "\n");
                sb.AppendFormat("<{0}>", RowName);
            }

            public void AddItem(string ColName, string Item)
            {
                //<cars><car><Name>BMW</Name><Color>Red</Color></car><car><Name>Audi</Name><Color>Green</Color></car></cars>
                //sb.AppendFormat("<{0}>{1}</{0}>{2}", ColName, Item, "\n");
                sb.AppendFormat("<{0}>{1}</{0}>", ColName, Item);
            }

            public void RowEnd(string RowName)
            {
                //<cars><car><Name>BMW</Name><Color>Red</Color></car><car><Name>Audi</Name><Color>Green</Color></car></cars>
                //sb.AppendFormat("</{0}>{1}", RowName, "\n");
                sb.AppendFormat("</{0}>", RowName);
            }

            public override string ToString()
            {
                //sb.Append("</Rows>" + "\n");
                sb.Append("</Rows>");
                return sb.ToString();
            }
        }
        #endregion

    }
}
