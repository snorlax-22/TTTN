#pragma checksum "C:\Users\Snorlax\OneDrive\Desktop\Cuong\MWG\BT2\BT2MWG\Views\Shared\_OthersToy.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "ea0a921f502bb621d3999d16c4161cbf25fa4ca5"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared__OthersToy), @"mvc.1.0.view", @"/Views/Shared/_OthersToy.cshtml")]
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
#line 6 "C:\Users\Snorlax\OneDrive\Desktop\Cuong\MWG\BT2\BT2MWG\Views\Shared\_OthersToy.cshtml"
using System.Globalization;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"ea0a921f502bb621d3999d16c4161cbf25fa4ca5", @"/Views/Shared/_OthersToy.cshtml")]
    #nullable restore
    public class Views_Shared__OthersToy : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<List<BT2MWG.Models.Product>>
    #nullable disable
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("<div class=\"others-toy\">\r\n");
            WriteLiteral("    \n");
#nullable restore
#line 14 "C:\Users\Snorlax\OneDrive\Desktop\Cuong\MWG\BT2\BT2MWG\Views\Shared\_OthersToy.cshtml"
     foreach (var item in @Model.Take(6))
    {
        

#line default
#line hidden
#nullable disable
#nullable restore
#line 16 "C:\Users\Snorlax\OneDrive\Desktop\Cuong\MWG\BT2\BT2MWG\Views\Shared\_OthersToy.cshtml"
   Write(await Component.InvokeAsync("ToyBoxes",item.ProductID));

#line default
#line hidden
#nullable disable
#nullable restore
#line 16 "C:\Users\Snorlax\OneDrive\Desktop\Cuong\MWG\BT2\BT2MWG\Views\Shared\_OthersToy.cshtml"
                                                               
    }

#line default
#line hidden
#nullable disable
            WriteLiteral("</div>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<List<BT2MWG.Models.Product>> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591
