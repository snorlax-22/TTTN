#pragma checksum "C:\Users\Snorlax\OneDrive\Desktop\Cuong\BaoCaoThucTap\TTTN\Views\Admin\Partial\ListCart.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "9cd59eca81bf0393e4a0ef7955f72e02052ddc8d"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Admin_Partial_ListCart), @"mvc.1.0.view", @"/Views/Admin/Partial/ListCart.cshtml")]
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
#line 1 "C:\Users\Snorlax\OneDrive\Desktop\Cuong\BaoCaoThucTap\TTTN\Views\Admin\Partial\ListCart.cshtml"
using BT2MWG.ViewModel;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"9cd59eca81bf0393e4a0ef7955f72e02052ddc8d", @"/Views/Admin/Partial/ListCart.cshtml")]
    #nullable restore
    public class Views_Admin_Partial_ListCart : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<AdminPageViewModel>
    #nullable disable
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/public/js/admin/order.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        #pragma warning restore 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __backed__tagHelperScopeManager = null;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __tagHelperScopeManager
        {
            get
            {
                if (__backed__tagHelperScopeManager == null)
                {
                    __backed__tagHelperScopeManager = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager(StartTagHelperWritingScope, EndTagHelperWritingScope);
                }
                return __backed__tagHelperScopeManager;
            }
        }
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 3 "C:\Users\Snorlax\OneDrive\Desktop\Cuong\BaoCaoThucTap\TTTN\Views\Admin\Partial\ListCart.cshtml"
  
    var listNVGH = @Model.listNV.Where(x => x.MaNV != 4);
    int pageidx = 1;
    int count = 0;
    string clsHide = string.Empty;
    int pageSize = 9;
    int TotalPages = (int)Math.Ceiling(Model.listGioHang.Count / (double)pageSize);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"<style>
    .pagination {
        margin-left: 45%;
        display: inline-block;
    }

        .pagination a {
            color: black;
            float: left;
            padding: 10px 22px;
            text-decoration: none;
            transition: background-color .3s;
        }

            .pagination a.active {
                background-color: #2cabe3;
                color: white;
            }

            .pagination a:hover:not(.active) {
                background-color: #ddd;
            }
</style>
<table class=""table"" id=""cart_tab"">
    <tr>
        <th>Mã </th>
        <th>NV Duyệt</th>
        <th>NV Giao</th>
        <th>CMNDKH</th>
        <th>Thời Gian Giao</th>
        <th>Hóa Đơn</th>
        <th>Trạng Thái</th>
        <th>  </th>

    </tr>
");
#nullable restore
#line 46 "C:\Users\Snorlax\OneDrive\Desktop\Cuong\BaoCaoThucTap\TTTN\Views\Admin\Partial\ListCart.cshtml"
     foreach (var item in @Model.listGioHang)
    {
        count++;
        if (count > pageSize * pageidx)
        {
            pageidx++;
            clsHide = "hide";
        }

#line default
#line hidden
#nullable disable
            WriteLiteral("        <tr");
            BeginWriteAttribute("class", " class=\"", 1320, "\"", 1361, 4);
            WriteAttributeValue("", 1328, "itemrow", 1328, 7, true);
#nullable restore
#line 54 "C:\Users\Snorlax\OneDrive\Desktop\Cuong\BaoCaoThucTap\TTTN\Views\Admin\Partial\ListCart.cshtml"
WriteAttributeValue(" ", 1335, clsHide, 1336, 8, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue(" ", 1344, "pageidx-", 1345, 9, true);
#nullable restore
#line 54 "C:\Users\Snorlax\OneDrive\Desktop\Cuong\BaoCaoThucTap\TTTN\Views\Admin\Partial\ListCart.cshtml"
WriteAttributeValue("", 1353, pageidx, 1353, 8, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" data-page=\"");
#nullable restore
#line 54 "C:\Users\Snorlax\OneDrive\Desktop\Cuong\BaoCaoThucTap\TTTN\Views\Admin\Partial\ListCart.cshtml"
                                                            Write(pageidx);

#line default
#line hidden
#nullable disable
            WriteLiteral("\">\r\n            <td><a class=\"ctgh\" data-id=\"");
#nullable restore
#line 55 "C:\Users\Snorlax\OneDrive\Desktop\Cuong\BaoCaoThucTap\TTTN\Views\Admin\Partial\ListCart.cshtml"
                                    Write(item.MaGioHang);

#line default
#line hidden
#nullable disable
            WriteLiteral("\" onclick=\"showPopup()\">");
#nullable restore
#line 55 "C:\Users\Snorlax\OneDrive\Desktop\Cuong\BaoCaoThucTap\TTTN\Views\Admin\Partial\ListCart.cshtml"
                                                                           Write(item.MaGioHang);

#line default
#line hidden
#nullable disable
            WriteLiteral("</a></td>\r\n            <td><label>");
#nullable restore
#line 56 "C:\Users\Snorlax\OneDrive\Desktop\Cuong\BaoCaoThucTap\TTTN\Views\Admin\Partial\ListCart.cshtml"
                  Write(item.NvDuyet.TenNV);

#line default
#line hidden
#nullable disable
            WriteLiteral("</label></td>\r\n            <td>\r\n                <label>\r\n");
#nullable restore
#line 59 "C:\Users\Snorlax\OneDrive\Desktop\Cuong\BaoCaoThucTap\TTTN\Views\Admin\Partial\ListCart.cshtml"
                     if (item.TrangThai.MaTrangThai == 1)
                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                        <select name=\"deliver\" id=\"deliver\">\r\n");
#nullable restore
#line 62 "C:\Users\Snorlax\OneDrive\Desktop\Cuong\BaoCaoThucTap\TTTN\Views\Admin\Partial\ListCart.cshtml"
                             foreach (var nv in listNVGH)
                            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                <option");
            BeginWriteAttribute("value", " value=\"", 1865, "\"", 1881, 1);
#nullable restore
#line 64 "C:\Users\Snorlax\OneDrive\Desktop\Cuong\BaoCaoThucTap\TTTN\Views\Admin\Partial\ListCart.cshtml"
WriteAttributeValue("", 1873, nv.MaNV, 1873, 8, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">");
#nullable restore
#line 64 "C:\Users\Snorlax\OneDrive\Desktop\Cuong\BaoCaoThucTap\TTTN\Views\Admin\Partial\ListCart.cshtml"
                                                    Write(nv.TenNV);

#line default
#line hidden
#nullable disable
            WriteLiteral("</option>\r\n");
#nullable restore
#line 65 "C:\Users\Snorlax\OneDrive\Desktop\Cuong\BaoCaoThucTap\TTTN\Views\Admin\Partial\ListCart.cshtml"
                            }

