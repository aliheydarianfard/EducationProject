#pragma checksum "F:\My Appliction\Web\EducationProject\EductionWebSite\Views\Shared\Components\Header\Default.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "42f713cf78f6b9b878020ee1499f11ac1598f8a0"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared_Components_Header_Default), @"mvc.1.0.view", @"/Views/Shared/Components/Header/Default.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Shared/Components/Header/Default.cshtml", typeof(AspNetCore.Views_Shared_Components_Header_Default))]
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
#line 1 "F:\My Appliction\Web\EducationProject\EductionWebSite\Views\_ViewImports.cshtml"
using EductionWeb;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"42f713cf78f6b9b878020ee1499f11ac1598f8a0", @"/Views/Shared/Components/Header/Default.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"08faf392d63bee30d178a260a553910c23cc88e0", @"/Views/_ViewImports.cshtml")]
    public class Views_Shared_Components_Header_Default : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Eduction.Service.DTOs.TopMenu.TopMenu>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(47, 2183, true);
            WriteLiteral(@"<header>
    <div class=""header-area "">
        <div class=""header-top_area"">
            <div class=""container-fluid"">
                <div class=""row"">
                    <div class=""col-lg-12"">
                        <div class=""header_top_wrap d-flex justify-content-between align-items-center"">
                            <div class=""text_wrap"">
                                <p><span style=""font-family:'Times New Roman', Times, serif"">ObjectGroup98@gmail.com</span></p>
                            </div>
                            <div class=""text_wrap"">
                                <p><a href=""#""> <i class=""fa fa-user align-self-cente""></i>ورود</a><a href=""#""><i class=""fa fa-user-plus align-self-center""></i>ثبت نام</a></p>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <div id=""sticky-header"" class=""main-header-area"">
            <div class=""container-fluid"">
         ");
            WriteLiteral(@"       <div class=""row"">
                    <div class=""col-lg-12"">
                        <div class=""header_wrap d-flex justify-content-between align-items-center"">
                            <div class=""header_left"">
                                <div class=""logo"">
                                    <a href=""/home/index"">
                                        <img id=""Logimg"" style=""width:180px;height:80px"" src=""/img/logo.png"" alt="""">
                                    </a>
                                </div>
                            </div>
                            <div class=""header_right d-flex align-items-center"">
                                <div class=""main-menu  d-none d-lg-block"">
                                    <nav>
                                        <ul id=""navigation"">
                                            <li><a href=""index.html"">خانه</a></li>
                                            <li class=""fa fa-angle-down"">
                           ");
            WriteLiteral("                     <a href=\"Courses.html\">دوره های آموزشی</a>\r\n                                                <ul class=\"submenu\">\r\n");
            EndContext();
#line 40 "F:\My Appliction\Web\EducationProject\EductionWebSite\Views\Shared\Components\Header\Default.cshtml"
                                                     foreach (var item in Model.ListCategory)
                                                    {

#line default
#line hidden
            BeginContext(2380, 72, true);
            WriteLiteral("                                                        <li><a href=\"#\">");
            EndContext();
            BeginContext(2453, 17, false);
#line 42 "F:\My Appliction\Web\EducationProject\EductionWebSite\Views\Shared\Components\Header\Default.cshtml"
                                                                   Write(item.CategoryName);

#line default
#line hidden
            EndContext();
            BeginContext(2470, 11, true);
            WriteLiteral("</a></li>\r\n");
            EndContext();
#line 43 "F:\My Appliction\Web\EducationProject\EductionWebSite\Views\Shared\Components\Header\Default.cshtml"
                                                    }

#line default
#line hidden
            BeginContext(2536, 941, true);
            WriteLiteral(@"
                                                </ul>
                                            </li>
                                            <li>
                                                <a href=""#"">وبلاگ</a>
                                            </li>

                                            <li><a href=""contact.html"">ارتباط با ما</a></li>
                                        </ul>
                                    </nav>
                                </div>

                            </div>
                        </div>
                    </div>
                    <div class=""col-12"">
                        <div class=""mobile_menu d-block d-lg-none""></div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</header>
<script>
    $(""#Logimg"").hover(function () {
        $(this).fadeOut(200).fadeIn();
    });

</script>");
            EndContext();
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Eduction.Service.DTOs.TopMenu.TopMenu> Html { get; private set; }
    }
}
#pragma warning restore 1591
