#pragma checksum "/Users/ChengXiong/Documents/UWOClasses/ComputerScience/Software Engineer I/Project/CalendarApp/CalenderApp/SoftEng/Views/Home/Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "0632776600cb89310fd169325337cad88356b9fc"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_Index), @"mvc.1.0.view", @"/Views/Home/Index.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Home/Index.cshtml", typeof(AspNetCore.Views_Home_Index))]
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
#line 1 "/Users/ChengXiong/Documents/UWOClasses/ComputerScience/Software Engineer I/Project/CalendarApp/CalenderApp/SoftEng/Views/_ViewImports.cshtml"
using SoftEng;

#line default
#line hidden
#line 2 "/Users/ChengXiong/Documents/UWOClasses/ComputerScience/Software Engineer I/Project/CalendarApp/CalenderApp/SoftEng/Views/_ViewImports.cshtml"
using SoftEng.Models;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"0632776600cb89310fd169325337cad88356b9fc", @"/Views/Home/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"f57677b90addf52ae2317829f6a5f175cee9439f", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#line 1 "/Users/ChengXiong/Documents/UWOClasses/ComputerScience/Software Engineer I/Project/CalendarApp/CalenderApp/SoftEng/Views/Home/Index.cshtml"
  
    ViewData["Title"] = "Home Page";

#line default
#line hidden
            BeginContext(42, 714, true);
            WriteLiteral(@"
<div align=""center"">
    <div>
        <h1>Calendar Application</h1><br /><br />
    </div>
    <div>
        <label class=""textLabel"">Username:</label>
        <input class=""textBox"" type=""text"" id=""usernameText"" name=""Username""/><br /><br />
    </div>
    <div>
        <label class=""textLabel"">Password:</label>
        <input class=""textBox"" type=""text"" id=""passwordText"" name=""Password"" /><br /><br />
    </div>
    <div>
        <button type=""button"" id=""userLoginBtn"" name=""user"">User Login</button>
        <button type=""button"" id=""adminLoginBtn"" name=""admin"">Admin Login</button><br /><br />
    </div>
    <div>
        <button type=""button"" id=""registerBtn"">Register</button><br />
    </div>
</div>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591
