#pragma checksum "C:\Users\Snorlax\OneDrive\Desktop\Cuong\BaoCaoThucTap\TTTN\Views\Home\SignUp.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "90d606d06d58c8755c8eb69ab48a7285ad8dee73"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_SignUp), @"mvc.1.0.view", @"/Views/Home/SignUp.cshtml")]
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
#line 1 "C:\Users\Snorlax\OneDrive\Desktop\Cuong\BaoCaoThucTap\TTTN\Views\Home\SignUp.cshtml"
using BT2MWG.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\Snorlax\OneDrive\Desktop\Cuong\BaoCaoThucTap\TTTN\Views\Home\SignUp.cshtml"
using BT2MWG.ViewModel;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\Snorlax\OneDrive\Desktop\Cuong\BaoCaoThucTap\TTTN\Views\Home\SignUp.cshtml"
using System.Globalization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\Users\Snorlax\OneDrive\Desktop\Cuong\BaoCaoThucTap\TTTN\Views\Home\SignUp.cshtml"
using Microsoft.AspNetCore.Http;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"90d606d06d58c8755c8eb69ab48a7285ad8dee73", @"/Views/Home/SignUp.cshtml")]
    #nullable restore
    public class Views_Home_SignUp : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    #nullable disable
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("href", new global::Microsoft.AspNetCore.Html.HtmlString("~/public/css/cart/cart.css"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("rel", new global::Microsoft.AspNetCore.Html.HtmlString("stylesheet"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/public/js/cart/client.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
            WriteLiteral("\r\n");
#nullable restore
#line 6 "C:\Users\Snorlax\OneDrive\Desktop\Cuong\BaoCaoThucTap\TTTN\Views\Home\SignUp.cshtml"
  
    Layout = "~/Views/Shared/_Footer.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("link", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "90d606d06d58c8755c8eb69ab48a7285ad8dee734707", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@"

<div id=""app"" class=""bluekids"">
    <section>
        
        <div class=""middleCart"">
            
            <div class=""infor-customer"">
                <h2>Đăng ký tài khoản</h2>
                <form class=""form-customer"">
                    <div class=""form-check form-check-inline"">
                        <input class=""form-check-input"" type=""radio"" name=""inlineRadioOptions"" id=""inlineRadio1"" value=""option1"">
                        <label class=""form-check-label"" for=""inlineRadio1"">Anh</label>
                    </div>
                    <div class=""form-check form-check-inline"">
                        <input class=""form-check-input"" type=""radio"" name=""inlineRadioOptions"" id=""inlineRadio2"" value=""option2"">
                        <label class=""form-check-label"" for=""inlineRadio2"">Chị</label>
                    </div>
                    <div class=""fillinform"">
                        <div class=""fillname"">
                            <input placeholder=""Họ và Tên"" maxleng");
            WriteLiteral(@"th=""50"" id=""cusName"" name=""cusName"" required=""required"" class="" untouched pristine required"">
                            <label for=""cusName"" class=""form-label""></label>
                        </div>
                        <div class=""fillname phoneNumber"">
                            <input placeholder=""Số điện thoại"" type=""tel"" maxlength=""10"" id=""cusPhone"" name=""cusPhone"" required=""required"" class=""untouched pristine required phoneNumber__input"">
                            <label for=""cusPhone"" class=""form-label"">

                            </label>
                        </div>
                    </div>
                    <h4>Thông tin địa chỉ</h4>
                    <div class=""fillinform"">
                        <div class=""fillname"">
                            <input placeholder=""Email"" maxlength=""50"" id=""cusEmail"" name=""cusName"" required=""required"" class="" untouched pristine required"">
                            <label for=""cusName"" class=""form-label""></label>
              ");
            WriteLiteral(@"          </div>
                        <div class=""fillname"">
                            <input placeholder=""Địa chỉ"" maxlength=""50"" id=""cusAdd"" name=""cusName"" required=""required"" class="" untouched pristine required"">
                            <label for=""cusName"" class=""form-label""></label>
                        </div>
                        <div class=""fillname"">
                            <input placeholder=""Mã số thuế"" maxlength=""50"" id=""cusMST"" name=""cusName"" required=""required"" class=""  untouched pristine required"">
                            <label for=""cusName"" class=""form-label""></label>
                        </div>
                        <div class=""fillname"">
                            <input placeholder=""CMND/CCCD"" maxlength=""50"" id=""cusID"" name=""cusID"" required=""required"" class="" untouched pristine required"">
                            <label for=""cusName"" class=""form-label""></label>
                        </div>
                    </div>
                    <h4>Thô");
            WriteLiteral(@"ng tin tài khoản</h4>
                    <div class=""fillinform"">
                        <div class=""fillname"">
                            <input placeholder=""Tài khoản"" maxlength=""50"" id=""cusAccount"" name=""cusName"" required=""required"" class="" untouched pristine required"">
                            <label for=""cusName"" class=""form-label""></label>
                        </div>
                        <div class=""fillname"">
                            <input placeholder=""Mật khẩu"" maxlength=""50"" id=""cusPass"" name=""cusName"" type=""password"" required=""required"" class="" untouched pristine required"">
                            <label for=""cusName"" class=""form-label""></label>
                        </div>

                    </div>
                </form>
            </div>
            <div class=""finaltotal"">
                <button type=""button"" class=""submitorder"">
                    <b id=""signup"">ĐĂNG KÝ</b>
                </button>

            </div>
        </div>
    </section");
            WriteLiteral(">\r\n</div>\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "90d606d06d58c8755c8eb69ab48a7285ad8dee7310261", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n\r\n\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591
