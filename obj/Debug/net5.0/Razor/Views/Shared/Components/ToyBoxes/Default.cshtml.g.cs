#pragma checksum "C:\Users\Snorlax\OneDrive\Desktop\Cuong\MWG\BT2\BT2MWG\Views\Shared\Components\ToyBoxes\Default.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "a9f058f801622de237eb6a5354c7902af257e40e"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared_Components_ToyBoxes_Default), @"mvc.1.0.view", @"/Views/Shared/Components/ToyBoxes/Default.cshtml")]
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
#line 4 "C:\Users\Snorlax\OneDrive\Desktop\Cuong\MWG\BT2\BT2MWG\Views\Shared\Components\ToyBoxes\Default.cshtml"
using System.Globalization;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"a9f058f801622de237eb6a5354c7902af257e40e", @"/Views/Shared/Components/ToyBoxes/Default.cshtml")]
    #nullable restore
    public class Views_Shared_Components_ToyBoxes_Default : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<BT2MWG.Models.Product>
    #nullable disable
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 6 "C:\Users\Snorlax\OneDrive\Desktop\Cuong\MWG\BT2\BT2MWG\Views\Shared\Components\ToyBoxes\Default.cshtml"
  
    String i = (String)Url.ActionContext.RouteData.Values["id"];
    int j = Int32.Parse(i);

    CultureInfo cul = CultureInfo.GetCultureInfo("vi-VN");
    string af = Model.Price.ToString("#,###", cul.NumberFormat);

    decimal priceNew = Model.Price - (Model.Price * Model.Discount) / 100;

    string aff = priceNew.ToString("#,###", cul.NumberFormat);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n\r\n\r\n<div class=\"others-toy-item\">\r\n    <img");
            BeginWriteAttribute("src", " src=", 604, "", 624, 1);
#nullable restore
#line 22 "C:\Users\Snorlax\OneDrive\Desktop\Cuong\MWG\BT2\BT2MWG\Views\Shared\Components\ToyBoxes\Default.cshtml"
WriteAttributeValue("", 609, Model.Image[0], 609, 15, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            BeginWriteAttribute("alt", " alt=\"", 624, "\"", 630, 0);
            EndWriteAttribute();
            WriteLiteral(" />\r\n    <h3>\r\n");
            WriteLiteral("        ");
#nullable restore
#line 25 "C:\Users\Snorlax\OneDrive\Desktop\Cuong\MWG\BT2\BT2MWG\Views\Shared\Components\ToyBoxes\Default.cshtml"
   Write(Model.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n    </h3>\r\n    <p class=\"others-toy-item-price\">\r\n");
            WriteLiteral("        ");
#nullable restore
#line 29 "C:\Users\Snorlax\OneDrive\Desktop\Cuong\MWG\BT2\BT2MWG\Views\Shared\Components\ToyBoxes\Default.cshtml"
   Write(aff);

#line default
#line hidden
#nullable disable
            WriteLiteral("₫\r\n    </p>\r\n    <span class=\"others-toy-item-old-price\">\r\n");
            WriteLiteral("        ");
#nullable restore
#line 33 "C:\Users\Snorlax\OneDrive\Desktop\Cuong\MWG\BT2\BT2MWG\Views\Shared\Components\ToyBoxes\Default.cshtml"
   Write(af);

#line default
#line hidden
#nullable disable
            WriteLiteral("₫\r\n    </span>\r\n    <span class=\"others-toy-item-percent\">\r\n        ");
#nullable restore
#line 36 "C:\Users\Snorlax\OneDrive\Desktop\Cuong\MWG\BT2\BT2MWG\Views\Shared\Components\ToyBoxes\Default.cshtml"
   Write(Model.Discount);

#line default
#line hidden
#nullable disable
            WriteLiteral("%\r\n    </span>\r\n\r\n    <div class=\"others-toy-item-buy\">\r\n        <p class=\"txt\">Chọn mua</p>\r\n    </div>\r\n</div>\r\n");
        }
        #pragma warning restore 1998
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<BT2MWG.Models.Product> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591
