#pragma checksum "C:\Users\USER\source\repos\MalayanBank Online Banking\MalayanBank.OnlineBanking\Views\Shared\_ComposeLayout.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "12847b889a384ad871b74754fb130245234c06e7"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared__ComposeLayout), @"mvc.1.0.view", @"/Views/Shared/_ComposeLayout.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"12847b889a384ad871b74754fb130245234c06e7", @"/Views/Shared/_ComposeLayout.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"462063a73f782a6c52d399f9addd7d8521a82ff5", @"/Views/_ViewImports.cshtml")]
    public class Views_Shared__ComposeLayout : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("name", "_Signature", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.PartialTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral(@"<div class=""px-3"">
	<input id=""message-to"" type=""text"" placeholder=""Recipients"" class=""form-control border-top-0 border-left-0 border-right-0 px-0 rounded-0 fs-md mt-2 pr-5"" tabindex=""2"">
	<a href=""javascript:void(0)"" class=""position-absolute pos-right pos-top mt-3 mr-4"" data-action=""toggle"" data-class=""d-block"" data-target=""#message-to-cc"" data-focus=""message-to-cc"" data-toggle=""tooltip"" data-original-title=""Add Cc recipients"" data-placement=""bottom"">Cc</a>
	<input id=""message-to-cc"" type=""text"" placeholder=""Cc"" class=""form-control border-top-0 border-left-0 border-right-0 px-0 rounded-0 fs-md mt-2 d-none"" tabindex=""3"">
	<input type=""text"" placeholder=""Subject"" class=""form-control border-top-0 border-left-0 border-right-0 px-0 rounded-0 fs-md mt-2"" tabindex=""4"">
</div>
<div class=""flex-1"" style=""overflow-y: auto;"">
	<div id='fake_textarea' class=""form-control rounded-0 w-100 h-100 border-0 py-3"" contenteditable tabindex=""5"">
		<br>
		<br>
		");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("partial", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "12847b889a384ad871b74754fb130245234c06e74544", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.PartialTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper.Name = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@"
	</div>
</div>
<div class=""px-3 py-4 d-flex flex-row align-items-center flex-wrap flex-shrink-0"">
	<a href=""javascript:void(0);"" class=""btn btn-info mr-3"">Send</a>
	<a href=""javascript:void(0);"" class=""btn btn-icon fs-xl mr-1"" data-toggle=""tooltip"" data-original-title=""Formatting options"" data-placement=""top"">
		<i class=""fas fa-font color-fusion-300""></i>
	</a>
	<a href=""javascript:void(0);"" class=""btn btn-icon fs-xl mr-1"" data-toggle=""tooltip"" data-original-title=""Attach files"" data-placement=""top"">
		<i class=""fas fa-paperclip color-fusion-300""></i>
	</a>
	<a href=""javascript:void(0);"" class=""btn btn-icon fs-xl mr-1"" data-toggle=""tooltip"" data-original-title=""Insert photo"" data-placement=""top"">
		<i class=""fas fa-camera color-fusion-300""></i>
	</a>
	<div class=""ml-auto"">
		<a href=""javascript:void(0);"" class=""btn btn-icon fs-xl"" data-toggle=""tooltip"" data-original-title=""Disregard draft"" data-placement=""top"">
			<i class=""fas fa-trash color-fusion-300""></i>
		</a>
		<a href=""javascript:v");
            WriteLiteral("oid(0);\" class=\"btn btn-icon fs-xl width-1\" data-toggle=\"tooltip\" data-original-title=\"More options\" data-placement=\"top\">\r\n\t\t\t<i class=\"fas fa-ellipsis-v-alt color-fusion-300\"></i>\r\n\t\t</a>\t\t\t\t\t\t\r\n\t</div>\r\n</div>");
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
