#pragma checksum "C:\Aktueller Kurs\Powerwoche_MVC_WebAPI_2021_07_28\Powerwoche_MVC_WebAPI\ASPNETCOREMVC_MovieStoreSample\Views\ShoppingPayment\Payment.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "7c3b0cb9d4f4ef7ce41db600865112c4f1fccb34"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_ShoppingPayment_Payment), @"mvc.1.0.view", @"/Views/ShoppingPayment/Payment.cshtml")]
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
#nullable restore
#line 1 "C:\Aktueller Kurs\Powerwoche_MVC_WebAPI_2021_07_28\Powerwoche_MVC_WebAPI\ASPNETCOREMVC_MovieStoreSample\Views\ShoppingPayment\Payment.cshtml"
using Microsoft.AspNetCore.Identity;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"7c3b0cb9d4f4ef7ce41db600865112c4f1fccb34", @"/Views/ShoppingPayment/Payment.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"c95e31a5bb760944ce3028900a3970c93227988b", @"/Views/_ViewImports.cshtml")]
    public class Views_ShoppingPayment_Payment : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
            WriteLiteral("\r\n");
#nullable restore
#line 6 "C:\Aktueller Kurs\Powerwoche_MVC_WebAPI_2021_07_28\Powerwoche_MVC_WebAPI\ASPNETCOREMVC_MovieStoreSample\Views\ShoppingPayment\Payment.cshtml"
  
    ViewData["Title"] = "Payment";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<h1>Payment</h1>\r\n\r\n\r\n\r\n");
#nullable restore
#line 14 "C:\Aktueller Kurs\Powerwoche_MVC_WebAPI_2021_07_28\Powerwoche_MVC_WebAPI\ASPNETCOREMVC_MovieStoreSample\Views\ShoppingPayment\Payment.cshtml"
 if (SignInManager.IsSignedIn(User))
{

#line default
#line hidden
#nullable disable
            WriteLiteral("    <p>PayPal</p>\r\n    <p>Sofortüberweisung</p>\r\n");
#nullable restore
#line 18 "C:\Aktueller Kurs\Powerwoche_MVC_WebAPI_2021_07_28\Powerwoche_MVC_WebAPI\ASPNETCOREMVC_MovieStoreSample\Views\ShoppingPayment\Payment.cshtml"
}
else
{

#line default
#line hidden
#nullable disable
            WriteLiteral("    <p>Sie sind nicht angemeldet</p>\r\n");
#nullable restore
#line 22 "C:\Aktueller Kurs\Powerwoche_MVC_WebAPI_2021_07_28\Powerwoche_MVC_WebAPI\ASPNETCOREMVC_MovieStoreSample\Views\ShoppingPayment\Payment.cshtml"
}

#line default
#line hidden
#nullable disable
            WriteLiteral("</ul>\r\n\r\n\r\n");
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public UserManager<IdentityUser> UserManager { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public SignInManager<IdentityUser> SignInManager { get; private set; }
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
