#pragma checksum "C:\Users\Snorlax\OneDrive\Desktop\Cuong\BaoCaoThucTap\TTTN\Views\Admin\ToyDetail.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "532b0a082965b1759249d5e91a6e2b4c1b6cbca2"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Admin_ToyDetail), @"mvc.1.0.view", @"/Views/Admin/ToyDetail.cshtml")]
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
#line 1 "C:\Users\Snorlax\OneDrive\Desktop\Cuong\BaoCaoThucTap\TTTN\Views\Admin\ToyDetail.cshtml"
using BT2MWG.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\Snorlax\OneDrive\Desktop\Cuong\BaoCaoThucTap\TTTN\Views\Admin\ToyDetail.cshtml"
using System.Globalization;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"532b0a082965b1759249d5e91a6e2b4c1b6cbca2", @"/Views/Admin/ToyDetail.cshtml")]
    #nullable restore
    public class Views_Admin_ToyDetail : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<BT2MWG.Models.DOCHOI>
    #nullable disable
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("rel", new global::Microsoft.AspNetCore.Html.HtmlString("icon"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("type", new global::Microsoft.AspNetCore.Html.HtmlString("image/png"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("sizes", new global::Microsoft.AspNetCore.Html.HtmlString("16x16"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("href", new global::Microsoft.AspNetCore.Html.HtmlString("~/plugins/images/favicon.png"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("href", new global::Microsoft.AspNetCore.Html.HtmlString("~/public/plugins/bower_components/chartist/dist/chartist.min.css"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("rel", new global::Microsoft.AspNetCore.Html.HtmlString("stylesheet"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_6 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("href", new global::Microsoft.AspNetCore.Html.HtmlString("~/public/plugins/bower_components/chartist-plugin-tooltips/dist/chartist-plugin-tooltip.css"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_7 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("href", new global::Microsoft.AspNetCore.Html.HtmlString("~/public/css/style.min.css"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_8 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("href", new global::Microsoft.AspNetCore.Html.HtmlString("~/public/css/admin/toydetail.css"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_9 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/public/js/admin/toydetail.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.HeadTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper;
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.BodyTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 5 "C:\Users\Snorlax\OneDrive\Desktop\Cuong\BaoCaoThucTap\TTTN\Views\Admin\ToyDetail.cshtml"
  
    var count = 0;
    var dbo = new db();

    var gia = dbo.layGiaTheoMaSanPham(@Model.MaDoChoi).Gia;
    var listAnh = dbo.layTatCaAnhTheoDoChoi(@Model.MaDoChoi);
    var listDanhMuc = dbo.layDanhMucTheoDoChoi(@Model.MaDoChoi);
    CultureInfo cul = CultureInfo.GetCultureInfo("vi-VN");
    string giaOld = gia.ToString("#,###", cul.NumberFormat);
    //viết thêm hàm lấy đồ chơi để lấy tên đồ chơi (lấy theo id)

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("head", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "532b0a082965b1759249d5e91a6e2b4c1b6cbca27633", async() => {
                WriteLiteral("\r\n    <script src=\"https://code.jquery.com/jquery-3.6.0.js\"\r\n            integrity=\"sha256-H+K7U5CnXl1h5ywQfKtSj8PCmoN9aaq30gDh27Xc0jk=\"\r\n            crossorigin=\"anonymous\"></script>\r\n    <meta charset=\"utf-8\">\r\n    <!-- Favicon icon -->\r\n    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("link", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "532b0a082965b1759249d5e91a6e2b4c1b6cbca28151", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n    <!-- Custom CSS -->\r\n    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("link", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "532b0a082965b1759249d5e91a6e2b4c1b6cbca29531", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_4);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_5);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n\r\n    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("link", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "532b0a082965b1759249d5e91a6e2b4c1b6cbca210714", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_5);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_6);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n    <!-- Custom CSS -->\r\n    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("link", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "532b0a082965b1759249d5e91a6e2b4c1b6cbca211921", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_7);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_5);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("link", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "532b0a082965b1759249d5e91a6e2b4c1b6cbca213101", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_8);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_5);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n\r\n    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "532b0a082965b1759249d5e91a6e2b4c1b6cbca214285", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_9);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n\r\n");
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.HeadTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("body", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "532b0a082965b1759249d5e91a6e2b4c1b6cbca216097", async() => {
                WriteLiteral("\r\n\r\n    <div id=\"main-wrapper\" data-layout=\"vertical\" data-navbarbg=\"skin5\" data-sidebartype=\"full\"\r\n         data-sidebar-position=\"absolute\" data-header-position=\"absolute\" data-boxed-layout=\"full\">\r\n\r\n        ");
#nullable restore
#line 41 "C:\Users\Snorlax\OneDrive\Desktop\Cuong\BaoCaoThucTap\TTTN\Views\Admin\ToyDetail.cshtml"
   Write(await Html.PartialAsync("/Views/Common/Partial/Topbar Header.cshtml"));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n\r\n        ");
#nullable restore
#line 43 "C:\Users\Snorlax\OneDrive\Desktop\Cuong\BaoCaoThucTap\TTTN\Views\Admin\ToyDetail.cshtml"
   Write(await Html.PartialAsync("/Views/Common/Partial/Left Sidebar.cshtml"));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n        <div class=\"page-wrapper\">\r\n            <br />\r\n            <label>Nhân viên nhập</label>\r\n            <input id=\"emppName\" type=\"button\"");
                BeginWriteAttribute("value", " value=\"", 1857, "\"", 1865, 0);
                EndWriteAttribute();
                WriteLiteral(" readonly disabled>\r\n");
                WriteLiteral("            <br />\r\n            <br />\r\n            <label>Tên đồ chơi</label>\r\n            <input id=\"toyName\" type=\"text\"");
                BeginWriteAttribute("value", " value=\"", 2095, "\"", 2119, 1);
#nullable restore
#line 52 "C:\Users\Snorlax\OneDrive\Desktop\Cuong\BaoCaoThucTap\TTTN\Views\Admin\ToyDetail.cshtml"
WriteAttributeValue("", 2103, Model.TenDoChoi, 2103, 16, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(" />\r\n            <br />\r\n            <br />\r\n            <label>Nhà cung cấp</label>\r\n            <input id=\"toySuppliers\" type=\"text\"");
                BeginWriteAttribute("value", " value=\"", 2254, "\"", 2288, 1);
#nullable restore
#line 56 "C:\Users\Snorlax\OneDrive\Desktop\Cuong\BaoCaoThucTap\TTTN\Views\Admin\ToyDetail.cshtml"
WriteAttributeValue("", 2262, Model.NHACUNGCAP.TENNHACC, 2262, 26, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(" readonly disabled />\r\n            <br />\r\n            <br />\r\n            <label>Hãng đồ chơi</label>\r\n            <input id=\"toyBrand\" type=\"text\"");
                BeginWriteAttribute("value", " value=\"", 2437, "\"", 2476, 1);
#nullable restore
#line 60 "C:\Users\Snorlax\OneDrive\Desktop\Cuong\BaoCaoThucTap\TTTN\Views\Admin\ToyDetail.cshtml"
WriteAttributeValue("", 2445, Model.HANGDOCHOI.TENHANGDOCHOI, 2445, 31, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(" readonly disabled />\r\n            <br />\r\n            <br />\r\n            <label>Giá đồ chơi</label>\r\n            <input id=\"toyPrice\" type=\"text\"");
                BeginWriteAttribute("value", " value=\"", 2624, "\"", 2639, 1);
#nullable restore
#line 64 "C:\Users\Snorlax\OneDrive\Desktop\Cuong\BaoCaoThucTap\TTTN\Views\Admin\ToyDetail.cshtml"
WriteAttributeValue("", 2632, giaOld, 2632, 7, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(" />₫\r\n            <br />\r\n            <br />\r\n            <label>Danh mục đồ chơi</label>\r\n            <div class=\"cate-section\">\r\n");
#nullable restore
#line 69 "C:\Users\Snorlax\OneDrive\Desktop\Cuong\BaoCaoThucTap\TTTN\Views\Admin\ToyDetail.cshtml"
                 foreach (var cate in listDanhMuc)
                {

#line default
#line hidden
#nullable disable
                WriteLiteral("                    <input type=\"text\" data-id=\"");
#nullable restore
#line 71 "C:\Users\Snorlax\OneDrive\Desktop\Cuong\BaoCaoThucTap\TTTN\Views\Admin\ToyDetail.cshtml"
                                           Write(cate.ID);

#line default
#line hidden
#nullable disable
                WriteLiteral("\"");
                BeginWriteAttribute("value", " value=\"", 2899, "\"", 2917, 1);
#nullable restore
#line 71 "C:\Users\Snorlax\OneDrive\Desktop\Cuong\BaoCaoThucTap\TTTN\Views\Admin\ToyDetail.cshtml"
WriteAttributeValue("", 2907, cate.Name, 2907, 10, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(" />\r\n                    <span></span>\r\n");
#nullable restore
#line 73 "C:\Users\Snorlax\OneDrive\Desktop\Cuong\BaoCaoThucTap\TTTN\Views\Admin\ToyDetail.cshtml"
                }

#line default
#line hidden
#nullable disable
                WriteLiteral("            </div>\r\n            <br />\r\n            <br />\r\n            <label>Ảnh</label>\r\n\r\n            <div class=\"img-section\">\r\n");
#nullable restore
#line 80 "C:\Users\Snorlax\OneDrive\Desktop\Cuong\BaoCaoThucTap\TTTN\Views\Admin\ToyDetail.cshtml"
                 foreach (var item in listAnh)
                {
                    count++;
                    string classnameInput = "inputFileToLoad" + @count;
                    string classnameImg = "imgTest" + @count;

                    

#line default
#line hidden
#nullable disable
                WriteLiteral("<div class=\"img\">\r\n                        <img");
                BeginWriteAttribute("class", " class=\"", 3412, "\"", 3441, 2);
#nullable restore
#line 87 "C:\Users\Snorlax\OneDrive\Desktop\Cuong\BaoCaoThucTap\TTTN\Views\Admin\ToyDetail.cshtml"
WriteAttributeValue("", 3420, classnameImg, 3420, 13, false);

#line default
#line hidden
#nullable disable
                WriteAttributeValue(" ", 3433, "img-box", 3434, 8, true);
                EndWriteAttribute();
                BeginWriteAttribute("src", " src=\"", 3442, "\"", 3461, 1);
#nullable restore
#line 87 "C:\Users\Snorlax\OneDrive\Desktop\Cuong\BaoCaoThucTap\TTTN\Views\Admin\ToyDetail.cshtml"
WriteAttributeValue("", 3448, item.HinhAnh, 3448, 13, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(" />\r\n                        <input");
                BeginWriteAttribute("class", " class=\"", 3497, "\"", 3520, 1);
#nullable restore
#line 88 "C:\Users\Snorlax\OneDrive\Desktop\Cuong\BaoCaoThucTap\TTTN\Views\Admin\ToyDetail.cshtml"
WriteAttributeValue("", 3505, classnameInput, 3505, 15, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(" type=\"file\"");
                BeginWriteAttribute("onchange", " onchange=\"", 3533, "\"", 3599, 5);
                WriteAttributeValue("", 3544, "encodeImageFileAsURL(\'", 3544, 22, true);
#nullable restore
#line 88 "C:\Users\Snorlax\OneDrive\Desktop\Cuong\BaoCaoThucTap\TTTN\Views\Admin\ToyDetail.cshtml"
WriteAttributeValue("", 3566, classnameInput, 3566, 15, false);

#line default
#line hidden
#nullable disable
                WriteAttributeValue("", 3581, "\',\'", 3581, 3, true);
#nullable restore
#line 88 "C:\Users\Snorlax\OneDrive\Desktop\Cuong\BaoCaoThucTap\TTTN\Views\Admin\ToyDetail.cshtml"
WriteAttributeValue("", 3584, classnameImg, 3584, 13, false);

#line default
#line hidden
#nullable disable
                WriteAttributeValue("", 3597, "\')", 3597, 2, true);
                EndWriteAttribute();
                WriteLiteral(" />\r\n\r\n                    </div>\r\n");
#nullable restore
#line 91 "C:\Users\Snorlax\OneDrive\Desktop\Cuong\BaoCaoThucTap\TTTN\Views\Admin\ToyDetail.cshtml"
                }

#line default
#line hidden
#nullable disable
                WriteLiteral(@"            </div>
            <br />
            <br />
            <br />
            <button id=""save-toy"">Lưu</button>
        </div>

        <footer class=""footer text-center"">
            2021 © Ample Admin brought to you by <a href=""https://www.wrappixel.com/"">wrappixel.com</a>
        </footer>

    </div>

    </div>

    <script src=""plugins/bower_components/jquery/dist/jquery.min.js""></script>
    <!-- Bootstrap tether Core JavaScript -->
    <script src=""bootstrap/dist/js/bootstrap.bundle.min.js""></script>
    <script src=""js/app-style-switcher.js""></script>
    <script src=""plugins/bower_components/jquery-sparkline/jquery.sparkline.min.js""></script>
    <!--Wave Effects -->
    <script src=""js/waves.js""></script>
    <!--Menu sidebar -->
    <script src=""js/sidebarmenu.js""></script>
    <!--Custom JavaScript -->
    <script src=""js/custom.js""></script>
    <!--This page JavaScript -->
    <!--chartis chart-->

");
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.BodyTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<BT2MWG.Models.DOCHOI> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591