#line default
#line hidden
#nullable disable
            WriteLiteral("                        </select>\r\n");
#nullable restore
#line 67 "C:\Users\Snorlax\OneDrive\Desktop\Cuong\BaoCaoThucTap\TTTN\Views\Admin\Partial\ListCart.cshtml"
                    }
                    else
                    {
                        

#line default
#line hidden
#nullable disable
#nullable restore
#line 70 "C:\Users\Snorlax\OneDrive\Desktop\Cuong\BaoCaoThucTap\TTTN\Views\Admin\Partial\ListCart.cshtml"
                   Write(item.NvGiao.TenNV);

#line default
#line hidden
#nullable disable
#nullable restore
#line 70 "C:\Users\Snorlax\OneDrive\Desktop\Cuong\BaoCaoThucTap\TTTN\Views\Admin\Partial\ListCart.cshtml"
                                          
                    }

#line default
#line hidden
#nullable disable
            WriteLiteral("                </label>\r\n            </td>\r\n            <td><label>");
#nullable restore
#line 74 "C:\Users\Snorlax\OneDrive\Desktop\Cuong\BaoCaoThucTap\TTTN\Views\Admin\Partial\ListCart.cshtml"
                  Write(item.CMNDKH);

#line default
#line hidden
#nullable disable
            WriteLiteral("</label></td>\r\n            <td><label>");
#nullable restore
#line 75 "C:\Users\Snorlax\OneDrive\Desktop\Cuong\BaoCaoThucTap\TTTN\Views\Admin\Partial\ListCart.cshtml"
                  Write(item.NgayGiao);

#line default
#line hidden
#nullable disable
            WriteLiteral("</label></td>\r\n            <td>\r\n                <label>\r\n");
#nullable restore
#line 78 "C:\Users\Snorlax\OneDrive\Desktop\Cuong\BaoCaoThucTap\TTTN\Views\Admin\Partial\ListCart.cshtml"
                      
                        if (string.IsNullOrEmpty(item.MaHoaDon) && item.TrangThai.MaTrangThai == 2)
                        {

#line default
#line hidden
#nullable disable
            WriteLiteral("                            <button class=\"gotoprint\">In hóa đơn</button>\r\n");
#nullable restore
#line 82 "C:\Users\Snorlax\OneDrive\Desktop\Cuong\BaoCaoThucTap\TTTN\Views\Admin\Partial\ListCart.cshtml"
                        }
                        else
                        {
                            

#line default
#line hidden
#nullable disable
#nullable restore
#line 85 "C:\Users\Snorlax\OneDrive\Desktop\Cuong\BaoCaoThucTap\TTTN\Views\Admin\Partial\ListCart.cshtml"
                       Write(item.MaHoaDon);

#line default
#line hidden
#nullable disable
#nullable restore
#line 85 "C:\Users\Snorlax\OneDrive\Desktop\Cuong\BaoCaoThucTap\TTTN\Views\Admin\Partial\ListCart.cshtml"
                                          ;
                        }
                    

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n                </label>\r\n            </td>\r\n            <td><label>");
#nullable restore
#line 92 "C:\Users\Snorlax\OneDrive\Desktop\Cuong\BaoCaoThucTap\TTTN\Views\Admin\Partial\ListCart.cshtml"
                  Write(item.TrangThai.TenTrangThai);

