#pragma checksum "C:\Users\Snorlax\OneDrive\Desktop\Cuong\BT2MWG\Views\Product\Partial\_ItemSearch.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "5af584ffbc396735e51d6387118800c849093ec7"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Product_Partial__ItemSearch), @"mvc.1.0.view", @"/Views/Product/Partial/_ItemSearch.cshtml")]
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
#line 1 "C:\Users\Snorlax\OneDrive\Desktop\Cuong\BT2MWG\Views\Product\Partial\_ItemSearch.cshtml"
using BT2MWG.Helpers;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\Snorlax\OneDrive\Desktop\Cuong\BT2MWG\Views\Product\Partial\_ItemSearch.cshtml"
using BT2MWG.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"5af584ffbc396735e51d6387118800c849093ec7", @"/Views/Product/Partial/_ItemSearch.cshtml")]
    public class Views_Product_Partial__ItemSearch : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<List<DOCHOI>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
            WriteLiteral("\r\n<ul>\r\n");
#nullable restore
#line 7 "C:\Users\Snorlax\OneDrive\Desktop\Cuong\BT2MWG\Views\Product\Partial\_ItemSearch.cshtml"
     foreach (var item in Model)
    {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <li>\r\n            <a");
            BeginWriteAttribute("href", " href=\"", 145, "\"", 182, 2);
            WriteAttributeValue("", 152, "/product/detail/", 152, 16, true);
#nullable restore
#line 10 "C:\Users\Snorlax\OneDrive\Desktop\Cuong\BT2MWG\Views\Product\Partial\_ItemSearch.cshtml"
WriteAttributeValue("", 168, item.MaDoChoi, 168, 14, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">\r\n                <div class=\"img\">\r\n                    <img");
            BeginWriteAttribute("src", " src=\"", 245, "\"", 291, 1);
#nullable restore
#line 12 "C:\Users\Snorlax\OneDrive\Desktop\Cuong\BT2MWG\Views\Product\Partial\_ItemSearch.cshtml"
WriteAttributeValue("", 251, item.DSHINHANH.FirstOrDefault().HinhAnh, 251, 40, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" class=\"ls-is-cached lazyloaded\"");
            BeginWriteAttribute("alt", " alt=\"", 324, "\"", 330, 0);
            EndWriteAttribute();
            WriteLiteral(">\r\n                </div>\r\n                <div class=\"ct\">\r\n                    <h3>");
#nullable restore
#line 15 "C:\Users\Snorlax\OneDrive\Desktop\Cuong\BT2MWG\Views\Product\Partial\_ItemSearch.cshtml"
                   Write(item.TenDoChoi);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h3>\r\n                    <div class=\"price\">\r\n");
#nullable restore
#line 17 "C:\Users\Snorlax\OneDrive\Desktop\Cuong\BT2MWG\Views\Product\Partial\_ItemSearch.cshtml"
                          
                            decimal pricecurrent = item.ThayDoiGia.Gia - (item.ThayDoiGia.Gia * item.KHUYENMAI.CTKM.PTGiamGia/100);
                        

#line default
#line hidden
#nullable disable
#nullable restore
#line 20 "C:\Users\Snorlax\OneDrive\Desktop\Cuong\BT2MWG\Views\Product\Partial\_ItemSearch.cshtml"
                          
                            if (@item.KHUYENMAI.CTKM.PTGiamGia > 0)
                            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                <strong class=\"price-current\">");
#nullable restore
#line 23 "C:\Users\Snorlax\OneDrive\Desktop\Cuong\BT2MWG\Views\Product\Partial\_ItemSearch.cshtml"
                                                         Write(pricecurrent.ToVnd());

#line default
#line hidden
#nullable disable
            WriteLiteral("</strong>\r\n                                <span class=\"price-old\">");
#nullable restore
#line 24 "C:\Users\Snorlax\OneDrive\Desktop\Cuong\BT2MWG\Views\Product\Partial\_ItemSearch.cshtml"
                                                   Write(item.ThayDoiGia.Gia.ToVnd());

#line default
#line hidden
#nullable disable
            WriteLiteral("</span>\r\n                                <span class=\"price-percent\">");
#nullable restore
#line 25 "C:\Users\Snorlax\OneDrive\Desktop\Cuong\BT2MWG\Views\Product\Partial\_ItemSearch.cshtml"
                                                       Write(item.KHUYENMAI.CTKM.PTGiamGia);

#line default
#line hidden
#nullable disable
            WriteLiteral("%</span>\r\n");
#nullable restore
#line 26 "C:\Users\Snorlax\OneDrive\Desktop\Cuong\BT2MWG\Views\Product\Partial\_ItemSearch.cshtml"
                            }
                            else
                            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                <strong class=\"price-current\">");
#nullable restore
#line 29 "C:\Users\Snorlax\OneDrive\Desktop\Cuong\BT2MWG\Views\Product\Partial\_ItemSearch.cshtml"
                                                         Write(pricecurrent.ToVnd());

#line default
#line hidden
#nullable disable
            WriteLiteral("</strong>\r\n");
#nullable restore
#line 30 "C:\Users\Snorlax\OneDrive\Desktop\Cuong\BT2MWG\Views\Product\Partial\_ItemSearch.cshtml"
                            }
                        

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </div>\r\n                </div>\r\n            </a>\r\n        </li>\r\n");
#nullable restore
#line 37 "C:\Users\Snorlax\OneDrive\Desktop\Cuong\BT2MWG\Views\Product\Partial\_ItemSearch.cshtml"
    }

#line default
#line hidden
#nullable disable
            WriteLiteral("</ul>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<List<DOCHOI>> Html { get; private set; }
    }
}
#pragma warning restore 1591