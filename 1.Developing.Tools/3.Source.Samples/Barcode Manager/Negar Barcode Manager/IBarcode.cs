using System.Collections.Generic;

namespace Negar.BarcodeManager
{
    interface IBarcode
    {
        string Encoded_Value
        {
            get;
        }//Encoded_Value

        string RawData
        {
            get;
        }//Raw_Data

        List<string> Errors
        {
            get;
        }//Errors

    }//interface
}//namespace