#line default
#line hidden
#nullable disable
            WriteLiteral("</label></td>\r\n");
#nullable restore
#line 93 "C:\Users\Snorlax\OneDrive\Desktop\Cuong\BaoCaoThucTap\TTTN\Views\Admin\Partial\ListCart.cshtml"
              
                string btn = item.TrangThai.MaTrangThai == 1 ? "Duyệt" : "Hoàn thành";
                string clsBtn = btn == "Duyệt" ? "approve" : "complete";
            

#line default
#line hidden
#nullable disable
            WriteLiteral("            <td><a");
            BeginWriteAttribute("class", " class=\"", 3030, "\"", 3054, 2);
            WriteAttributeValue("", 3038, "edit-btn", 3038, 8, true);
#nullable restore
#line 97 "C:\Users\Snorlax\OneDrive\Desktop\Cuong\BaoCaoThucTap\TTTN\Views\Admin\Partial\ListCart.cshtml"
WriteAttributeValue(" ", 3046, clsBtn, 3047, 7, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" data-idnvduyet=\"");
#nullable restore
#line 97 "C:\Users\Snorlax\OneDrive\Desktop\Cuong\BaoCaoThucTap\TTTN\Views\Admin\Partial\ListCart.cshtml"
                                                       Write(Model.nv.MaNV);

#line default
#line hidden
#nullable disable
            WriteLiteral("\" data-btn=\"");
#nullable restore
#line 97 "C:\Users\Snorlax\OneDrive\Desktop\Cuong\BaoCaoThucTap\TTTN\Views\Admin\Partial\ListCart.cshtml"
                                                                                 Write(clsBtn);

#line default
#line hidden
#nullable disable
            WriteLiteral("\" data-id=\"");
#nullable restore
#line 97 "C:\Users\Snorlax\OneDrive\Desktop\Cuong\BaoCaoThucTap\TTTN\Views\Admin\Partial\ListCart.cshtml"
                                                                                                   Write(item.MaGioHang);

#line default
#line hidden
#nullable disable
            WriteLiteral("\">");
#nullable restore
#line 97 "C:\Users\Snorlax\OneDrive\Desktop\Cuong\BaoCaoThucTap\TTTN\Views\Admin\Partial\ListCart.cshtml"
                                                                                                                    Write(btn);

#line default
#line hidden
#nullable disable
            WriteLiteral("</a></td>\r\n        </tr>\r\n");
#nullable restore
#line 99 "C:\Users\Snorlax\OneDrive\Desktop\Cuong\BaoCaoThucTap\TTTN\Views\Admin\Partial\ListCart.cshtml"
    }

#line default
#line hidden
#nullable disable
            WriteLiteral("</table>\r\n\r\n<div class=\"pagination\">\r\n");
#nullable restore
#line 103 "C:\Users\Snorlax\OneDrive\Desktop\Cuong\BaoCaoThucTap\TTTN\Views\Admin\Partial\ListCart.cshtml"
     for (int i = 1; i <= TotalPages; i++)
    {
        string clsActive = i == 1 ? "active" : string.Empty;

#line default
#line hidden
#nullable disable
            WriteLiteral("        <a");
            BeginWriteAttribute("class", " class=\"", 3331, "\"", 3361, 2);
#nullable restore
#line 106 "C:\Users\Snorlax\OneDrive\Desktop\Cuong\BaoCaoThucTap\TTTN\Views\Admin\Partial\ListCart.cshtml"
WriteAttributeValue("", 3339, clsActive, 3339, 10, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue(" ", 3349, "page-button", 3350, 12, true);
            EndWriteAttribute();
            WriteLiteral(" data-page=\"");
#nullable restore
#line 106 "C:\Users\Snorlax\OneDrive\Desktop\Cuong\BaoCaoThucTap\TTTN\Views\Admin\Partial\ListCart.cshtml"
                                                Write(i);

#line default
#line hidden
#nullable disable
            WriteLiteral("\">");
#nullable restore
#line 106 "C:\Users\Snorlax\OneDrive\Desktop\Cuong\BaoCaoThucTap\TTTN\Views\Admin\Partial\ListCart.cshtml"
                                                    Write(i);

#line default
#line hidden
#nullable disable
            WriteLiteral("</a>\r\n");
#nullable restore
#line 107 "C:\Users\Snorlax\OneDrive\Desktop\Cuong\BaoCaoThucTap\TTTN\Views\Admin\Partial\ListCart.cshtml"
    }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</div>
<script>

    //paging
    $('.page-button').click(function() {
        var clsName = '.pageidx-' + $(this).data('page');

        $('.itemrow').addClass('hide');
        $(clsName).removeClass('hide');

        $('.page-button').removeClass('active');

        $(this).addClass('active');

    });
</script>
");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "9cd59eca81bf0393e4a0ef7955f72e02052ddc8d15979", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<AdminPageViewModel> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591
