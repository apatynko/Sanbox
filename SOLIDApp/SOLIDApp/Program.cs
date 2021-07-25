using System;
using SRPLibrary.SRPWay;

namespace SOLIDApp
{
    class Program
    {
        static void Main(string[] args)
        {


            //
            // SRPLibrary
            //

            //SRPLibrary.NormalWay.NormalWayApp exampleNormalWay = new SRPLibrary.NormalWay.NormalWayApp();
            //exampleNormalWay.ShowExample();

            //SPRWayApp exampleSPRlWay = new SRPLibrary.SRPWay.SPRWayApp();
            //exampleSPRlWay.ShowExample();

            //
            // OCPLibrary
            //

            //OCPLibrary.NormalWay.NormalWayApp exampleNormalWayApp = new OCPLibrary.NormalWay.NormalWayApp();
            //exampleNormalWayApp.ShowExample();

            //OCPLibrary.OCPWay.OCPWayApp examplOCPWayApp = new OCPLibrary.OCPWay.OCPWayApp();
            //examplOCPWayApp.ShowExample();

            //
            // LSPLibrary
            //

            //LSPLibrary.NormalWay.NormalWayApp examplenormalWayApp = new LSPLibrary.NormalWay.NormalWayApp();
            //examplenormalWayApp.ShowExample();

            //LSPLibrary.LSPWay.LSPWayApp exampleLSPWayApp = new LSPLibrary.LSPWay.LSPWayApp();
            //exampleLSPWayApp.ShowExample();

            //
            // DIPLibrary
            //

            //DIPLibrary.NormalWay.NormalWayApp exampleNormalWayApp = new DIPLibrary.NormalWay.NormalWayApp();
            //exampleNormalWayApp.ShowExample();

            //DIPLibrary.DIPWay.DIPWayApp exampleDIPWayApp = new DIPLibrary.DIPWay.DIPWayApp();
            //exampleDIPWayApp.ShowExample();

            //
            // AutofacLibrary
            //

            //AutofacLibrary.NormalWay.NormalWayApp exampleNormalWayApp = new AutofacLibrary.NormalWay.NormalWayApp();
            //exampleNormalWayApp.ShowExample();

            AutofacLibrary.DIPWay.DIPWayApp exampleDIPWayApp = new AutofacLibrary.DIPWay.DIPWayApp();
            exampleDIPWayApp.ShowExample();
        }
    }
}
