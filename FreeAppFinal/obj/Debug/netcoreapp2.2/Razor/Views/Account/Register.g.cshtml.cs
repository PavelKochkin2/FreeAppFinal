#pragma checksum "C:\Users\p.kochkin\source\repos\FreeAppFinal\FreeAppFinal\Views\Account\Register.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "436105c648f616ae116d01ef72f2bd3a356a55ac"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Account_Register), @"mvc.1.0.view", @"/Views/Account/Register.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Account/Register.cshtml", typeof(AspNetCore.Views_Account_Register))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"436105c648f616ae116d01ef72f2bd3a356a55ac", @"/Views/Account/Register.cshtml")]
    public class Views_Account_Register : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<FreeAppFinal.ViewModels.RegisterModel>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(46, 898, true);
            WriteLiteral(@" 
<h2>Регистрация</h2>
 
<form asp-action=""Register"" asp-controller=""Account"" asp-anti-forgery=""true"">
    <div class=""validation"" asp-validation-summary=""ModelOnly"" />
    <div>
        <div>
            <label asp-for=""Email"">Введите Email</label><br />
            <input type=""text"" asp-for=""Email"" />
            <span asp-validation-for=""Email"" />
        </div>
        <div>
            <label asp-for=""Password"">Введите парольz</label><br />
            <input asp-for=""Password"" />
            <span asp-validation-for=""Password"" />
        </div>
        <div>
            <label asp-for=""ConfirmPassword"">Повторите пароль</label><br />
            <input asp-for=""ConfirmPassword"" />
            <span asp-validation-for=""ConfirmPassword"" />
        </div>
        <div>
            <input type=""submit"" value=""Региsстрация"" />
        </div>
    </div>
</form>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<FreeAppFinal.ViewModels.RegisterModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
