#pragma checksum "C:\Users\Administrator\Documents\GitHub\net\Plagiarism_Checker\Plagiarism-Checker\Views\Student\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "fe2635ceccdbb65daf725ff76c3a31dbb9b03e3e"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Student_Index), @"mvc.1.0.view", @"/Views/Student/Index.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Student/Index.cshtml", typeof(AspNetCore.Views_Student_Index))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"fe2635ceccdbb65daf725ff76c3a31dbb9b03e3e", @"/Views/Student/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"4629291b9607b6f696e738bdc026a069f08427a2", @"/Views/_ViewImports.cshtml")]
    public class Views_Student_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Plagiarism_Checker.Models.Student.StudentTasks>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(55, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 3 "C:\Users\Administrator\Documents\GitHub\net\Plagiarism_Checker\Plagiarism-Checker\Views\Student\Index.cshtml"
  
    ViewData["Title"] = "Головна";
    Layout = "~/Views/Shared/_StudentLayout.cshtml";

#line default
#line hidden
            BeginContext(154, 24, true);
            WriteLiteral("\r\n<h1>Головна</h1>\r\n<div");
            EndContext();
            BeginWriteAttribute("onclick", " onclick=\"", 178, "\"", 242, 3);
            WriteAttributeValue("", 188, "location.href=\'", 188, 15, true);
#line 9 "C:\Users\Administrator\Documents\GitHub\net\Plagiarism_Checker\Plagiarism-Checker\Views\Student\Index.cshtml"
WriteAttributeValue("", 203, Url.Action("ListSubjects", "Student"), 203, 38, false);

#line default
#line hidden
            WriteAttributeValue("", 241, "\'", 241, 1, true);
            EndWriteAttribute();
            BeginContext(243, 293, true);
            WriteLiteral(@" style=""min-height: 80px;
    background: #333333;
    justify-content: center;
    padding: 2em;"">
    <h2 style=""color: #000000; cursor:pointer;"" >ПЕРЕЛІК ДИСЦИПЛІН</h2>
</div>
<div class=""largeDarkDiv"" style=""flex-direction: column;margin: 5em;"">
    <h2>Найближчі самостійні:</h2>
");
            EndContext();
#line 17 "C:\Users\Administrator\Documents\GitHub\net\Plagiarism_Checker\Plagiarism-Checker\Views\Student\Index.cshtml"
     foreach (var item in Model.Tests)
    {

#line default
#line hidden
            BeginContext(583, 188, true);
            WriteLiteral("        <div style=\"width:80%;height:180px;margin-bottom:20px;border:solid;border-width:1px\">\r\n            <div style=\"background-color:#d8d8d8\">\r\n                <p style=\"color:#000000\">");
            EndContext();
            BeginContext(772, 21, false);
#line 21 "C:\Users\Administrator\Documents\GitHub\net\Plagiarism_Checker\Plagiarism-Checker\Views\Student\Index.cshtml"
                                    Write(item.NameOfDiscipline);

#line default
#line hidden
            EndContext();
            BeginContext(793, 79, true);
            WriteLiteral("</p>\r\n            </div>\r\n            <p style=\"color:#d8d8d8; font-size:13px\">");
            EndContext();
            BeginContext(873, 33, false);
#line 23 "C:\Users\Administrator\Documents\GitHub\net\Plagiarism_Checker\Plagiarism-Checker\Views\Student\Index.cshtml"
                                                Write(item.TaskAssignment.Requirenments);

#line default
#line hidden
            EndContext();
            BeginContext(906, 86, true);
            WriteLiteral("</p>\r\n            <p style=\"color:#555454; font-size:10px; justify-content:flex-end;\">");
            EndContext();
            BeginContext(993, 11, false);
#line 24 "C:\Users\Administrator\Documents\GitHub\net\Plagiarism_Checker\Plagiarism-Checker\Views\Student\Index.cshtml"
                                                                           Write(item.Lector);

#line default
#line hidden
            EndContext();
            BeginContext(1004, 3, true);
            WriteLiteral(" - ");
            EndContext();
            BeginContext(1008, 9, false);
#line 24 "C:\Users\Administrator\Documents\GitHub\net\Plagiarism_Checker\Plagiarism-Checker\Views\Student\Index.cshtml"
                                                                                          Write(item.Time);

#line default
#line hidden
            EndContext();
            BeginContext(1017, 202, true);
            WriteLiteral("</p>\r\n\r\n            <div style=\"display: flex;justify-content: center;margin-top:8px\">\r\n                <button style=\"font-size:6px; padding:0.0025em 0.75em; border:none;\" type=\"submit\" class=\"button2\"");
            EndContext();
            BeginWriteAttribute("onclick", " onclick=\"", 1219, "\"", 1314, 3);
            WriteAttributeValue("", 1229, "location.href=\'", 1229, 15, true);
#line 27 "C:\Users\Administrator\Documents\GitHub\net\Plagiarism_Checker\Plagiarism-Checker\Views\Student\Index.cshtml"
WriteAttributeValue("", 1244, Url.Action("AddSolutionPage", "Student", new { id = item._Task.Id }), 1244, 69, false);

#line default
#line hidden
            WriteAttributeValue("", 1313, "\'", 1313, 1, true);
            EndWriteAttribute();
            BeginContext(1315, 122, true);
            WriteLiteral(">Переглянути</button>\r\n                \r\n            </div>\r\n            <div style=\"clear:both;\"></div>\r\n        </div>\r\n");
            EndContext();
#line 32 "C:\Users\Administrator\Documents\GitHub\net\Plagiarism_Checker\Plagiarism-Checker\Views\Student\Index.cshtml"
    }

#line default
#line hidden
            BeginContext(1444, 11, true);
            WriteLiteral("    <button");
            EndContext();
            BeginWriteAttribute("onclick", " onclick=\"", 1455, "\"", 1519, 3);
            WriteAttributeValue("", 1465, "location.href=\'", 1465, 15, true);
#line 33 "C:\Users\Administrator\Documents\GitHub\net\Plagiarism_Checker\Plagiarism-Checker\Views\Student\Index.cshtml"
WriteAttributeValue("", 1480, Url.Action("ListTestWork", "Student"), 1480, 38, false);

#line default
#line hidden
            WriteAttributeValue("", 1518, "\'", 1518, 1, true);
            EndWriteAttribute();
            BeginContext(1520, 125, true);
            WriteLiteral(" class=\"button2\">УСІ САМОСТІЙНІ</button>\r\n</div>\r\n<div class=\"largeDarkDiv\" style=\"flex-direction:row;margin: 5em;\">\r\n    <h2");
            EndContext();
            BeginWriteAttribute("onclick", " onclick=\"", 1645, "\"", 1709, 3);
            WriteAttributeValue("", 1655, "location.href=\'", 1655, 15, true);
#line 36 "C:\Users\Administrator\Documents\GitHub\net\Plagiarism_Checker\Plagiarism-Checker\Views\Student\Index.cshtml"
WriteAttributeValue("", 1670, Url.Action("ListHomework", "Student"), 1670, 38, false);

#line default
#line hidden
            WriteAttributeValue("", 1708, "\'", 1708, 1, true);
            EndWriteAttribute();
            BeginContext(1710, 25, true);
            WriteLiteral(">Домашнє завдання:</h2>\r\n");
            EndContext();
#line 37 "C:\Users\Administrator\Documents\GitHub\net\Plagiarism_Checker\Plagiarism-Checker\Views\Student\Index.cshtml"
     foreach (var item in Model.Hometasks)
    {

#line default
#line hidden
            BeginContext(1786, 188, true);
            WriteLiteral("        <div style=\"width:80%;height:180px;margin-bottom:20px;border:solid;border-width:1px\">\r\n            <div style=\"background-color:#d8d8d8\">\r\n                <p style=\"color:#000000\">");
            EndContext();
            BeginContext(1975, 21, false);
#line 41 "C:\Users\Administrator\Documents\GitHub\net\Plagiarism_Checker\Plagiarism-Checker\Views\Student\Index.cshtml"
                                    Write(item.NameOfDiscipline);

#line default
#line hidden
            EndContext();
            BeginContext(1996, 79, true);
            WriteLiteral("</p>\r\n            </div>\r\n            <p style=\"color:#d8d8d8; font-size:13px\">");
            EndContext();
            BeginContext(2076, 33, false);
#line 43 "C:\Users\Administrator\Documents\GitHub\net\Plagiarism_Checker\Plagiarism-Checker\Views\Student\Index.cshtml"
                                                Write(item.TaskAssignment.Requirenments);

#line default
#line hidden
            EndContext();
            BeginContext(2109, 86, true);
            WriteLiteral("</p>\r\n            <p style=\"color:#555454; font-size:10px; justify-content:flex-end;\">");
            EndContext();
            BeginContext(2196, 11, false);
#line 44 "C:\Users\Administrator\Documents\GitHub\net\Plagiarism_Checker\Plagiarism-Checker\Views\Student\Index.cshtml"
                                                                           Write(item.Lector);

#line default
#line hidden
            EndContext();
            BeginContext(2207, 3, true);
            WriteLiteral(" - ");
            EndContext();
            BeginContext(2211, 9, false);
#line 44 "C:\Users\Administrator\Documents\GitHub\net\Plagiarism_Checker\Plagiarism-Checker\Views\Student\Index.cshtml"
                                                                                          Write(item.Time);

#line default
#line hidden
            EndContext();
            BeginContext(2220, 202, true);
            WriteLiteral("</p>\r\n\r\n            <div style=\"display: flex;justify-content: center;margin-top:8px\">\r\n                <button style=\"font-size:6px; padding:0.0025em 0.75em; border:none;\" type=\"submit\" class=\"button2\"");
            EndContext();
            BeginWriteAttribute("onclick", " onclick=\"", 2422, "\"", 2517, 3);
            WriteAttributeValue("", 2432, "location.href=\'", 2432, 15, true);
#line 47 "C:\Users\Administrator\Documents\GitHub\net\Plagiarism_Checker\Plagiarism-Checker\Views\Student\Index.cshtml"
WriteAttributeValue("", 2447, Url.Action("AddSolutionPage", "Student", new { id = item._Task.Id }), 2447, 69, false);

#line default
#line hidden
            WriteAttributeValue("", 2516, "\'", 2516, 1, true);
            EndWriteAttribute();
            BeginContext(2518, 118, true);
            WriteLiteral(">Виконати</button>\r\n\r\n            </div>\r\n            <div style=\"clear:both;\"></div>\r\n        </div>\r\n        <button");
            EndContext();
            BeginWriteAttribute("onclick", " onclick=\"", 2636, "\"", 2700, 3);
            WriteAttributeValue("", 2646, "location.href=\'", 2646, 15, true);
#line 52 "C:\Users\Administrator\Documents\GitHub\net\Plagiarism_Checker\Plagiarism-Checker\Views\Student\Index.cshtml"
WriteAttributeValue("", 2661, Url.Action("ListHomework", "Student"), 2661, 38, false);

#line default
#line hidden
            WriteAttributeValue("", 2699, "\'", 2699, 1, true);
            EndWriteAttribute();
            BeginContext(2701, 54, true);
            WriteLiteral(" class=\"button2\">ПЕРЕГЛЯНУТИ ГОТОВІ ДОМАШНІ</button>\r\n");
            EndContext();
#line 53 "C:\Users\Administrator\Documents\GitHub\net\Plagiarism_Checker\Plagiarism-Checker\Views\Student\Index.cshtml"

    }

#line default
#line hidden
            BeginContext(2764, 10, true);
            WriteLiteral("</div>\r\n\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Plagiarism_Checker.Models.Student.StudentTasks> Html { get; private set; }
    }
}
#pragma warning restore 1591
