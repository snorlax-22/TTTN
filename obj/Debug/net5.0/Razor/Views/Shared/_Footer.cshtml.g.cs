#pragma checksum "C:\Users\Snorlax\OneDrive\Desktop\Cuong\MWG\BT2\BT2MWG\Views\Shared\_Footer.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "f6f3184c543168c27be16a596c9e02745e9246f1"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared__Footer), @"mvc.1.0.view", @"/Views/Shared/_Footer.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"f6f3184c543168c27be16a596c9e02745e9246f1", @"/Views/Shared/_Footer.cshtml")]
    #nullable restore
    public class Views_Shared__Footer : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<List<BT2MWG.Models.Product>>
    #nullable disable
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("href", new global::Microsoft.AspNetCore.Html.HtmlString("~/public/css/style.css"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("rel", new global::Microsoft.AspNetCore.Html.HtmlString("stylesheet"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("type", new global::Microsoft.AspNetCore.Html.HtmlString("text/css"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("media", new global::Microsoft.AspNetCore.Html.HtmlString("screen"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("runat", new global::Microsoft.AspNetCore.Html.HtmlString("server"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("href", new global::Microsoft.AspNetCore.Html.HtmlString("~/public/css/_Footer.css"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_6 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/public/js/slider.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_7 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/public/js/productController.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_8 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("href", new global::Microsoft.AspNetCore.Html.HtmlString("~/public/css/_Header.css"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
#nullable restore
#line 5 "C:\Users\Snorlax\OneDrive\Desktop\Cuong\MWG\BT2\BT2MWG\Views\Shared\_Footer.cshtml"
  
    //int i = 0;
    string i = "";
    //String i = (String)Url.ActionContext.RouteData.Values["id"];
    int j = 0;
    if((String)Url.ActionContext.RouteData.Values["id"]==null)
    {
        i = "0";
    }
    else
    {
        i = (String)Url.ActionContext.RouteData.Values["id"]; 
    }
    j = Int32.Parse(i);
    


    string name = Model[j].Name;
    string image = Model[j].Image[0];
    decimal price = Model[j].Price;
    int productId = Model[j].ProductID;

   
    

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<!DOCTYPE html>\r\n<html lang=\"en\">\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("head", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "f6f3184c543168c27be16a596c9e02745e9246f16841", async() => {
                WriteLiteral(@"
    <script src=""https://cdnjs.cloudflare.com/ajax/libs/jquery/3.4.1/jquery.js"" integrity=""sha512-sJa5KWq3F99QOeijUOm9O+BgDgVtzrWBBagZtjlW7F3I47NO1OaNJvbut+9KOPmjNr4Wb3blU4vQiQdi+Zk6wg=="" crossorigin=""anonymous"" referrerpolicy=""no-referrer""></script>
    <script src=""https://cdnjs.cloudflare.com/ajax/libs/OwlCarousel2/2.3.4/owl.carousel.js"" integrity=""sha512-gY25nC63ddE0LcLPhxUJGFxa2GoIyA5FLym4UJqHDEMHjp8RET6Zn/SHo1sltt3WuVtqfyxECP38/daUc/WVEA=="" crossorigin=""anonymous"" referrerpolicy=""no-referrer""></script>
    <link rel=""stylesheet"" href=""https://cdnjs.cloudflare.com/ajax/libs/OwlCarousel2/2.3.4/assets/owl.carousel.min.css"" integrity=""sha512-tS3S5qG0BlhnQROyJXvNjeEM4UpMXHrQfTGmbQ1gKmelCxlSEBUaxhRBj/EFTzpbP4RVSrpEikbmdJobCvhE3g=="" crossorigin=""anonymous"" referrerpolicy=""no-referrer"" />
    <link rel=""stylesheet"" href=""https://cdnjs.cloudflare.com/ajax/libs/OwlCarousel2/2.3.4/assets/owl.carousel.css"" integrity=""sha512-UTNP5BXLIptsaj5WdKFrkFov94lDx+eBvbKyoe1YAfjeRPC+gT5kyZ10kOHCfNZqEui1sxmqvodNUx3KbuYI/A=");
                WriteLiteral(@"="" crossorigin=""anonymous"" referrerpolicy=""no-referrer"" />
    <script src=""https://cdnjs.cloudflare.com/ajax/libs/OwlCarousel2/2.3.4/owl.carousel.min.js"" integrity=""sha512-bPs7Ae6pVvhOSiIcyUClR7/q2OAsRiovw4vAkX+zJbw3ShAeeqezq50RIIcIURq7Oa20rW2n2q+fyXBNcU9lrw=="" crossorigin=""anonymous"" referrerpolicy=""no-referrer""></script>
    <link href=""https://fonts.googleapis.com/icon?family=Material+Icons"" rel=""stylesheet"">
    <meta charset=""UTF-8"">
    <meta http-equiv=""X-UA-Compatible"" content=""IE=edge"">
    <link rel=""stylesheet"" href=""https://fonts.googleapis.com/css2?family=Material+Symbols+Outlined:opsz,wght,FILL,GRAD@20..48,100..700,0..1,-50..200"" />
    <meta name=""viewport"" content=""width=device-width, initial-scale=1.0"">
    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("link", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "f6f3184c543168c27be16a596c9e02745e9246f18960", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_4);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("link", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "f6f3184c543168c27be16a596c9e02745e9246f110399", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_5);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_4);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "f6f3184c543168c27be16a596c9e02745e9246f111840", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_6);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "f6f3184c543168c27be16a596c9e02745e9246f112940", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_7);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n    <title>");
#nullable restore
#line 48 "C:\Users\Snorlax\OneDrive\Desktop\Cuong\MWG\BT2\BT2MWG\Views\Shared\_Footer.cshtml"
      Write(Model[j].Name);

#line default
#line hidden
#nullable disable
                WriteLiteral("</title>\r\n    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("link", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "f6f3184c543168c27be16a596c9e02745e9246f114291", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_8);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_4);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n   \r\n");
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
            WriteLiteral("\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("body", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "f6f3184c543168c27be16a596c9e02745e9246f116443", async() => {
                WriteLiteral("\r\n    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "f6f3184c543168c27be16a596c9e02745e9246f116706", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_7);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral(@"
    <div class=""header"">

    <section style=""height:54px"" class=""header-search-section"">
        <a href=""/"" class=""header-logo"">
                <i class=""icon-logo-newsversion""></i>
        </a>
        <form class=""header-search"">
            <input type=""text"" id=""keyword"" placeholder=""Tìm sản phẩm, nhóm hàng, hãng..."">
            <div class=""clear-search"">
                <i class=""icon-clear-search""></i>
            </div>
            <button type=""submit"" class=""submit-search"">
                <i class=""icon-search""></i>
            </button>
            <div class=""search-show"">
                <div class=""search-result"">
");
                WriteLiteral(@"                </div>
            </div>
        </form>
        <div class=""boxright"">
            <a href=""/cart/"" class=""header__cart"">
                <div class=""header__cart-icon"">
                    <i class=""icon-cart""></i>
                    <div class=""number""></div>
                </div>
                <div class=""header__cart-money"">
                    Giỏ hàng
                    <strong style=""display: none;""></strong>
                </div>
            </a>
            <div class=""add-cart"">
                <p class=""add-cart-txt""><i class=""icon-done""></i>Đã thêm sản phẩm</p>
                <a href=""/cart/"" class=""add-cart-btn"">Xem giỏ hàng</a>
            </div>
          
            <a href=""tel:1900866874"" class=""header__hotline"">
                Hotline (7h30 - 22h00)
                <br>
                <span>1900 866 874</span>
            </a>
            <a href=""/me-va-be"" class=""txtlink-right"">
                CẨM NANG<br>MẸ VÀ BÉ
            </a>
  ");
                WriteLiteral("      </div>\r\n\r\n       \r\n    </section>\r\n</div>\r\n    ");
#nullable restore
#line 121 "C:\Users\Snorlax\OneDrive\Desktop\Cuong\MWG\BT2\BT2MWG\Views\Shared\_Footer.cshtml"
Write(RenderBody());

#line default
#line hidden
#nullable disable
                WriteLiteral(@"
    <div class=""commitment"">
        <ul>
            <li>
                <div class=""li-icon"">
                    <i class=""icon-chinhhang""></i>
                </div>
                <div class=""li-content"">
                    <p><span>100% sản phẩm chính hãng</span><br>hơn 100 thương hiệu nổi tiếng</p>
                </div>
            </li>
            <li>
                <div class=""li-icon"">
                    <i class=""icon-doi1""></i>
                </div>
                <div class=""li-content"">
                    <p><span>1 Đổi 1 trong vòng 1 tháng</span><span class=""li-content-note"">(Tuỳ sản phẩm)</span><br>Tại 49 cửa hàng trên toàn quốc</p>
                    <a href=""/bao-hanh-doi-tra"" class=""txt-link"">Xem chi tiết</a>
                </div>
            </li>
            <li>
                <div class=""li-icon"">
                    <i class=""icon-mpgiaohang""></i>
                </div>
                <div class=""li-content"">
                    <p><span>Miễn ph");
                WriteLiteral(@"í giao hàng</span><br>Cho đơn từ 500.000đ trong 10km đầu tiên </p>
                    <a href=""/chinh-sach-giao-hang"" class=""txt-link"">Xem chi tiết</a>
                </div>
            </li>
        </ul>
    </div>
    <div class=""footer__logo"">
        <p class=""footer__logo-hd"">Ghé thăm các website khác cùng tập đoàn MWG</p>
        <ul class=""footer__logo-list"">
            <li>
                <a rel=""nofollow"" href=""https://www.avasport.com/"" target=""_blank"">
                    <i class=""iconlogo-sport""></i>
                </a>
            </li>
            <li>
                <a rel=""nofollow"" href=""https://www.avafashion.com/"" target=""_blank"">
                    <i class=""iconlogo-fashion""></i>
                </a>
            </li>
            <li>
                <a rel=""nofollow"" href=""https://www.thegioididong.com/avaji"" target=""_blank"">
                    <i class=""iconlogo-ji""></i>
                </a>
            </li>
            <li>
                <a rel=""no");
                WriteLiteral(@"follow"" href=""https://www.dienmayxanh.com/xe-dap"" target=""_blank"">
                    <i class=""iconlogo-cycle""></i>
                </a>
            </li>
            <li>
                <a rel=""nofollow"" href=""https://www.topzone.vn/"" target=""_blank"">
                    <i class=""iconlogo-topzone""></i>
                </a>
            </li>
            <li>
                <a rel=""nofollow"" href=""https://www.bachhoaxanh.com/"" target=""_blank"">
                    <i class=""iconlogo-bachhoaxanh""></i>
                </a>
            </li>
            <li>
                <a rel=""nofollow"" href=""https://www.thegioididong.com/"" target=""_blank"">
                    <i class=""iconlogo-thegioididong""></i>
                </a>
            </li>
            <li>
                <a rel=""nofollow"" href=""https://www.dienmayxanh.com/"" target=""_blank"">
                    <i class=""iconlogo-dienmayxanh""></i>
                </a>
            </li>
            <li>
                <a rel=""nofoll");
                WriteLiteral("ow\" href=\"https://www.nhathuocankhang.com/\" target=\"_blank\">\r\n                    <i class=\"iconlogo-ankhang\"></i>\r\n                </a>\r\n            </li>\r\n        </ul>\r\n    </div>\r\n");
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
            WriteLiteral("\r\n</html>");
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
