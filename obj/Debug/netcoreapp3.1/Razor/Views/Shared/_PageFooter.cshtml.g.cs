#pragma checksum "C:\Users\USER\source\repos\MalayanBank Online Banking\MalayanBank.OnlineBanking\Views\Shared\_PageFooter.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "8b0b2066b1627cf457668fc7f13cbfa74c5597e8"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared__PageFooter), @"mvc.1.0.view", @"/Views/Shared/_PageFooter.cshtml")]
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
#line 1 "C:\Users\USER\source\repos\MalayanBank Online Banking\MalayanBank.OnlineBanking\Views\_ViewImports.cshtml"
using MalayanBank.OnlineBanking;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\USER\source\repos\MalayanBank Online Banking\MalayanBank.OnlineBanking\Views\_ViewImports.cshtml"
using MalayanBank.OnlineBanking.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"8b0b2066b1627cf457668fc7f13cbfa74c5597e8", @"/Views/Shared/_PageFooter.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"462063a73f782a6c52d399f9addd7d8521a82ff5", @"/Views/_ViewImports.cshtml")]
    public class Views_Shared__PageFooter : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 1 "C:\Users\USER\source\repos\MalayanBank Online Banking\MalayanBank.OnlineBanking\Views\Shared\_PageFooter.cshtml"
 if (ViewBag.AppFooter?.Length > 0)
{

#line default
#line hidden
#nullable disable
            WriteLiteral("<footer class=\"page-footer\" role=\"contentinfo\">\r\n\t<div class=\"d-flex align-items-center flex-1 text-muted\">\r\n\t\t<span class=\"hidden-md-down fw-700\">");
#nullable restore
#line 5 "C:\Users\USER\source\repos\MalayanBank Online Banking\MalayanBank.OnlineBanking\Views\Shared\_PageFooter.cshtml"
                                       Write(Html.Raw(ViewBag.Copyright));

#line default
#line hidden
#nullable disable
            WriteLiteral("</span>\r\n\t</div>\r\n");
            WriteLiteral("</footer>\r\n");
#nullable restore
#line 16 "C:\Users\USER\source\repos\MalayanBank Online Banking\MalayanBank.OnlineBanking\Views\Shared\_PageFooter.cshtml"
}

#line default
#line hidden
#nullable disable
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
