#pragma checksum "C:\Users\Administrator\Documents\GitHub\net\Plagiarism_Checker\Plagiarism-Checker\Views\Teacher\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "f0f7fda05b7f6d1dc398640d6d8534be4ef6aab7"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Teacher_Index), @"mvc.1.0.view", @"/Views/Teacher/Index.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Teacher/Index.cshtml", typeof(AspNetCore.Views_Teacher_Index))]
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
#line 1 "C:\Users\Administrator\Documents\GitHub\net\Plagiarism_Checker\Plagiarism-Checker\Views\_ViewImports.cshtml"
using Plagiarism_Checker;

#line default
#line hidden
#line 2 "C:\Users\Administrator\Documents\GitHub\net\Plagiarism_Checker\Plagiarism-Checker\Views\_ViewImports.cshtml"
using Plagiarism_Checker.Models;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"f0f7fda05b7f6d1dc398640d6d8534be4ef6aab7", @"/Views/Teacher/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"4629291b9607b6f696e738bdc026a069f08427a2", @"/Views/_ViewImports.cshtml")]
    public class Views_Teacher_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Plagiarism_Checker.Models.Teacher.TeacherTasks>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(55, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 3 "C:\Users\Administrator\Documents\GitHub\net\Plagiarism_Checker\Plagiarism-Checker\Views\Teacher\Index.cshtml"
  
    Layout = "~/Views/Shared/_TeacherLayout.cshtml";

#line default
#line hidden
            BeginContext(118, 28, true);
            WriteLiteral("\r\n\r\n\r\n<h1>Головна</h1>\r\n<div");
            EndContext();
            BeginWriteAttribute("onclick", " onclick=\"", 146, "\"", 210, 3);
            WriteAttributeValue("", 156, "location.href=\'", 156, 15, true);
#line 10 "C:\Users\Administrator\Documents\GitHub\net\Plagiarism_Checker\Plagiarism-Checker\Views\Teacher\Index.cshtml"
WriteAttributeValue("", 171, Url.Action("ListSubjects", "Teacher"), 171, 38, false);

#line default
#line hidden
            WriteAttributeValue("", 209, "\'", 209, 1, true);
            EndWriteAttribute();
            BeginContext(211, 295, true);
            WriteLiteral(@" style=""min-height: 80px;
    background: #333333;
    justify-content: center;
    padding: 2em;"">
    <h2 style=""color: whitesmoke; cursor:pointer;"">ПЕРЕЛІК ДИСЦИПЛІН</h2>
</div>
<div class=""largeDarkDiv"" style=""flex-direction: column;margin: 5em;"">
    <h2>Найближчі самостійні:</h2>
");
            EndContext();
#line 18 "C:\Users\Administrator\Documents\GitHub\net\Plagiarism_Checker\Plagiarism-Checker\Views\Teacher\Index.cshtml"
     foreach (var item in Model.Tests)
    {

#line default
#line hidden
            BeginContext(553, 188, true);
            WriteLiteral("        <div style=\"width:80%;height:180px;margin-bottom:20px;border:solid;border-width:1px\">\r\n            <div style=\"background-color:#d8d8d8\">\r\n                <p style=\"color:#000000\">");
            EndContext();
            BeginContext(742, 21, false);
#line 22 "C:\Users\Administrator\Documents\GitHub\net\Plagiarism_Checker\Plagiarism-Checker\Views\Teacher\Index.cshtml"
                                    Write(item.NameOfDiscipline);

#line default
#line hidden
            EndContext();
            BeginContext(763, 79, true);
            WriteLiteral("</p>\r\n            </div>\r\n            <p style=\"color:#d8d8d8; font-size:13px\">");
            EndContext();
            BeginContext(843, 33, false);
#line 24 "C:\Users\Administrator\Documents\GitHub\net\Plagiarism_Checker\Plagiarism-Checker\Views\Teacher\Index.cshtml"
                                                Write(item.TaskAssignment.Requirenments);

#line default
#line hidden
            EndContext();
            BeginContext(876, 86, true);
            WriteLiteral("</p>\r\n            <p style=\"color:#555454; font-size:10px; justify-content:flex-end;\">");
            EndContext();
            BeginContext(963, 10, false);
#line 25 "C:\Users\Administrator\Documents\GitHub\net\Plagiarism_Checker\Plagiarism-Checker\Views\Teacher\Index.cshtml"
                                                                           Write(item.Group);

#line default
#line hidden
            EndContext();
            BeginContext(973, 3, true);
            WriteLiteral(" - ");
            EndContext();
            BeginContext(977, 9, false);
#line 25 "C:\Users\Administrator\Documents\GitHub\net\Plagiarism_Checker\Plagiarism-Checker\Views\Teacher\Index.cshtml"
                                                                                         Write(item.Time);

#line default
#line hidden
            EndContext();
            BeginContext(986, 67, true);
            WriteLiteral("</p>\r\n            <div style=\"clear:both;\"></div>\r\n        </div>\r\n");
            EndContext();
#line 28 "C:\Users\Administrator\Documents\GitHub\net\Plagiarism_Checker\Plagiarism-Checker\Views\Teacher\Index.cshtml"
    }

#line default
#line hidden
            BeginContext(1060, 7, true);
            WriteLiteral("<button");
            EndContext();
            BeginWriteAttribute("onclick", " onclick=\"", 1067, "\"", 1128, 3);
            WriteAttributeValue("", 1077, "location.href=\'", 1077, 15, true);
#line 29 "C:\Users\Administrator\Documents\GitHub\net\Plagiarism_Checker\Plagiarism-Checker\Views\Teacher\Index.cshtml"
WriteAttributeValue("", 1092, Url.Action("ListTests", "Teacher"), 1092, 35, false);

#line default
#line hidden
            WriteAttributeValue("", 1127, "\'", 1127, 1, true);
            EndWriteAttribute();
            BeginContext(1129, 100, true);
            WriteLiteral(" class=\"button2\">УСІ НАЙБЛИЖЧІ САМОСТІЙНІ</button>\r\n</div>\r\n<div style=\"display: flex\">\r\n    <button");
            EndContext();
            BeginWriteAttribute("onclick", " onclick=\"", 1229, "\"", 1293, 3);
            WriteAttributeValue("", 1239, "location.href=\'", 1239, 15, true);
#line 32 "C:\Users\Administrator\Documents\GitHub\net\Plagiarism_Checker\Plagiarism-Checker\Views\Teacher\Index.cshtml"
WriteAttributeValue("", 1254, Url.Action("ListHomework", "Teacher"), 1254, 38, false);

#line default
#line hidden
            WriteAttributeValue("", 1292, "\'", 1292, 1, true);
            EndWriteAttribute();
            BeginContext(1294, 65, true);
            WriteLiteral(" class=\"button2\">ПЕРЕГЛЯНУТИ ГОТОВІ ДОМАШНІ</button>\r\n    <button");
            EndContext();
            BeginWriteAttribute("onclick", " onclick=\"", 1359, "\"", 1426, 3);
            WriteAttributeValue("", 1369, "location.href=\'", 1369, 15, true);
#line 33 "C:\Users\Administrator\Documents\GitHub\net\Plagiarism_Checker\Plagiarism-Checker\Views\Teacher\Index.cshtml"
WriteAttributeValue("", 1384, Url.Action("ListSolvedTests", "Teacher"), 1384, 41, false);

#line default
#line hidden
            WriteAttributeValue("", 1425, "\'", 1425, 1, true);
            EndWriteAttribute();
            BeginContext(1427, 68, true);
            WriteLiteral(" class=\"button2\">ПЕРЕГЛЯНУТИ ГОТОВІ САМОСТІЙНІ</button>\r\n    <button");
            EndContext();
            BeginWriteAttribute("onclick", " onclick=\"", 1495, "\"", 1554, 3);
            WriteAttributeValue("", 1505, "location.href=\'", 1505, 15, true);
#line 34 "C:\Users\Administrator\Documents\GitHub\net\Plagiarism_Checker\Plagiarism-Checker\Views\Teacher\Index.cshtml"
WriteAttributeValue("", 1520, Url.Action("AddTask", "Teacher"), 1520, 33, false);

#line default
#line hidden
            WriteAttributeValue("", 1553, "\'", 1553, 1, true);
            EndWriteAttribute();
            BeginContext(1555, 85, true);
            WriteLiteral(" class=\"button2\">ДОДАТИ ДОМАШНЄ ЗАВДАННЯ/САМОСТІЙНУ РОБОТУ</button>\r\n</div>\r\n\r\n\r\n\r\n\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Plagiarism_Checker.Models.Teacher.TeacherTasks> Html { get; private set; }
    }
}
#pragma warning restore 1591
