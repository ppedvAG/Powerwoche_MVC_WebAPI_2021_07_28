#pragma checksum "C:\Aktueller Kurs\Powerwoche_MVC_WebAPI_2021_07_28\Powerwoche_MVC_WebAPI\ASPNETCOREMVC_MovieStoreSample\Views\StateManagement\TempDataThirdSample.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "44e84372eec471bcaee49e0c1ce520e63a5a1fc9"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_StateManagement_TempDataThirdSample), @"mvc.1.0.view", @"/Views/StateManagement/TempDataThirdSample.cshtml")]
namespace AspNetCore
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#nullable restore
#line 1 "C:\Aktueller Kurs\Powerwoche_MVC_WebAPI_2021_07_28\Powerwoche_MVC_WebAPI\ASPNETCOREMVC_MovieStoreSample\Views\_ViewImports.cshtml"
using ASPNETCOREMVC_MovieStoreSample;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Aktueller Kurs\Powerwoche_MVC_WebAPI_2021_07_28\Powerwoche_MVC_WebAPI\ASPNETCOREMVC_MovieStoreSample\Views\_ViewImports.cshtml"
using ASPNETCOREMVC_MovieStoreSample.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"44e84372eec471bcaee49e0c1ce520e63a5a1fc9", @"/Views/StateManagement/TempDataThirdSample.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"c95e31a5bb760944ce3028900a3970c93227988b", @"/Views/_ViewImports.cshtml")]
    public class Views_StateManagement_TempDataThirdSample : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 2 "C:\Aktueller Kurs\Powerwoche_MVC_WebAPI_2021_07_28\Powerwoche_MVC_WebAPI\ASPNETCOREMVC_MovieStoreSample\Views\StateManagement\TempDataThirdSample.cshtml"
  
    ViewData["Title"] = "TempDataThirdSample";
    //string email = TempData["EmailAddress"].ToString();
    //int id = Convert.ToInt32(TempData["Id"]);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<h1>TempDataThirdSample</h1>\r\n\r\n");
            WriteLiteral("\r\n");
#nullable restore
#line 14 "C:\Aktueller Kurs\Powerwoche_MVC_WebAPI_2021_07_28\Powerwoche_MVC_WebAPI\ASPNETCOREMVC_MovieStoreSample\Views\StateManagement\TempDataThirdSample.cshtml"
Write(TempData.Peek("EmailAdress"));

#line default
#line hidden
#nullable disable
            WriteLiteral(";<!-- Ausgabe + Variable bleibt für einen weiteren Zugriff erhalten-->\r\n");
#nullable restore
#line 15 "C:\Aktueller Kurs\Powerwoche_MVC_WebAPI_2021_07_28\Powerwoche_MVC_WebAPI\ASPNETCOREMVC_MovieStoreSample\Views\StateManagement\TempDataThirdSample.cshtml"
Write(TempData.Peek("Id"));

#line default
#line hidden
#nullable disable
            WriteLiteral(";\r\n");
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591
